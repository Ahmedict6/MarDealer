using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Product_DTOs
{
    public record AllCategoriesDTO
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescritpion { get; set; }
        public int ParentNo { get; set; }
    }
}
