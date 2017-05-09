using Baja.Domain.Restriction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
