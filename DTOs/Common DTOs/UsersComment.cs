using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Common_DTOs
{
    public record UsersComment
    {
        public int Id { get; set; }
        public string? CommentText { get; set; }
        public int CommentReviewStars { get; set; }
        public int UserNo { get; set; }
        public CommentType commentType { get; set; }
        public int RefranceNumber { get; set; }
        public DateTime CommentCreatedDate { get; set; }
        public DateTime CommentModifiedDate { get; set; }


        public enum CommentType
        {
            CompanyComment,
            ProductComment,


        }

    }
}
