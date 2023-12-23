
using DTOs.Common_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record ExporterDTO
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string? ExporterName { get; set; }
        public int ExportPercentage { get; set; }
        public int ExportDoneDeals { get; set; }
        public decimal FrightPrice { get; set; }
        public string? SocialInsuracePrice { get; set; }
        public string? Mobile { get; set; }
        public string? Telephone { get; set; }
        public bool IsTrusted { get; set; }
        public bool HasDeals { get; set; }
        public List<UsersCommentDTO> PeopleComments { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
    }
}
