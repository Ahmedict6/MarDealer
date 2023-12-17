using Entities.Models.Common;
using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderDetailsDTO
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public int ExporterNo { get; set; }
        public string? UserName { get; set; }
        public string? PaymentType { get; set; }
        public OrderPaymentDTO OrderPayment { get; set; }
        public decimal ItemTotalTotalPrice { get; set; }
        public string? ExporterName { get; set; }
        public decimal ExporterPrice { get; set; }
        public int ExporterDeals { get; set; }
        public string? OrderAdress { get; set; }
        public string? OrderAdressMobile { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime OrderModifiedDate { get; set; }
    }
}
