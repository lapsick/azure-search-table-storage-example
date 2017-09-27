using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSearchApp.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System.Configuration;

namespace MessageSearchApp.Utils {
    public static class MessageUtils {

        #region Constants

        private static string _searchIndexName;

        #endregion

        private static SearchServiceClient _serviceClient;
        private static SearchIndexClient _indexClient;

        static MessageUtils () {
            _serviceClient = CreateSearchServiceClient();            
        }

        public static List<MessageModel> GetMessageModels (string text, DateTime from, DateTime to, bool isPredefined = false) {
            if ( isPredefined ) {
                _searchIndexName = "oneparentsindex";
                _indexClient = GetSearchIndexClient();
            }
            else {
                _searchIndexName = "allmessagesindex";
                _indexClient = GetSearchIndexClient();
            }

            List<MessageModel> searchResult = null;
            if(string.IsNullOrEmpty( text ) && from == DateTime.MinValue && to == DateTime.MinValue)
                throw new Exception("Please apply the filter and/or text to search");

            if ( !string.IsNullOrEmpty( text ) && from == DateTime.MinValue && to == DateTime.MinValue ) {
                //search for only text
                searchResult = SearchOnlyText(text);
            } else if( !string.IsNullOrEmpty(text) && from > DateTime.MinValue && to > DateTime.MinValue ) {
                //search for text and date range
                searchResult = SearchTextAndDateRange(text, from, to);
            } else if ( string.IsNullOrEmpty( text ) && from > DateTime.MinValue && to > DateTime.MinValue ) {
                //search for only date range
                searchResult = SearchOnlyDateRange(from, to);
            }

            return searchResult;
        }
        

        #region Helpers

        private static SearchServiceClient CreateSearchServiceClient () {
            string searchServiceName = ConfigurationManager.AppSettings["SearchServiceName"];
            string adminApiKey = ConfigurationManager.AppSettings["SearchServiceAdminApiKey"];

            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }

        private static SearchIndexClient GetSearchIndexClient () {
            string searchServiceName = ConfigurationManager.AppSettings["SearchServiceName"];
            string queryApiKey = ConfigurationManager.AppSettings["SearchServiceQueryApiKey"];

            SearchIndexClient indexClient = new SearchIndexClient(searchServiceName, _searchIndexName, new SearchCredentials(queryApiKey));
            return indexClient;
        }

        
        private static List<MessageModel> GetDocuments ( DocumentSearchResult<MessageModel> searchResults ) {
            var resultList = new List<MessageModel>();
            foreach ( var result in searchResults.Results ) {
                resultList.Add(result.Document);
            }

            return resultList;
        }

        #region Search methods

        private static List<MessageModel> SearchOnlyDateRange (DateTime from, DateTime to) {
            List<MessageModel> modelResults = new List<MessageModel>();
            var filter = "Created gt " + from.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ") + " and Created lt " + to.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            var parameters = new SearchParameters() {
                IncludeTotalResultCount = true,
                Filter = filter,
            };
            var results = _indexClient.Documents.Search<MessageModel>("*", parameters);
            while ( results.ContinuationToken != null ) {
                modelResults.AddRange(GetDocuments(results));
                results = _indexClient.Documents.ContinueSearch<MessageModel>(results.ContinuationToken);
            }

            modelResults.AddRange(GetDocuments(results));

            return modelResults;
        }

        private static List<MessageModel> SearchTextAndDateRange (string text, DateTime from, DateTime to) {
            List<MessageModel> modelResults = new List<MessageModel>();
            var filter = "Created gt " + from.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ") + " and Created lt " + to.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            var parameters = new SearchParameters() {
                IncludeTotalResultCount = true,
                Filter = filter,
            };
            var results = _indexClient.Documents.Search<MessageModel>(text, parameters);
            while ( results.ContinuationToken != null ) {
                modelResults.AddRange(GetDocuments(results));
                results = _indexClient.Documents.ContinueSearch<MessageModel>(results.ContinuationToken);
            }

            modelResults.AddRange(GetDocuments(results));

            return modelResults;
        }

        private static List<MessageModel> SearchOnlyText (string text) {
            List<MessageModel> modelResults = new List<MessageModel>();
            var parameters = new SearchParameters() {
                IncludeTotalResultCount = true
            };
            var results = _indexClient.Documents.Search<MessageModel>(text, parameters);
            while ( results.ContinuationToken != null ) {
               modelResults.AddRange( GetDocuments( results ) );
               results = _indexClient.Documents.ContinueSearch<MessageModel>(results.ContinuationToken);
            }

            modelResults.AddRange( GetDocuments( results ) );
            
            return modelResults;
        }

        #endregion

        #endregion
    }
}
