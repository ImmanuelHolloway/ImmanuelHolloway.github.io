using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MunitionStockAndSupply.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public bool IsItemRestricted { get; set; }
        public string ItemPrice { get; set; }
        public int? SellerId { get; set; }
    }
}
