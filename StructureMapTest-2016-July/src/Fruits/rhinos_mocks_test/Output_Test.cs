using FruitInterfaces;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rhinos_test
{
    public class Output_Test
    {
        [Test]
        public void Test_AssertWasCalled1()
        {
            var stubUserRepository = MockRepository.GenerateStub<IOutput>();
            stubUserRepository.AssertWasNotCalled(x => x.Print(""));

            stubUserRepository.Print("hallo");
            stubUserRepository.AssertWasCalled(x => x.Print("hallo"));
            
        }

        [Test]
        public void Test_AssertWasCalled2()
        {
            var stubUserRepository = MockRepository.GenerateStub<IOutput>();
            stubUserRepository.AssertWasNotCalled(x => x.Print(""));

            stubUserRepository.Print("hallo");
            stubUserRepository.Print("efefeef");
            stubUserRepository.AssertWasCalled(x => x.Print("efefeef"));
            stubUserRepository.AssertWasCalled(x => x.Print("hallo"));
        }

        [Test]
        public void Test_VerifyAllExpectations()
        {
            // arrange
            var stubUserRepository = MockRepository.GenerateStub<IOutput>();
            // ???
            /*
            stubUserRepository.Print(null);
            LastCall.Constraints(Is.EqualTo("Y2"));
            stubUserRepository.Replay<IOutput>();

            // act
            stubUserRepository.Print("Y2");
            // stubUserRepository.Print("Y2");

            // assert
            stubUserRepository.VerifyAllExpectations();
            */
        }
    }
}
