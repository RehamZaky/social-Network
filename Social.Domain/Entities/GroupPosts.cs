using Social.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class GroupPosts
    {
        public int GroupId { get; set; }
        public int PostId { get; set; }

        public int Status { get; set; }  // Enum
        public bool IsApproved { get; set; }

        public Group Group { get; set; }

        public Posts Posts { get; set; }
    }
}
