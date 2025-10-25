using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class CreatePostGroupDTO
    {

        public int GroupId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
    }
}
