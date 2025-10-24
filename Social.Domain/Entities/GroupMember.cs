using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class GroupMember
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public bool IsAdmin { get; set; }

        public Group Group { get; set; }
        public User User { get; set; }




    }
}
