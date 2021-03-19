using System;
using System.Collections;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] _list = new object[] { "a string", new[] { "a", "b", "c" }, "spam", new[] { "eggs" }, new[] { new[] { "one", "two" }, new[] { "three", "four" } } };

            var tables = DumpList("Foo", _list);
        }

        public static string DumpList(string prefix, object list)
        {
            var stringBuilder = new StringBuilder();

            var formatList = (IList)list;
            var index = 0;

            foreach (var item in formatList)
            {
                var formattedPrefix = $"{prefix}.{index}";
                Type valueType = item.GetType();
                if (valueType.IsArray)
                {
                    var nested = DumpList(formattedPrefix, item);
                    stringBuilder.Append(nested);
                }
                else
                {
                    formattedPrefix = $"{formattedPrefix}:";
                    stringBuilder.AppendLine($"{formattedPrefix} {item}");
                }

                index++;
            }

            return stringBuilder.ToString();
        }
    }
}
