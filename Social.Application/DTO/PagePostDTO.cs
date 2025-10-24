using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class PagePostDTO
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public bool IsHidden { get; set; } = false;
        public bool IsApproved { get; set; } = false;

        public int PageId { get; set; }

        public int Status { get; set; } = 0;
    }
}
