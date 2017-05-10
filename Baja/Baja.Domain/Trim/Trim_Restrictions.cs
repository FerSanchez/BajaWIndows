using Baja.Domain.Restriction;
using System.ComponentModel.DataAnnotations;

namespace Baja.Domain.Trim
{
    public class Trim_Restrictions
    {
        [Key]
        public int Id { get; set; }

        //FK
        public int TrimId { get; set; }
        public virtual Trim Trim { get; set; }

        //FK
        public int RestrictionsId { get; set; }
        public virtual Restrictions Restrictions { get; set; }

    }
}
