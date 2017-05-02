using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithList
{
    class Program
    {
        static void Main(string[] args)
        {
            SellLinkedList<string> sList1 = new SellLinkedList<string>("~");
            sList1.AddAtEnd("No");
            sList1.AddAtEnd("circle");
            sList1.AddAtEnd("in");
            sList1.AddAtEnd("this");
            sList1.AddAtEnd("list");

            foreach(string str in sList1)
                Console.WriteLine(str);

            Console.WriteLine("\nAnd rabbit with turtle say: {0}", sList1.HasCircle(false));

            Console.ReadKey();
        }
    }
}
