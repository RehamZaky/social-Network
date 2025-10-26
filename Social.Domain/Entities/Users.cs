using Social.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Info { get; set; }

        public string ProfilePic { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Posts> Posts { get; set; }

        public ICollection<PostInteraction> PostInteraction { get; set; }

        public ICollection<PageMember> pageMembers { get; set; }

        public ICollection<GroupMember> groupMembers { get; set; }

        public ICollection<Hashtag> hashtags { get; set; }  

        public ICollection<Friend> Friends { get; set; }
        public ICollection<Friend> FriendsOfUser { get; set; }

        public int Type {  get; set; } // Enum admin ,user
    }
}
