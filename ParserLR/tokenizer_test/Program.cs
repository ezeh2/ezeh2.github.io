using System;
using tokenizer;

namespace tokenizer_test
{
    public class Program
    {
        public static void Main()
        {
            Parser p = new Parser(" sc ss<aa>");
            var x = p.CreateParsedItems();
            Console.WriteLine("Finished tokenizer_test.Program.Main");
        }
    }
}