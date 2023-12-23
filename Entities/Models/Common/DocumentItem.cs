using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Entities.Models.Common
{
    public class DocumentItem
    {
        [Key]
        public int Id { get; set; }
        public string? DocuemntName { get; set; }
        public string? DocumentUrl { get; set; }
        public int DocumentType { get; set; }
        public int? RefereneceNumber { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
        public DateTime DocuementCreatedDate { get; set; }
        public DateTime DocumentModifiedDate { get; set; }

    }
}
