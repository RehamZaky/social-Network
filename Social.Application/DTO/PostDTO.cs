using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class PostDTO
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public bool IsHidden { get; set; } = false;

        public string Media { get; set; }
    }
}
