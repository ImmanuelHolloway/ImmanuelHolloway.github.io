using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MunitionStockAndSupply.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ShippingAddress { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string ExperationDate { get; set; }
        [Required]
        public string SecurityCode { get; set; }
    }
}
