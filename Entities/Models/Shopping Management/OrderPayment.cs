using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shopping_Management
{
    public class OrderPayment
    {
        [Key]
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public decimal Amount { get; set; }
        public string? PyamentDescription { get; set; }
        public int Status { get; set; }
        public DateTime PaymentCreatedDate { get; set; }
        public DateTime PaymentModifiedDate { get; set; }
    }
}
