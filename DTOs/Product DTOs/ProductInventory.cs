using Entities.Models.Common;
using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Product_DTOs
{
    public record ProductInventoryDTO
    {
        public int Id { get; set; }
        public string? InventoryName { get; set; }
        public string? InventoryDescritpion { get; set; }
        public DateTime InventoryCreatedDate { get; set; }
        public DateTime InventoryModifiedDate { get; set; }
    }
}
