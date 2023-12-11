using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Product_Management
{
    public class ProductInventory
    {
        [Key]
        public int Id { get; set; }
        public string? InventoryName { get; set; }
        public string? InventoryDescritpion { get; set; }
        public DateTime InventoryCreatedDate { get; set; }
        public DateTime InventoryModifiedDate { get; set; }

    }
}
