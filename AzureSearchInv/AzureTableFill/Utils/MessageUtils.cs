using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTableFill.Utils {
    public static class MessageUtils {

        private const int PartitionsCount = 10;
        private const int Exceed = 100;
        private const string ChildStr = "child";

        private static int partitionIndex = 0;

        private static readonly List<Guid> PredefinedPartitionKeys;

        private static int _count;

        static MessageUtils () {
            _count = 0;
            PredefinedPartitionKeys = new List<Guid>(PartitionsCount);
            for ( int i = 0; i < PartitionsCount; i++ ) {
                PredefinedPartitionKeys.Add( Guid.NewGuid() );
            }
        }

        public static string GetPartitionId ( int index ) {
            if ( index%Exceed == 0 ) {
                partitionIndex++;
            }
            if ( partitionIndex == PartitionsCount ) {
                partitionIndex = 0;
            }
            return PredefinedPartitionKeys[partitionIndex].ToString();
        }

        public static string GetMessageId ( int index ) {
            return index.ToString();
        }

        public static string GetMessage ( int index ) {
            var firstPart = Guid.NewGuid().ToString().Replace( '-', ' ' );
            var secondPart = Guid.NewGuid().ToString().Replace('-', ' ');
            if ( (index%Exceed == 0 || index%Exceed == 99) )
                _count++;
            return (index % Exceed == 0 || index % Exceed == 99) ? $"{firstPart} {ChildStr} {secondPart}" : $"{firstPart} {secondPart}";
        }

        public static DateTime GetMessageCreated ( int index ) {
            return DateTime.Now.AddMinutes( -10 * index );
        }

        public static int GetCount () {
            return _count;
        }
    }
}
