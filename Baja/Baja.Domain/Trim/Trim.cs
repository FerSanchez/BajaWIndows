﻿using Baja.Domain.Fabric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Trim
{
    public class Trim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Trim_Restrictions> Trim_Restrictions { get; set; }
    }
}
