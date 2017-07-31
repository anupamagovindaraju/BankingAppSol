using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    public class WithdrawModel
    {
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}