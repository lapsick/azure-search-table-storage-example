using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureTableFill.Entities;
using AzureTableFill.Utils;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableFill {
    class Program {
        static void Main ( string[] args ) {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //var table = GetCustomerTable( tableClient );
            var table = GetTextMessageTable( tableClient );

            //DisplayCustomerTable( table );

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        #region Helpers

        #region TextMessages

        private static CloudTable GetTextMessageTable ( CloudTableClient tableClient ) {
            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("textmessages");

            if ( table.Exists() ) {
                Console.WriteLine("Do you want to delete existing textmessages table? (Y - yes, N - no)");

                var resp = Console.ReadKey();
                if ( resp.Key == ConsoleKey.Y ) {
                    // Delete the table it if exists.
                    table.DeleteIfExists();
                    Console.WriteLine();
                    Console.WriteLine("Create table...");
                    // Create the table if it doesn't exist.
                    table.CreateIfNotExists();

                    FulfillTextMessagesTable(table);
                }
            } else {
                Console.WriteLine("Create table...");
                // Create the table if it doesn't exist.
                table.CreateIfNotExists();

                FulfillTextMessagesTable(table);
            }

            return table;

        }

        private static void FulfillTextMessagesTable ( CloudTable table ) {
            Console.Write("Adding data...");
            // Create the batch operation.
            TableBatchOperation batchOperation = new TableBatchOperation();
            int max = 100000;
            int exceed = 100;
            for ( int i = 1; i <= max; i++ ) {
                var message = new TextMessageEntity(MessageUtils.GetPartitionId(i), MessageUtils.GetMessageId(i)) {
                    Message = MessageUtils.GetMessage(i),
                    Created = MessageUtils.GetMessageCreated(i)
                };

                if ( i % exceed == 0 ) {
                    // Execute the batch operation.
                    table.ExecuteBatch(batchOperation);
                    batchOperation.Clear();
                    Console.Write(".");
                }

                // Add customer entity to the batch insert operation.
                batchOperation.Insert(message);
            }

            Console.WriteLine("Finished.");
            Console.WriteLine("Messages with child text added: " + MessageUtils.GetCount());
        }

        #endregion

        #region Customers

        private static CloudTable GetCustomerTable ( CloudTableClient tableClient ) {

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("people");


            if ( table.Exists() ) {
                Console.WriteLine("Do you want to delete existing people table? (Y - yes, N - no)");

                var resp = Console.ReadKey();
                if ( resp.Key == ConsoleKey.Y ) {
                    // Delete the table it if exists.
                    table.DeleteIfExists();
                    Console.WriteLine();
                    Console.WriteLine("Create table...");
                    // Create the table if it doesn't exist.
                    table.CreateIfNotExists();

                    FulfillCustomerTable(table);
                }
            } else {
                Console.WriteLine("Create table...");
                // Create the table if it doesn't exist.
                table.CreateIfNotExists();

                FulfillCustomerTable(table);
            }

            return table;
        }

        private static void DisplayCustomerTable ( CloudTable table ) {
            Console.WriteLine("Display table...");

            // Construct the query operation for all customer entities where PartitionKey="Mykhailovych".
            TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Mykhailovych"));

            // Print the fields for each customer.
            foreach ( CustomerEntity entity in table.ExecuteQuery(query) ) {
                Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}", entity.PartitionKey, entity.RowKey,
                    entity.Email, entity.PhoneNumber, entity.Description, entity.Rating);
            }

            Console.WriteLine("Finished.");
        }

        private static void FulfillCustomerTable ( CloudTable table ) {
            Console.Write("Adding data...");
            // Create the batch operation.
            TableBatchOperation batchOperation = new TableBatchOperation();
            int max = 10000;
            int exceed = 100;
            for ( int i = 1; i <= max; i++ ) {
                var customer = new CustomerEntity("Mykhailovych", $"Roman{i}") {
                    Email = $"mykhaylovych{i}@neadevis.com",
                    PhoneNumber = $"425-555-0{i}",
                    Description = Guid.NewGuid().ToString(),
                    Rating = i
                };

                // Add customer entity to the batch insert operation.
                batchOperation.Insert(customer);

                if ( i % exceed == 0 ) {
                    // Execute the batch operation.
                    table.ExecuteBatch(batchOperation);
                    batchOperation.Clear();
                    Console.Write(".");
                }
            }

            Console.WriteLine("Finished.");
        }

        #endregion

        #endregion
    }
}
