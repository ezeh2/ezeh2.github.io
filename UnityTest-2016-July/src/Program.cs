using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            WithAppConfigurationFile();
            WithRegisterTypeMethod();
        }

        private static void WithRegisterTypeMethod()
        {

            using (var container = new UnityContainer())
            {
                /*
                container.RegisterTypes(
                  AllClasses.FromAssemblies(),
                  WithMappings.FromMatchingInterface,
                  WithName.TypeName,
                  WithLifetime.ContainerControlled);
                 */

                container.RegisterType(typeof(A), new InjectionConstructor(9090), new InjectionProperty("P1", "a prop"));

                A a1 = container.Resolve<A>();
                A a2 = (A)container.Resolve<IA>();
                B b1 = container.Resolve<B>();
                B b2 = (B)container.Resolve<IB>();
            }
        }

        private static void WithAppConfigurationFile()
        {
            IUnityContainer myContainer = new UnityContainer();
            myContainer.LoadConfiguration();
            A a1 = (A)myContainer.Resolve(typeof(A));

            A a2 = myContainer.Resolve<A>("A2");

            A a3 = (A)myContainer.Resolve<IA>();
        }
    }
}
