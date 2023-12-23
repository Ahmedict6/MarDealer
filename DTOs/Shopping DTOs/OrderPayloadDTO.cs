
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderPayloadDTO
    {
        public int Id { get; set; }
        public string? OrderDescritpion { get; set; }
        public string? OrderAmount{ get; set; }
        public int OrderDiscountAmount { get; set; }
        public int PaymentTypeNo { get; set; }
        public int UserNo { get; set; }
        public int ExporterNo { get; set; }
        public string? ReceiverName { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? AccountNumber { get; set; }
        public string? Expiry { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }



    }
}
