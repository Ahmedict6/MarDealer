using DTOs.Product_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public virtual OrderDTO Order { get; set; }
        public int ProductNo { get; set; }
        public  ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderItemCreatedDate { get; set; }
        public DateTime OrderItemModifiedDate { get; set; }
    }
}
