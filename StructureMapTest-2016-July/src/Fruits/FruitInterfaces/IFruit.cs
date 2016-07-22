using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitInterfaces
{
    public interface IFruit
    {
        void Pick();
        void Eat();
        void Throw();
        int Weight { get; }
    }
}
