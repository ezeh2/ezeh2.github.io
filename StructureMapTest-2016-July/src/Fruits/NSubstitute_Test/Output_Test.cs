using FruitInterfaces;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSubstitute_Test
{
    public class Output_Test
    {
        [Test]
        public void Test_Received()
        {
            // arrange
            var output = Substitute.For<IOutput>();

            // act
            output.Print("3");
            output.Print("1");
            output.Print("9");

            // assert
            // 3 calls are saved
            IEnumerable<ICall> calls = output.ReceivedCalls();
            List<ICall> calls2 = calls.ToList();
            Assert.That(calls2.Count, Is.EqualTo(3));

            output.Received().Print("3");
            output.Received().Print("1");
            output.Received().Print("9");
        }

        [Test]
        public void Test_Fruit_Weight()
        {
            // arrange
            var output = Substitute.For<IFruit>();

            // act
            output.Weight.Returns(20);

            // assert
            Assert.That(output.Weight, Is.EqualTo(20));
        }

        [Test]
        public void Test_IEnumerable_GetEnumerator()
        {
            // arrange 
            var enumerable = Substitute.For<IEnumerable<string>>();

            List<string> l = new List<string>();
            enumerable.GetEnumerator().Returns<IEnumerator<string>>(l.GetEnumerator());

            // act
            foreach(string s in enumerable)
            {
            }

            enumerable.Received().GetEnumerator();
        }
    }
}