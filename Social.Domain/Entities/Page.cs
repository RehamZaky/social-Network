using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Page : Base
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public string CoverPhoto { get; set; }

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<PageMember> Members { get; set; }

        public ICollection<PagePosts> PagePosts { get; set; }

    }
}
