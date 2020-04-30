using System.ComponentModel;

namespace MunitionStockAndSupply.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [DisplayName("Products")]
        public string ItemName { get; set; }
        [DisplayName("Restricted Status")]
        public bool IsItemRestricted { get; set; }
        [DisplayName("Price")]
        public string ItemPrice { get; set; }
        public int? SellerId { get; set; }
    }
}
