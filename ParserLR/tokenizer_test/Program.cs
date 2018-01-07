using System;
using tokenizer;

namespace tokenizer_test
{
    public class Program
    {
        public static void Main()
        {
            /*
            Parser p = new Parser(" sc ss<aa x=y >");
            var x = p.CreateParsedItems();
             */
            ParsingWithHtmlAgilityPack dht = new ParsingWithHtmlAgilityPack();
            dht.ParseShortHtml();
            Console.WriteLine("Finished tokenizer_test.Program.Main");
        }
    }
}