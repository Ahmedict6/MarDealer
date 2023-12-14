using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderPaymentDTO
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public decimal Amount { get; set; }
        public string? Provider { get; set; }
        public int Status { get; set; }
        public DateTime PaymentCreatedDate { get; set; }
        public DateTime PaymentModifiedDate { get; set; }
    }
}
