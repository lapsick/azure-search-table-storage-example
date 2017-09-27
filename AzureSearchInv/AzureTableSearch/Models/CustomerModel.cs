using System;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace AzureTableSearch.Models {
    [SerializePropertyNamesAsCamelCase]
    public partial class CustomerModel {
        //first name
        public string RowKey { get; set; }

        //last name
        public string PartitionKey { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }
    }
}