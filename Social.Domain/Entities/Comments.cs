using Social.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Comment : Base
    {
        public string Content { get; set; }

        public int UserId { get; set; }
        public int PostId { get; set; }
        public int? ParentCommentId { get; set; }  // Foreign key


        public User User { get; set; }
        public Posts Post { get; set; }
        public Comment ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set;}

        public bool IsHidden { get; set; }
        public bool IsActive { get; set; } = true;

        public string Image { get; set; }

        // TODO: add media
    }
}
