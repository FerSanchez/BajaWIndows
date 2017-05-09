using Baja.Domain.Fabric;
using Baja.Domain.Restriction;
using Baja.Domain.Trim;
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


        /// TRIM //
        public DbSet<Trim.Trim> Trims { get; set; }
        public DbSet<Trim_Restrictions> Trim_Restrictions { get; set; }


        /// Restrictions ///
        public DbSet<Restrictions> Restrictions { get; set; }



    }
}
