using Entities.Models.Product_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.User_Management
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Mobile { get; set; }
        public string? FullName { get; set; }
        public int UserTypeNo { get; set; }
        [ForeignKey("UserTypeNo")]
        public virtual UserType UserType { get; set; }
        public int UserInformationNo { get; set; }
        public int? UserPaymentInformationNo { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
    }
}
