using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baja.Domain.Fabric
{
    public class Fabric
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [Display(Name = "Fabric Book")]
        public int FabricBookId { get; set; }
        public FabricBook FabricBooks { get; set; }


        public virtual ICollection<Fabric_Restriction> Fabric_Restrictions { get; set; }
        
    }
}
