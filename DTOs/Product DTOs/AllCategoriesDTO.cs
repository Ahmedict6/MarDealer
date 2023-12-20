using DTOs.Product_DTOs;
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
        public int CategoryLevel { get; set; }
        public int ParentNo { get; set; }
    }
    public record AllCategoriesDTO2
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescritpion { get; set; }
        public int CategoryLevel { get; set; }
        public int ParentNo { get; set; }
        public  List<SubCategroyDTO> SubCategories { get; set; }
    }

    public record SubCategroyDTO
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescritpion { get; set; }
        public int CategoryLevel { get; set; }
        public int ParentNo { get; set; }
        public List<SubOfSubDTO> SubOfSubCategories { get; set; }
    }

    public record SubOfSubDTO
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescritpion { get; set; }
        public int CategoryLevel { get; set; }
        public int ParentNo { get; set; }
    }
}
