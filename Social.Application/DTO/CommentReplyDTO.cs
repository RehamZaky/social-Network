using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class CommentReplyDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public int PostId { get; set; }

        public int? ParentCommentId { get; set; } = null;

        public CommentDTO ParentComment { get; set; }

        public string Image { get; set; }
    }
}
