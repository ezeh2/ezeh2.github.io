using FruitImplementations;
using FruitInterfaces;
using NUnit.Framework;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureMap_Tests
{
    public class Fruit_Test
    {
        [Test]
        public void Test1()
        {
            Registry registry1 = new Registry();
            registry1.For<IOutput>().Use<Output>().Singleton();
            registry1.For<IFruit>().Use<Apple>();

            Container con1 = new Container(registry1);
            IOutput output1 = con1.GetInstance<IOutput>();
            IOutput output2 = con1.GetInstance<IOutput>();
            bool b1 = output1 == output2;
            IFruit fruit = con1.GetInstance<IFruit>();

            fruit.Pick();
            fruit.Eat();
            fruit.Throw();
        }
    }
}
