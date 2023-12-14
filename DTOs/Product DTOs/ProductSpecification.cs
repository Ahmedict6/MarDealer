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
    public record ProductSpecificationDTO
    {
        public int Id { get; set; }

        public int ProductNo { get; set; }
        public  Product? Product { get; set; }
        public string? SpecificationName { get; set; }
        public string? SpecificationDescritpion { get; set; }
        public DateTime CategoryCreatedDate { get; set; }
        public DateTime CategoryModifiedDate { get; set; }
    }
}
