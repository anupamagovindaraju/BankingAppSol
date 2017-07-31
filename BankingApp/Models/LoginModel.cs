using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Account number needs to be entered")]
        public string AccountNumber { get; set; }
    }
}