using ShoppingProject.BusinessValidation;
using ShoppingProject.Domain;
using ShoppingProject.InterfaceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace ShoppingProject.Factory
{
    // Design Pattern : Simple factory 
    public static class SimpleFactory<AnyType>
    {
        private static Lazy<IUnityContainer> customers = null;
        static SimpleFactory()
        {
            customers = new Lazy<IUnityContainer>(() => LoadCustomer());
        }
        private static IUnityContainer LoadCustomer()
        {
            UnityContainer temp = new UnityContainer();
            temp.RegisterType<ICustomer, Customer>("Customer", 
                new InjectionConstructor(new CustomerValidationAll()));
            temp.RegisterType<ICustomer, Lead>("Lead Customer",
                new InjectionConstructor(new LeadValidation()));
            return temp;
        }

        public static AnyType Create(string CustType)
        {
            // Design Pattern : RIP Pattern
            return customers.Value.Resolve<AnyType>(CustType);
        }
    }
}
