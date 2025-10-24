using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Info { get; set; }

        public string ProfilePic { get; set; }

        public int Type { get; set; } = 1;  // 0 admin , 1 user 

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
