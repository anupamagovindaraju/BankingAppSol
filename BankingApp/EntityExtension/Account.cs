using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApp
{
    public partial class Account
    {
        public void GenerateAccountNumber()
        {
            AccountNumber = Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        public decimal Deposit(decimal? amount)
        {
            if (!amount.HasValue)
                return 0m;

            Balance += amount.Value;
            return Balance;
        }

        public bool Withdraw(decimal? amount)
        {
            if (!amount.HasValue)
                return false;
            if (Balance > 0&& amount<=Balance)
            {
                Balance -= amount.Value;
                return true;
            }
            return false;
        }

        public void Update(CustomerModel customer)
        {
            Customer.FirstName = customer.FirstName;
            Customer.LastName = customer.LastName;
            //Customer.PhoneNumber = customer.PhoneNumber;
            Customer.Address = customer.Address;
        }
    }
}