using ShoppingProject.MiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Factory
{
    // Design Pattern : Simple factory 
    public static class SimpleFactory
    {
        private static Lazy<Dictionary<string, CustomerBase>> customers = null;
        static SimpleFactory()
        {
            customers = new Lazy<Dictionary<string, CustomerBase>>(() => LoadCustomer());

        }
        private static Dictionary<string, CustomerBase> LoadCustomer()
        {

            Dictionary<string, CustomerBase> temp = new Dictionary<string, CustomerBase>();

            temp.Add("Customer", new Customer());
            temp.Add("Lead Customer", new Lead());

            return temp;
        }

        public static CustomerBase Create(string CustType)
        {
            // Design Pattern : Lazy loading, eager loading
            // Instead of below code, using lazy keyword of c#

            //if (customers.Count == 0)
            //{
            //    customers.Add("Customer", new Customer());
            //    customers.Add("Lead Customer", new Lead());
            //}


            // Design Pattern : RIP Pattern
            return customers.Value[CustType];
            // replacing below with RIP
            //if (CustType=="Customer")
            //{
            //    return new Customer();
            //}
            //else
            //{
            //    return new Lead();
            //}

        }
    }
}
