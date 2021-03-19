//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestFixture]
    public class SumOfThousandsTest
    {
        [Test]
        public void ShouldHandleBasicCases()
        {
            //Assert.Pass()
        }
    }

    public static class MyStack
    {
        public static int Count<T>(this T items)
        {
            if (items.GetType() != typeof(IEnumerable))
            {
                return 0;
            }

            IList<T> list;
            items.TryCast(out list);

            if (list == null)
                return 0;

            return list.Count;
        }

        public static T Push<T>(this T items, object item)
        {
            if (items.GetType() != typeof(IEnumerable))
            {
                return items;
            }

            IList<T> list;
            items.TryCast(out list);

            if (list == null)
                return items;

            list.Add((T)item);

            return items;
        }

        public static T Pop<T>(this T items)
        {
            if (items.GetType() != typeof(IEnumerable))
            {
                return items;
            }

            IList<T> list;
            items.TryCast(out list);

            if (list == null)
                return items;

            list.RemoveAt(list.Count - 1);
            return items;
        }

        public static bool TryCast<T>(this object obj, out T result)
        {
            if (obj is T)
            {
                result = (T)obj;
                return true;
            }

            result = default(T);
            return false;
        }
    }
}
