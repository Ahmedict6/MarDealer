using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Common
{
    public class LookupData
    {
        public int Id { get; set; }
        public string? LookupValue { get; set; }
        public string? LookupName { get; set; }
        public string? LookupDescription { get; set; }
        public string? LookupType { get; set; }
        public bool IsActive { get; set; }
        public DateTime LookupCreatedDate { get; set; }
        public DateTime LookupModifiedDate { get; set; }

    }

}
