using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTableSearch.Models {
    public partial class CustomerModel {
        public override string ToString () {
            var builder = new StringBuilder();

            if ( !string.IsNullOrEmpty(RowKey) ) {
                builder.AppendFormat("First Name: {0}\t", RowKey);
            }

            if ( !string.IsNullOrEmpty(PartitionKey) ) {
                builder.AppendFormat("Last Name: {0}\t", PartitionKey);
            }

            if ( !string.IsNullOrEmpty(Email) ) {
                builder.AppendFormat("Email: {0}\t", Email);
            }

            if ( !string.IsNullOrEmpty(PhoneNumber) ) {
                builder.AppendFormat("Phone: {0}\t", PhoneNumber);
            }

            if ( !string.IsNullOrEmpty(Description) ) {
                builder.AppendFormat("Description: {0}\t", Description);
            }

            return builder.ToString();
        }
    }
}
