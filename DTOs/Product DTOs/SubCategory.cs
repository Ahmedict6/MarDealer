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
    public record SubCategoryDTO
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescritpion { get; set; }
        public int CategoryNo { get; set; }
        public  ProductCategory? ProductCategory { get; set; }
        public DateTime CategoryCreatedDate { get; set; }
        public DateTime CategoryModifiedDate { get; set; }
    }
}
