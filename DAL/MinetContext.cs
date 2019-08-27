using FIRERISK.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FIRERISK.DAL
{
    public class MinetContext : DbContext
    {
        public MinetContext() : base("MinetContext")
        {

        }


        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Industry> Industrys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

          
        }
    }
}