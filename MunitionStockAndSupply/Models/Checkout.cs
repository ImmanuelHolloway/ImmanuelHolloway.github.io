using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MunitionStockAndSupply.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("Shipping Address")]
        public string ShippingAddress { get; set; }
        [Required]
        [DisplayName("Credit Card Number")]
        public string CreditCardNumber { get; set; }
        [Required]
        [DisplayName("Expiration")]
        [DataType(DataType.Date)]
        public string ExperationDate { get; set; }
        [Required]
        [DisplayName("CCV")]
        public string SecurityCode { get; set; }
    }
}
