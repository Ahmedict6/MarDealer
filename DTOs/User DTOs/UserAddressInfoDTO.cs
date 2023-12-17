
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record UserAddressInformationDTO
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Mobile { get; set; }
        public string? Telephone { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
    }
}
