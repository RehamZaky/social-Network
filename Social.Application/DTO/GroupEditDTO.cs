using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class GroupEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }

        public string CoverPhoto { get; set; } = string.Empty;
        public int CreatedBy { get; set; }

        public bool IsPublic { get; set; }
    }
}
