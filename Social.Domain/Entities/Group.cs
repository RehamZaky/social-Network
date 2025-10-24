using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Group :Base
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public int CreatedBy { get; set; }

        public string CoverPhoto { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsPublic { get; set; }

        public ICollection<GroupMember> GroupMembers { get; set; } 

        public ICollection<GroupPosts> GroupPosts { get; set; }
    }
}
