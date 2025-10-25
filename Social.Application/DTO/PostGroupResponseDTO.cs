using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class PostGroupResponseDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int UserId { get; set; }
        public bool IsHidden { get; set; } = false;

        public string Media { get; set; }

        public ICollection<GroupPostDTO> GroupPosts { get; set; }

    }
}
