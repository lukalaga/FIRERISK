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
        public DbSet<Auditor> Auditors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Rule> Rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}