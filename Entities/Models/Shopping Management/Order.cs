using Entities.Models.Product_Management;
using Entities.Models.User_Management;
using System;
using System.Collections.Generic;
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
        public int UserNo { get; set; }
        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
        public int PyamentNo { get; set; }
        [ForeignKey("PyamentNo")]
        public virtual OrderPayment OrderPayment { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime OrderModifiedDate { get; set; }
    }
}
