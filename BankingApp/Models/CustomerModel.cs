using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please fill out this field")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please fill out this field")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please fill out this field")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please fill out this field")]
        [RegularExpression(@"^[789]\d{9}$",ErrorMessage ="Please enter a valid Phone Number")]
        public string PhoneNumber { get; set; }

    }
}