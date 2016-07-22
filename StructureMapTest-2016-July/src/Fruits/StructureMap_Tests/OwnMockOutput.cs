using FruitInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMap_Tests
{
    public class OwnMockOutput : IOutput
    {
        public List<string> List { get; private set; } 

        public OwnMockOutput()
        {
            List = new List<string>();
        }

        public void Print(string str)
        {
            List.Add(str);
        }
    }
}
