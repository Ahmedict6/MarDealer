using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.User_Management
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string? UserTypeName { get; set; }
        public string? UserTypeDescritpion { get; set; }
        public DateTime UserTypeCreatedDate { get; set; }
        public DateTime UserTypeModifiedDate { get; set; }
    }
}
