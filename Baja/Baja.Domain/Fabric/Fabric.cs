using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        [Display(Name = "Fabric Book")]
        public int FabricBookId { get; set; }
        public FabricBook FabricBooks { get; set; }


        /// ///////////////////////////////////////////////

        public virtual ICollection<FabricOnRestriction> FabricOnRestrictions { get; set; }

        //////////////////////////////////////////////////

        //Intento\\      
        public FabricRestriction FabricRestriction { get; set; }

        public ICollection<int>[] SelectedRestrictionList { get; set; }
        //Puede ser List o IEnumerable\\
        

       
        
    }
}
