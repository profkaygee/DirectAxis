using System;
using System.Collections.Generic;
using System.Linq;

namespace Batching
{
    class Program
    {
        static void Main(string[] args)
        {
            //NO NEED TO MODIFY MAIN
            var list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var batch in CollectionToBatch(list, short.MaxValue))
            {
                Console.WriteLine("New Batch");
                foreach (var batchItem in batch)
                {
                    Console.WriteLine(batchItem);
                }
            }

        }

        public static IEnumerable<List<T>> CollectionToBatch<T>(IEnumerable<T> items, int batchSize)
        {
            T[] newList = null;
            var count = 0;

            if (batchSize <= 0 || items == null || batchSize > items.Count())
            {
                yield break;
            }

            foreach (var item in items)
            {
                if (newList == null)
                    newList = new T[batchSize];

                newList[count++] = item;

                if (count != batchSize)
                    continue;

                yield return newList.Select(x => x).ToList();

                newList = null;
                count = 0;
            }

            // Return the last bucket with all remaining elements
            if (newList != null && count > 0)
            {
                Array.Resize(ref newList, count);
                yield return newList.Select(x => x).ToList();
            }
        }
    }
}