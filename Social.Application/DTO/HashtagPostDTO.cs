using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class HashtagPostDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Content { get; set; }

        public List<UpdateHashtagDto> Hashtags { get; set; } = new List<UpdateHashtagDto>();
    }
}
