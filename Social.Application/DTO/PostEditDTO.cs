using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class PostEditDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Content { get; set; }
        public bool IsHidden { get; set; } 

        public string Media { get; set; }
    }
}
