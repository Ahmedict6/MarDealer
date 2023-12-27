using DTOs.Product_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int ProductNo { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountAmount { get; set; }
        public string? DiscountDescription { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
