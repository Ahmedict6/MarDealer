using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTOs.Common_DTOs.CommonEnums;

namespace DTOs.Common_DTOs
{
    public record UsersCommentDTO
    {
        public int Id { get; set; }
        public string? CommentText { get; set; }
        public int CommentReviewStars { get; set; }
        public int UserNo { get; set; }
        public CommentTypeDTO commentType { get; set; }
        public int RefranceNumber { get; set; }
        public DateTime CommentCreatedDate { get; set; }
        public DateTime CommentModifiedDate { get; set; }


       

    }

    public enum CommentTypeDTO
    {
        CompanyComment,
        ProductComment,


    }

}
