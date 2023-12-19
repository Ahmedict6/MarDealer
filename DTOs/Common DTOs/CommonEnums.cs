using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Common_DTOs
{
    public record CommonEnums
    {

        public enum LookupType
        {
            PaymentType,
            UserType
        }

        public enum UserType
        {
            Exporter=1,
            Customer,
            Dealer,
            Factory
        }

        public enum DocumentItemType
        {
            UserProfileImage,
            ProductImage,


        }
    }
}
