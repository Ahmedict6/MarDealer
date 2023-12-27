using Entities.Models.Product_Management;
using Entities.Models.User_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shopping_Management
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserNo { get; set; }
        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
        public int OrderPaymentNo { get; set; }
        [ForeignKey("OrderPaymentNo")]
        public virtual OrderPayment OrderPayment { get; set; }
        public int ExporterNo { get; set; }
        public string? ExporterName { get; set; }
        public decimal ExporterPrice { get; set; }
        public int PaymentTypeNo { get; set; }
        public string? PaymentType { get; set; }
        public int OrderStatusNo { get; set; }
        public decimal Total { get; set; }
        public decimal TotalDiscount { get; set; }
        public string? OrderReceiverName { get; set; }
        public string? OrderAddress { get; set; }
        public string? OrderAddressMobile { get; set; }
        public string? AccountNumber { get; set; }
        public string? Expiry { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime OrderModifiedDate { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
    }
}
