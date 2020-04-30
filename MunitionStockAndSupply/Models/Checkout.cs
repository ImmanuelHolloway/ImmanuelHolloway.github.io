using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MunitionStockAndSupply.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Shipping Address")]
        public string ShippingAddress { get; set; }
        [Required]
        [DisplayName("Credit Card Number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Please enter a valid credit card number")]
        public string CreditCardNumber { get; set; }
        [Required]
        [DisplayName("Expiration")]
        [DataType(DataType.Date)]
        public string ExperationDate { get; set; }
        [Required]
        [DisplayName("CCV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Please enter a valid security code.")]
        public string SecurityCode { get; set; }
    }
}
