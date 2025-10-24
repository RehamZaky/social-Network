using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Info { get; set; }

        public string ProfilePic { get; set; }


        public int Type { get; set; } = 0;  // 1 admin , 0 user 
    }
}
