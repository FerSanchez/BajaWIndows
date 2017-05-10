using Baja.Domain.Trim;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Baja.Domain.Restriction
{
    public class Restrictions
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        //Listas
        public virtual ICollection<Trim_Restrictions> Trim_Restrictions { get; set; }
    }
}
