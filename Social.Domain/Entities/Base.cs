﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
