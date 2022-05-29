using FinalAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalAPI.DbContexts
{
    public class Database: DbContext
    {
        public Database(DbContextOptions<Database> options): base(options)
        {

        }

        public virtual DbSet<User> Users { get; set;} = null!;
        public virtual DbSet<Apartament> Apartamentes { get; set;} = null!;
        public virtual DbSet<Apartament_User> Apartaments_Users {get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartament_User>()
                .HasOne(e => e.Locatar)
                .WithOne()
                .HasForeignKey<Apartament_User>(e => e.ID_User)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Apartament_User>()
                .HasOne(e => e.Apartament)
                .WithOne()
                .HasForeignKey<Apartament_User>(e => e.ID_Apartament)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
