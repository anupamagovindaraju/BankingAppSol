using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApp
{
    public partial class Customer
    {
        public void Update(CustomerModel customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            PhoneNumber = customer.PhoneNumber;
            Address = customer.Address;
        }
    }
}