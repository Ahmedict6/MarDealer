using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shopping_Management
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderNo { get; set; }
        [ForeignKey("OrderNo")]
        public virtual Order Order { get; set; }
        public int ProductNo { get; set; }
        [ForeignKey("ProductNo")]
        public virtual Product Product{ get; set; }
        public int Quantity { get; set; }
        public decimal DiscountAmount { get; set; }
        public string? DiscountDescription { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderItemCreatedDate { get; set; }
        public DateTime OrderItemModifiedDate { get; set; }
    }
}
