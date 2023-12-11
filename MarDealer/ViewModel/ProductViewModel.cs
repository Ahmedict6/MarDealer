using Entities.Models.Common;
using Entities.Models.Product_Management;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarDealer.NewFolder
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescritpion { get; set; }
        public string? ProductPrice { get; set; }
        public int ProductCategoryNo { get; set; }
        [ForeignKey("ProductCategoryNo")]
        public virtual ProductCategory ProductCategory { get; set; }
        public int SubCategoryNo { get; set; }
        [ForeignKey("SubCategoryNo")]
        public virtual SubCategory SubCategory { get; set; }
        public int SubOfSubCategoryNo { get; set; }
        [ForeignKey("SubOfSubCategoryNo")]
        public virtual SubOfSubCategory SubOfSubCategory { get; set; }
        public int ProductInventoryNo { get; set; }
        [ForeignKey("ProductInventoryNo")]
        public virtual ProductInventory ProductInventory { get; set; }
        public int ProductDiscountNo { get; set; }
        [ForeignKey("ProductDiscountNo")]
        public virtual ProductDiscount ProductDiscount { get; set; }
        public  List<DocumentItem> ProductImages { get; set; }

        public int UserNo { get; set; }
        public string? ProductUnit { get; set; }
        public DateTime ProductCreatedDate { get; set; }
        public DateTime ProductModifiedDate { get; set; }

    }
}
