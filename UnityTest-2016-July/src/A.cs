using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityTest1
{
    public class A : IA
    {
        public A(int x)
        {

        }

        public B BB { get; set; }
        public B BB2 { get; set; }
        public string P1 { get; set; }
    }
}
