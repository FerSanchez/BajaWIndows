using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Fabric
{
    public class FabricViewModel
    {
        public int FabricId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }


        public int FabricBookId { get; set; }
        public FabricBook FabricBooks { get; set; }


        public List<CheckBoxViewModel> Restrictions { get; set; }

    }
}
