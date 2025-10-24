using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Media : Base
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public int Type { get; set; }


    }
}
