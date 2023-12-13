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
    public record ProductList
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescritpion { get; set; }
        public string? ProductPrice { get; set; }
       

        public int UserNo { get; set; }
        public string? UserName { get; set; }
        public string? UserLogUrl { get; set; }
        public string? ProductImageUrl { get; set; }
        public string? ProductUnit { get; set; }
    }
}
