using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class PostInteractionDTO
    {
        public int PostId { get; set; }

        public int InteractionType { get; set; }

        public int UserId { get; set; }
    }
}
