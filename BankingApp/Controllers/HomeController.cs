using BankingApp.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankingApp.Models;
using BankingApp.Filters;

namespace BankingApp.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        BankManager _manager;

        #endregion

        #region Ctor

        public HomeController()
            : this(new BankManager())
        { }

        public HomeController(BankManager manager)
        {
            _manager = manager;
        }

        #endregion

        #region Methods

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string accountNumber)
        {

            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Models.LoginModel accountData)
        {
            //write the logic to get the account from the DB
            Account account = _manager.GetAccount(accountData.AccountNumber);
            if (!ModelState.IsValid)
            {
                return View();

            }

            if (account == null)
            {
                ViewBag.message = "Your account number is not valid";
                return View();
            }
            else
            {
                return RedirectToAction("Detail", new { accountNumber = account.AccountNumber });
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult _Register()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            var newCustomer = _manager.CreateAccount(customer);
            var account = newCustomer.Accounts.FirstOrDefault();
            if (!ModelState.IsValid)
            {
                //return View();
                return Json(false);

            }
            if (account == null)
            {
                ViewBag.message = "Your account number is not valid";
                //  return View();
                return Json(false);
            }
            else
            {
                // return RedirectToAction("Detail", new { accountNumber = account.AccountNumber });
                // return RedirectToAction("GetAccounts");
                return Json(true);
            }
        }

        public ActionResult Detail(string accountNumber, int customerID = 0)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Account account = _manager.GetAccount(accountNumber);
            AccountModel accountModel = new AccountModel();

            if (account == null)
            {
                Customer customer = _manager.GetCustomer(customerID);
                accountModel.Customer = AccountModel.MapCustomer(customer);
            }
            else
            {
                accountModel = AccountModel.Mapping(account);
            }

            return View(accountModel);
        }

        public ActionResult Deposit(string accountNumber)
        {
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return View(model);
        }

        public ActionResult _Deposit(string accountNumber)
        {
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return PartialView(model);
        }

        [HttpPost]
        [CustomActionFilter]
        public ActionResult Deposit(AccountModel accountData)
        {
            //get account from Db
            Account account = _manager.GetAccount(accountData.AccountNumber);
            if (!ModelState.IsValid)
            {
                //   return View();
                return PartialView("~/Views/Home/_Deposit.cshtml", accountData);
            }

            if (account == null)
            {
                ViewBag.message = "Your account number is not valid";
                // return View();
                return Json(false);
            }
            else
            {
                //if (Request.Form["deposit"] != null)
                //{
                account.Deposit(accountData.TransactionAmount);
                _manager.Update();
                //  return RedirectToAction("Detail", new { accountNumber = account.AccountNumber });
                // return RedirectToAction("GetAccounts");
                return Json(true);
                //}
                //else if(Request.Form["withdraw"] != null)
                //{
                //    account.Withdraw(accountData.Balance);
                //    _manager.Update();
                //    return RedirectToAction("Detail", new { accountNumber = account.AccountNumber });
                //}
            }
        }

        public ActionResult Withdraw(string accountNumber)
        {
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return View(model);
        }

        public ActionResult _Withdraw(string accountNumber)
        {
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Withdraw(Models.AccountModel accountData)
        {
            //get account from Db

            Account account = _manager.GetAccount(accountData.AccountNumber);
            if (!ModelState.IsValid)
            {
                //return View();
                return PartialView("~/Views/Home/_Withdraw.cshtml", accountData);
            }

            if (account == null)
            {
                ViewBag.message = "Your account number is not valid";

                //return View();
                return Json(false);
            }
            else
            {
                bool result = account.Withdraw(accountData.TransactionAmount);

                if (result)
                {
                    _manager.Update();
                    return Json(true);
                }

                return Json(false);

                //  return RedirectToAction("GetAccounts");
                // return RedirectToAction("Detail", new { accountNumber = account.AccountNumber });
            }
        }

        public ActionResult Update(string accountNumber)
        {   
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return View(model);
        }

        public ActionResult _Update(string accountNumber)
        {
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Update(Models.AccountModel customerData)
        {
            //get account from Db
            var customer = _manager.GetCustomer(customerData.CustomerId);
            if (!ModelState.IsValid)
            {
                //return View();
                return PartialView("~/Views/Home/_Update.cshtml", customerData);
            }

            if (customer == null)
            {
                ViewBag.message = "Your account number is not valid";
                //return View();
                return Json(false);
            }
            else
            {
                customer.Update(customerData.Customer);
                _manager.Update();
                //return RedirectToAction("Detail", new { accountNumber = customerData.AccountNumber, customerID = customerData.CustomerId });
                //return RedirectToAction("GetAccounts");
                return Json(true);
            }
        }

        public ActionResult Delete(string accountNumber)
        {
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return View(model);
        }

        public ActionResult _Delete(string accountNumber)
        {
            Account account = _manager.GetAccount(accountNumber);
            AccountModel model = AccountModel.Mapping(account);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(AccountModel accountData)
        {
            //get account from Db
            Account account = _manager.GetAccount(accountData.AccountNumber);
            if (ModelState.IsValid)
            {
                //return View();
                return PartialView("~/Views/Home/_Delete.cshtml", accountData);

            }

            if (account == null)
            {
                ViewBag.message = "Your account number is not valid";
                //return View();
                return Json(false);
            }
            else
            {
                var Customer = _manager.DeleteAccount(accountData.AccountNumber);
                //   return RedirectToAction("Detail", new { accountNumber = accountData.AccountNumber, customerID = Customer.CustomerId });
                //return RedirectToAction("GetAccounts");
                return Json(true);
            }
        }

        public JsonResult GetCustomerList()
        {
            var CustomerList = _manager.GetCustomerList();
            List<Grid> grid = new List<Grid>();
            foreach (Customer c in CustomerList)
            {
                grid.Add(new Grid()
                {
                    AccountNumber = c.Accounts.FirstOrDefault().AccountNumber,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    Balance = c.Accounts.FirstOrDefault().Balance,
                });
            }
            return Json(new { gridData = grid }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAccounts()
        {
            List<Account> account = _manager.GetAccount();
            List<AccountModel> accountModelList = new List<AccountModel>();

            foreach (Account a in account)
            {
                var acntData = new AccountModel();
                acntData = AccountModel.Mapping(a);
                accountModelList.Add(acntData);
            }

            return View(accountModelList);
        }
        #endregion
    }
}