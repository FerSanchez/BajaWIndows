using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Fabric
{
    public class FabricOnRestriction
    {
        public int Id { get; set; }

        //FK
        public int FabricId { get; set; }
        public Fabric Fabrics { get; set; }

        //FK
        public int FabricRestrictionId { get; set; }
        public FabricRestriction FabricRestrictions { get; set; }
    }
}
