
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record UserPaymentInformationDTO
    {
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string? Provider { get; set; }
        public string? AccountNumber { get; set; }
        public string? Expiry { get; set; }
        public int PyamentType { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
    }
}
