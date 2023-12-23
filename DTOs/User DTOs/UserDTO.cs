using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? Mobile { get; set; }
        public string? FullName { get; set; }
        public string? CountryCode { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? UserToken { get; set; }
        public string? UserImageUrl { get; set; }
        public string? UserType { get; set; }
    }
}
