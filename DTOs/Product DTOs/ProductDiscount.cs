using Entities.Models.Common;
using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Product_DTOs
{
    public record ProductDiscountDTO
    {
        public int Id { get; set; }
        public string DiscountName { get; set; }
        public string DiscountDescritpion { get; set; }
        public int DiscountPercent { get; set; }
        public int UserNo { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEnddDate { get; set; }
        public DateTime DiscountCreatedDate { get; set; }
        public DateTime DiscountModifiedDate { get; set; }
    }
}
