
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Shopping_DTOs
{
    public record OrderPayloadDTO
    {
        public int Id { get; set; }
        public string? OrderDescritpion { get; set; }
        public string? OrderAmount{ get; set; }
        public int OrderDiscountAmount { get; set; }
        public int OrderDiscountNo { get; set; }
        public int UserNo { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }



    }
}
