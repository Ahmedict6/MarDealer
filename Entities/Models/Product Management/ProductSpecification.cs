using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Product_Management
{
    public class ProductSpecification
    {
        [Key]
        public int Id { get; set; }

        public int ProductNo { get; set; }
        [ForeignKey("ProductNo")]
    //    public virtual Product? Product { get; set; }
        public string? SpecificationName { get; set; }
        public string? SpecificationDescritpion { get; set; }
        public DateTime CategoryCreatedDate { get; set; }
        public DateTime CategoryModifiedDate { get; set; }

    }
}
