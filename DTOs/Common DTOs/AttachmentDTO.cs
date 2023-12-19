using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Common_DTOs
{
    public record AttachmentDTO
    {
        public int Id { get; set; }
        public CommonEnums.DocumentItemType AttachmentType { get; set; }
        public byte AttachmentFile{ get; set; }
    }
}
