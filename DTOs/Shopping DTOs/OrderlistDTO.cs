using Entities.Models.Common;
using Entities.Models.Product_Management;
using Entities.Models.Shopping_Management;
using Entities.Models.User_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderListDTO
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string? UserName { get; set; }
        public int PyamentNo { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime OrderModifiedDate { get; set; }
    }
}
