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
    public record ProductDetails
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescritpion { get; set; }
        public string? ProductPrice { get; set; }
        public int ProductCategoryNo { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public int SubCategoryNo { get; set; }
        [ForeignKey("SubCategoryNo")]
        public virtual SubCategory SubCategory { get; set; }
        public int SubOfSubCategoryNo { get; set; }
        [ForeignKey("SubOfSubCategoryNo")]
        public virtual SubOfSubCategory SubOfSubCategory { get; set; }
        public int ProductInventoryNo { get; set; }
        [ForeignKey("ProductInventoryNo")]
        public  ProductInventory ProductInventory { get; set; }
        public int ProductDiscountNo { get; set; }
        [ForeignKey("ProductDiscountNo")]
        public virtual ProductDiscount ProductDiscount { get; set; }
        public List<DocumentItem> ProductImages { get; set; }
        public List<ProductComment> ProductComments { get; set; }
        public List<ProductSpecification> ProductSpecifications { get; set; }

        public int UserNo { get; set; }
        public string? ProductUnit { get; set; }
        public DateTime ProductCreatedDate { get; set; }
        public DateTime ProductModifiedDate { get; set; }
    }
}
