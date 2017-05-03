using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Fabric
{
    public class FabricRestriction
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Restriction")]
        public string Name { get; set; }

        public virtual ICollection<Fabric_Restriction> Fabric_Restrictions { get; set; }

    }
}
