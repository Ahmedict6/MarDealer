using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.User_Management
{
    public class UserOrderAddress
    {
        [Key]
        public int Id { get; set; }
        public int UserNo{ get; set; }
        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public DateTime UserModifiedDate { get; set; }
    }
}
