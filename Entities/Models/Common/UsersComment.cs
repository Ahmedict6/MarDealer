using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Common
{
    public class UsersComment
    {
        [Key]
        public int Id { get; set; }
        public string? CommentText { get; set; }
        public int CommentReviewStars { get; set; }
        public int UserNo { get; set; }
        public CommentType CommentType { get; set; }
        public int RefranceNumber { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
        public DateTime CommentCreatedDate { get; set; }
        public DateTime CommentModifiedDate { get; set; }

    }

    public enum CommentType
    {
        CompanyComment,
        ProductComment,


    }

}
