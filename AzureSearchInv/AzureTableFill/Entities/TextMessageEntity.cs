using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableFill.Entities {
    public class TextMessageEntity : TableEntity {
        public TextMessageEntity ( string id, string messageId ) {
            this.PartitionKey = id;
            this.RowKey = messageId;
        }

        public TextMessageEntity () { }

        public string Message { get; set; }

        public DateTime Created { get; set; }
    }
}
