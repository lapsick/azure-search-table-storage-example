using System;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace MessageSearchApp.Models {
    [SerializePropertyNamesAsCamelCase]
    public partial class MessageModel {
        //id
        public string PartitionKey { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }
    }
}