using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record ChangePasswordDTO
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
      
    }
}
