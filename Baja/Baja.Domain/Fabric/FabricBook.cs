using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja.Domain.Fabric
{
    public class FabricBook
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Book")]
        public string Name { get; set; }


        public int FabricCategoryId { get; set; }
        public FabricCategory FabricCategories { get; set; }
    }
}
