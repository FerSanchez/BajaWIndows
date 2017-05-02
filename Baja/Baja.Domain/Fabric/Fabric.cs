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
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [Display(Name = "Fabric Category")]
        public int FabricBookId { get; set; }
        public FabricBook FabricBooks { get; set; }

        [Display(Name = "Fabric Restriction")]
        public int FabricRestrictionId { get; set; }
        public FabricRestriction FabricRestrictions { get; set; }
    }
}
