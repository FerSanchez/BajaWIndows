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


        //Puede ser List o IEnumerable\\
        [Required]
        [Display(Name = "Fabric")]
        public virtual ICollection<Fabric> Fabrics { get; set; }
    }
}
