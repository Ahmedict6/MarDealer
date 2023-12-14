using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record UserTypeDTO
    {
        public int Id { get; set; }
        public string? UserTypeName { get; set; }
        public string? UserTypeDescritpion { get; set; }
        public DateTime UserTypeCreatedDate { get; set; }
        public DateTime UserTypeModifiedDate { get; set; }
    }
}
