using Microsoft.EntityFrameworkCore;
using PetshopApp2019.Core.Entity;

namespace PetshopApp2019.Infrastructure.SQLData
{
    public class PetshopContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public PetshopContext(DbContextOptions<PetshopContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(e => e.PreviousOwner)
                .WithMany(c => c.Pets);
            modelBuilder.Entity<Owner>()
               .Ignore(e => e.Pets);


        }

    }
}
