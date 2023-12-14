
using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Product_DTOs
{
    public record ProductPayloadDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescritpion { get; set; }
        public string? ProductPrice { get; set; }
        public int ProductCategoryNo { get; set; }
        public int SubCategoryNo { get; set; }
        public int SubOfSubCategoryNo { get; set; }
        public int ProductInventoryNo { get; set; }
        public int ProductDiscountNo { get; set; }
        public int UserNo { get; set; }
        public String[] Images { get; set; }
        public string? ProductUnit { get; set; }



    }
}
