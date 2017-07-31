using System;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount needs to be entered")]
        [Range(0, int.MaxValue, ErrorMessage = "Amount must be a positive number")]
        public decimal? TransactionAmount { get; set; }

        public virtual CustomerModel Customer { get; set; }

        public static AccountModel Mapping(Account account)
        {
            CustomerModel customer = null;
            if (account == null)
                return null;

            customer = MapCustomer(account.Customer);

            AccountModel model = new AccountModel()
            {
                AccountNumber = account.AccountNumber,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                Customer = customer
            };

            return model;
        }

        public static CustomerModel MapCustomer(Customer customer)
        {
            if (customer == null)
                return null;

            var customerModel = new CustomerModel()
            {
                Address = customer.Address,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CustomerId = customer.CustomerId,
                PhoneNumber = customer.PhoneNumber
            };
            return customerModel;
        }
    }
}
