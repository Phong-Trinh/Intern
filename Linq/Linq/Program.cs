using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Linq
{
   public static class inq
    {
        public static IEnumerable<T> myOfType<T>(this IEnumerable list)
        {
            foreach (object type in list) if (type is T)
                yield return (T)type;
        }
    }

    class Program
    {       
        static void Main(string[] args)
        {
            Console.WriteLine("My LINQ!");
            ArrayList data = new ArrayList();
            data.Add("Nike");
            data.Add("Adidas");
            data.Add(4);
            data.Add(19.5);
            Console.WriteLine("\n\t\tArray before use my LINQ (OfType<string>)\n");
            foreach (object item in data)
            {
                Console.Write( "    "+item );
            }
            Console.WriteLine("\n\n\n\n\t\tAnd this is our array after use my LINQ (OfType<string>)\n");
            var list =data.myOfType<string>();
            foreach (object item in list)
            {
                Console.Write("    " + item);
            }
            Console.ReadKey();
        }
    }
}
