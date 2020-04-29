using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunitionStockAndSupply.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public int SellerID { get; set; }
    }
}
