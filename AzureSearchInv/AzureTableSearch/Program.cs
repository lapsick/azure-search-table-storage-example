using System;
using System.Configuration;
using AzureTableSearch.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace AzureTableSearch {
    class Program {
        #region Constants

        const string SearchIndexName = "customers";

        #endregion

        static void Main ( string[] args ) {
            SearchServiceClient serviceClient = CreateSearchServiceClient();

            SearchIndexClient indexClient = GetSearchIndexClient();
            //1. Search the entire index for the term 'Roman1' and return only the Email field
            SearchWithoutFilterWithOneFieldReturns(indexClient);

            //2. Apply a filter to the index to find customers with rating less than 200 and return only Last Name and Phone number
            //todo: uncomment when index will be re-created
            //SearchWithFilter(indexClient);

            //3. Search the entire index for the term 'Roman2'
            SearchWithoutFilter(indexClient);
            
            Console.WriteLine("{0}", "Complete.  Press any key to end application...\n");
            Console.ReadKey();
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

            SearchIndexClient indexClient = new SearchIndexClient(searchServiceName, SearchIndexName, new SearchCredentials(queryApiKey));
            return indexClient;
        }

        private static void DeleteCustomersIndexIfExists(SearchServiceClient serviceClient)
        {
            if (serviceClient.Indexes.Exists(SearchIndexName))
            {
                serviceClient.Indexes.Delete(SearchIndexName);
            }
        }

        private static void WriteDocuments ( DocumentSearchResult<CustomerModel> searchResults ) {
            foreach ( SearchResult<CustomerModel> result in searchResults.Results ) {
                Console.WriteLine(result.Document);
            }

            Console.WriteLine();
        }

        #region Search Helpers

        private static void SearchWithoutFilter(SearchIndexClient indexClient)
        {
            SearchParameters parameters;
            DocumentSearchResult<CustomerModel> results;

            Console.WriteLine("Search the entire index for the term 'Roman2':\n");

            parameters = new SearchParameters();
            results = indexClient.Documents.Search<CustomerModel>("Roman2", parameters);

            WriteDocuments(results);
        }

        private static void SearchWithFilter(SearchIndexClient indexClient)
        {
            SearchParameters parameters;
            DocumentSearchResult<CustomerModel> results;

            //todo: to test filter set Rating as flterable in index schema on azure portal
            Console.Write("Apply a filter to the index to find customers with rating less than 200, ");
            Console.WriteLine("and return the Last Name and Phone number:\n");

            parameters =
                new SearchParameters()
                {
                    Filter = "Rating lt 200",
                    Select = new[] { "PartitionKey", "PhoneNumber" }
                };

            results = indexClient.Documents.Search<CustomerModel>("*", parameters);

            WriteDocuments(results);
        }

        private static void SearchWithoutFilterWithOneFieldReturns(SearchIndexClient indexClient)
        {
            SearchParameters parameters;
            DocumentSearchResult<CustomerModel> results;

            Console.WriteLine("Search the entire index for the term 'Roman1' and return only the Email field:\n");

            parameters =
                new SearchParameters()
                {
                    Select = new[] { "Email" }
                };

            results = indexClient.Documents.Search<CustomerModel>("Roman1", parameters);

            WriteDocuments(results);
        }

        #endregion

        #endregion
    }
}
