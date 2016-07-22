using FruitInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitImplementations
{
    public class Output : IOutput
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
