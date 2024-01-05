﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class Color:BaseNameableEntity
    {
        public int Id { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set; }
    }
}
