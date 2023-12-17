using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.User_DTOs
{
    public record LoginDTO
    {
        public string? Mobile { get; set; }
        public string? Password { get; set; }
    }
}
