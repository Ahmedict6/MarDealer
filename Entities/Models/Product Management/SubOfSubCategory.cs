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
    public class SubOfSubCategory
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescritpion { get; set; }
        public string? CategoryNameAr { get; set; }
        public string? CategoryDescritpionAr { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
        public int SubCategoryNo { get; set; }
        [ForeignKey("SubCategoryNo")]
        public virtual SubCategory SubCategory { get; set; }
        public DateTime CategoryCreatedDate { get; set; }
        public DateTime CategoryModifiedDate { get; set; }

    }
}
