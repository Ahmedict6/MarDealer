using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record UserPayloadDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Mobile { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int UserTypeNo { get; set; }
        public int UserInformationNo { get; set; }
        public int? UserPaymentInformationNo { get; set; }
        public String UserImage { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
    }
}
