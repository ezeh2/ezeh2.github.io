using FruitInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitImplementations
{
    public class Apple : IFruit
    {
        private IOutput output;

        public Apple(IOutput output)
        {
            this.output = output;
            this.Weight = 2000;
        }

        public void Pick()
        {
            this.output.Print("Pick");
        }

        public void Eat()
        {
            this.output.Print("Eat");
        }

        public void Throw()
        {
            this.output.Print("Throw");
        }

        public int Weight
        {
            get;
            private set;
        }
    }
}
