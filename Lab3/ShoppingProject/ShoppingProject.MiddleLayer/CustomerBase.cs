using ShoppingProject.InterfaceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Domain
{
    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> validation = null;
        public CustomerBase(IValidation<ICustomer> obj)
        {
            validation = obj;
        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public virtual void Validate()
        {
            // "this" is for passing current object
            validation.Validate(this);
        }
    }

    public class Customer : CustomerBase
    {
        // base is for calling parent class
        public Customer(IValidation<ICustomer> obj): base (obj)
        {

        }
    }

    public class Lead : CustomerBase
    {
        public Lead(IValidation<ICustomer> obj) : base(obj)
        {

        }
    }
}
