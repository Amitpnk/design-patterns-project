using ShoppingProject.InterfaceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.BusinessValidation
{
    public class CustomerValidationAll : IValidation<ICustomer>
    {
        public void Validate(ICustomer customer)
        {
            if (customer.CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if (customer.PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }
            if (customer.BillAmount > 0)
            {
                throw new Exception("Bill is required");
            }
            if (customer.BillDate >= DateTime.Now)
            {
                throw new Exception("Bill date  is not proper");
            }
            if (customer.Address.Length == 0)
            {
                throw new Exception("Address is required");
            }
        }
    }

    public class LeadValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer customer)
        {
            if (customer.CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if (customer.PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }
        }
    }
}
