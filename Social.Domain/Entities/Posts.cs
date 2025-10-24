
using Social.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social.Domain.Data
{
    public class Posts : Base
    {
        public string Content { get; set; }
        public int userId { get; set; }

        [ForeignKey("userId")]
        public User Users { get; set; }

     //   public IdentityUser user { get; set; }
        public bool IsHidden { get; set; } = false;

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Hashtag> Hashtags { get; set; }

        public ICollection<PostInteraction> PostInteractions { get; set; }

        public ICollection<GroupPosts> GroupPosts { get; set; }

        public ICollection<PagePosts> PagePosts { get; set; }


    }
}
