using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class HashtagDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateHashtagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

    }


}
