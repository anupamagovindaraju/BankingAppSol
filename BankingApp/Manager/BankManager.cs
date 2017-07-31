using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BankingApp.Manager
{
    public class BankManager : IDisposable
    {
        BankAppEntities2 _context;

        public BankManager()
        {
            _context = new BankAppEntities2();
        }

        public Account GetAccount(string AccountNo)
        {
            try
            {
                List<Account> account = _context.Accounts.ToList();

                foreach (Account a in account)
                {
                    if (AccountNo == a.AccountNumber)
                        if (a != null)
                            return a;
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return null;
        }

        public List<Account> GetAccount()
        {
            try
            {
                List<Account> accounts = _context.Accounts.ToList();
                if (accounts != null)
                    return accounts;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return null;
        }

        public Customer GetCustomer(int CustomerID)
        {
            return _context.Customers.Where(x => x.CustomerId == CustomerID).FirstOrDefault();
        }

        public List<Customer> GetCustomerList()
        {
            return _context.Customers.ToList();
        }

        /// <summary>
        /// Creates Account
        /// </summary>
        /// <param name="customer">Customer Obj</param>
        /// <returns>Customer Data</returns>
        public Customer CreateAccount(Customer customer)
        {
            //1. Get Customer
            //2. Create Account Obj
            //3. Generate Accnt no
            //4. Save Cus and Accnt in cntxt
            try
            {
                if (customer == null)
                    throw new ArgumentNullException("customer", "Customer cannot be null");

                Account account = new Account();
                account.GenerateAccountNumber();
                customer.Accounts.Add(account);
                _context.Customers.Add(customer);

                _context.SaveChanges();
                if (customer != null)
                    return customer;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return null;

        }

        public Customer DeleteAccount(string accountNumber)
        {
            try
            {
                List<Account> accounts = _context.Accounts.ToList();
                foreach (Account a in accounts)
                {
                    if (accountNumber == a.AccountNumber)
                    {
                        var CustomerId = a.CustomerId;
                        _context.Accounts
                            .Where(x => x.CustomerId == a.CustomerId).ToList()
                            .ForEach(x => _context.Accounts.Remove(x));
                        //_context.Customers.Remove(a.Customer);
                        // _context.SaveChanges();
                        Update();
                        return _context.Customers.Where(x => x.CustomerId == CustomerId).FirstOrDefault();
                    }
                }
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            return null;
        }

        public void Update()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}