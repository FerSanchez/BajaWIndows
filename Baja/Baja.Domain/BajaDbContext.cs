using Baja.Domain.Fabric;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Baja.Domain
{
    public class BajaDbContext : DbContext
    {
        /// FABRIC ///
        public DbSet<Fabric.Fabric> Frabrics {get; set;}
        public DbSet<FabricBook> FabricBooks { get; set; }
        public DbSet<FabricCategory> FabricCategories { get; set; }
        public DbSet<FabricRestriction> FabricRestrictions { get; set; }
        public DbSet<Fabric_Restriction> Fabric_Restrictions { get; set; }




    }
}
