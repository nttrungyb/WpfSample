using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample1.Data.Models;

namespace WpfSample1.Data
{
    public class SampleDbContext: DbContext
    {
        public DbSet<SeaFood> SeaFoods { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SeaFood>().ToTable("haisan");
            modelBuilder.Entity<SeaFood>().HasKey(x => new { x.Ma });

        }
    }
}
