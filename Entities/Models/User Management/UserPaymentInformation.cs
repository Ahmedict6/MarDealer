using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.User_Management
{
    public class UserPaymentInformation
    {
        [Key]
        public int Id { get; set; }
        public int UserNo { get; set; }
        public string? Provider { get; set; }
        public string? AccountNumber { get; set; }
        public string? Expiry { get; set; }
        public string? CVV { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
    }
}
