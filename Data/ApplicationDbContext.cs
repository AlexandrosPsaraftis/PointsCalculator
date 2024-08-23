using Microsoft.EntityFrameworkCore;

namespace Army_Creator_App.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Miniature> Miniatures { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<MeleeWeapon> MeleeWeapons { get; set; }
        public DbSet<RangedWeapon> RangedWeapons { get; set; }
        public DbSet<MiniatureWeapon> MiniatureWeapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary key for MiniatureWeapon
            modelBuilder.Entity<MiniatureWeapon>()
                .HasKey(mw => new { mw.MiniatureId, mw.WeaponId });

            // Relationships for MiniatureWeapon
            modelBuilder.Entity<MiniatureWeapon>()
                .HasOne(mw => mw.Miniature)
                .WithMany(m => m.MiniatureWeapons)
                .HasForeignKey(mw => mw.MiniatureId);

            modelBuilder.Entity<MiniatureWeapon>()
                .HasOne(mw => mw.Weapon)
                .WithMany(w => w.MiniatureWeapons)
                .HasForeignKey(mw => mw.WeaponId);

            // Inheritance mapping with discriminator
            modelBuilder.Entity<Weapon>()
                .HasDiscriminator<string>("WeaponType")
                .HasValue<MeleeWeapon>("MeleeWeapon")
                .HasValue<RangedWeapon>("RangedWeapon");
        }
    }
}
