using Baja.Domain.Fabric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Trim
{
    public class TrimViewModel
    {
        public int TrimId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }


        public List<CheckBoxViewModel> Restrictions { get; set; }

    }
}
