using FruitImplementations;
using FruitInterfaces;
using NUnit.Framework;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StructureMap_Tests
{
    public class Fruit_Test
    {
        [Test]
        public void Test_Singleton()
        {
            Registry registry1 = new Registry();
            registry1.For<IOutput>().Use<Output>().Singleton();
            registry1.For<IFruit>().Use<Apple>();

            Container con1 = new Container(registry1);
            IOutput output1 = con1.GetInstance<IOutput>();
            IOutput output2 = con1.GetInstance<IOutput>();
            Assert.AreSame(output1, output2);
        }

        [Test]
        public void Test_GetAllInstances()
        {
            Registry registry1 = new Registry();
            registry1.For<IOutput>().Use<Output>().Singleton();
            registry1.For<IFruit>().Use<Apple>();

            Container con1 = new Container(registry1);

            Type t1 = typeof(IOutput);
            Assert.AreEqual(1, ConvertToList(con1, t1).Count);
            Assert.AreEqual(1, ConvertToList(con1, t1).Count);

            Type t2 = typeof(Apple);
            Assert.AreEqual(0, ConvertToList(con1, t2).Count);
            Assert.AreEqual(0, ConvertToList(con1, t2).Count);
        }

        private static List<object> ConvertToList(Container con1, Type t)
        {
            List<object> ret = new List<object>();

            var x = con1.GetAllInstances(t);
            foreach (object o in x)
            {
                ret.Add(o);
            }

            return ret;
        }

        [Test]
        [ExpectedException(typeof(StructureMapConfigurationException))]
        public void Test_Without_Registration()
        {
            Registry registry1 = new Registry();
            Container con1 = new Container(registry1);
            IOutput output1 = con1.GetInstance<IOutput>();
        }

        [Test]
        public void Test_Registry_Scan()
        {
            Registry registry1 = new Registry();
            registry1.Scan(scanner => {
                // scanner.Assembly("FruitImplementations");
                scanner.AssemblyContainingType<Output>();
                scanner.WithDefaultConventions();
            });
            Container con1 = new Container(registry1);
            IOutput output1 = con1.GetInstance<IOutput>();
            IOutput output2 = con1.GetInstance<IOutput>();
            Assert.AreNotSame(output1, output2);
        }

        [Test]
        public void Test_OwnMockOutput()
        {
            Registry registry1 = new Registry();
            registry1.For<IOutput>().Use<OwnMockOutput>().Singleton();
            registry1.For<IFruit>().Use<Apple>();

            Container con1 = new Container(registry1);

            IFruit fruit = con1.GetInstance<IFruit>();
            fruit.Pick();
            fruit.Eat();
            fruit.Throw();

            OwnMockOutput output = (OwnMockOutput)con1.GetInstance<IOutput>();
            Assert.AreEqual(3, output.List.Count);
        }
    }
}
