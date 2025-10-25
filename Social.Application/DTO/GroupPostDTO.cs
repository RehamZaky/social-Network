using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class GroupPostDTO
    {
        public int GroupId { get; set; }
        public int PostId { get; set; }

        public int Status { get; set; }  // Enum
        public bool IsApproved { get; set; }
    }
}
