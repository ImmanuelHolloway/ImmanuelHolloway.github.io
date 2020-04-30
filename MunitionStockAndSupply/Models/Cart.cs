using System.ComponentModel;

namespace MunitionStockAndSupply.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Products")]
        public string ItemName { get; set; }
        [DisplayName("Price")]
        public string ItemPrice { get; set; }
        public int SellerID { get; set; }
    }
}
