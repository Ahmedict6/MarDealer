using DTOs.User_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderDTO
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public int ExporterNo { get; set; }
        public int PyamentNo { get; set; }
        public  OrderPaymentDTO OrderPayment { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime OrderModifiedDate { get; set; }
    }
}
