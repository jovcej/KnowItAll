using KnowItAll.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowItAll.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Material_Offer> Material_Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material_Offer>()
                .HasOne(b => b.Material)
                .WithMany(ba => ba.MaterialOffers)
                .HasForeignKey(bi => bi.MaterialId);

            modelBuilder.Entity<Material_Offer>()
                .HasOne(b => b.Offer)
                .WithMany(ba => ba.MaterialOffers)
                .HasForeignKey(bi => bi.OfferId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
