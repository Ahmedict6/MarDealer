using Entities.Models.User_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Product_Management
{
    public class ProductDiscount
    {
        [Key]
        public int Id { get; set; }
        public string DiscountNameAr { get; set; }
        public string DiscountDescritpion { get; set; }
        public string DiscountName { get; set; }
        public string DiscountDescritpionAr { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
        public int DiscountPercent { get; set; }
        public int UserNo { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEnddDate { get; set; }
        public DateTime DiscountCreatedDate { get; set; }
        public DateTime DiscountModifiedDate { get; set; }

    }
}
