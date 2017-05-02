using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Baja.Domain.Fabric
{
    public class FabricViewModel
    {
        public Fabric Fabric { get; set; }
        public IEnumerable<SelectListItem> AllRestriction { get; set; }
    }
}
