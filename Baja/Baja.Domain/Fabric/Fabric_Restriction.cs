using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Fabric
{
    public class Fabric_Restriction
    {
        public int Id { get; set; }

        //FK
        public int FabricId { get; set; }
        public virtual Fabric Fabric { get; set; }

        //FK
        public int FabricRestrictionId { get; set; }
        public virtual FabricRestriction FabricRestriction { get; set; }
    }
}
