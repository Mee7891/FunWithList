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
            Console.WriteLine("--------------------------------------------------------------");

            SellLinkedList<string> sList2 = new SellLinkedList<string>("~");
            sList2.AddAtEnd("This");
            sList2.AddAtEnd("circle");
            sList2.AddAtEnd("will");
            sList2.AddAtEnd("have");
            sList2.AddAtEnd("circle");
            sList2.AddAtEnd("starting");
            sList2.AddAtEnd("here,");
            sList2.AddAtEnd("let's");
            sList2.AddAtEnd("see");
            sList2.AddAtEnd("what");
            sList2.AddAtEnd("rabbit");
            sList2.AddAtEnd("and");
            sList2.AddAtEnd("turtle");
            sList2.AddAtEnd("gonna");
            sList2.AddAtEnd("say");

            foreach (string str in sList2)
                Console.WriteLine(str);

            if (sList2.MakeCircle(6) > 0)
                Console.WriteLine("\nAnd rabbit with turtle say: {0}", sList2.HasCircle(true));

            Console.WriteLine("\nAnd after doing their job they say: {0}", sList2.HasCircle(true));

            Console.ReadKey();
        }
    }
}
