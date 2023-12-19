using Entities.Models.Common;
using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Common_DTOs
{
    public record DocumentItemDTO
    {
        public int Id { get; set; }

        public string? DocuemntName { get; set; }
        public string? DocumentUrl { get; set; }
        public DocumentItemType? DocumentType { get; set; }
        public int? RefereneceNumber { get; set; }
        public DateTime DocuementCreatedDate { get; set; }
        public DateTime DocumentModifiedDate { get; set; }



        public enum DocumentItemType
        {
            UserProfileImage,
            ProductImage,


        }
    }
}
