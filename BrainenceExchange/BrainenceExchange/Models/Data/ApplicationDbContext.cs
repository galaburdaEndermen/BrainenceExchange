using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            EnsurePopulated();
        }

        private void EnsurePopulated()
        {

        }

        public DbSet<ExchangeEntry> ExchangeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.HasPostgresExtension("uuid-ossp");

            //mb.Entity<ExchangeEntry>().Property(entry => entry.Date).HasColumnType("date");         
            mb.Entity<ExchangeEntry>().Property(entry => entry.Id).HasDefaultValueSql("uuid_generate_v4()");
        }
    }
}
