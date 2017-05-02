using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Fabric
{
    public class Fabric
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }


        public int FabricBookId { get; set; }
        public FabricBook FabricBooks { get; set; }

        public int FabricRestrictionId { get; set; }
        public FabricRestriction FabricRestrictions { get; set; }
    }
}
