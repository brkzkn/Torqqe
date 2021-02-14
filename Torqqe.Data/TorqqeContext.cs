using Microsoft.EntityFrameworkCore;
using Torqqe.Data.Models;

namespace Torqqe.Data
{
    public class TorqqeContext : DbContext
    {
        public TorqqeContext()
        {
        }

        public TorqqeContext(DbContextOptions<TorqqeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Labor> Labors { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Subcontract> Subcontracts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Total> Totals { get; set; }
        public virtual DbSet<VehicleOwner> VehicleOwners { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<UpdateInfo> UpdateInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ShopmonkeyId);

                entity.Property(e => e.ShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(4);

                entity.Property(e => e.Zip).HasMaxLength(10);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.CustomerShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.CustomerShopmonkeyId)
                    .HasConstraintName("FK_Emails_Customers");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.ShopmonkeyId);

                entity.Property(e => e.ShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Discount).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.EpaValueType).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.OrderShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.ShopSuppliesValueType).HasMaxLength(50);

                entity.Property(e => e.Taxes).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.TaxesValueType).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.OrderShopmonkeyId)
                    .HasConstraintName("FK_Jobs_Orders");

                entity.HasOne(d => d.Total)
                    .WithOne(p => p.Job)
                    .HasForeignKey<Job>(d => d.ShopmonkeyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jobs_Totals");
            });

            modelBuilder.Entity<Labor>(entity =>
            {
                entity.HasKey(e => e.ShopmonkeyId);

                entity.Property(e => e.ShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Discount).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.DiscountValueType).HasMaxLength(50);

                entity.Property(e => e.JobShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Labors)
                    .HasForeignKey(d => d.JobShopmonkeyId)
                    .HasConstraintName("FK_Labors_Jobs");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.ShopmonkeyId);

                entity.Property(e => e.ShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.AuthorizedDate).HasColumnType("datetime");

                entity.Property(e => e.Complaint).HasMaxLength(4000);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.InvoicedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.PaidAmount).HasColumnType("money");

                entity.Property(e => e.PublicId).HasMaxLength(50);

                entity.Property(e => e.TechRecommendation).HasMaxLength(500);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.VehicleShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Workflow).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerShopmonkeyId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VehicleShopmonkeyId)
                    .HasConstraintName("FK_Orders_Vehicles");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasKey(e => e.ShopmonkeyId);

                entity.Property(e => e.ShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Discount).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.DiscountValueType).HasMaxLength(50);

                entity.Property(e => e.JobShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.RetailCost).HasColumnType("money");

                entity.Property(e => e.WholesaleCost).HasColumnType("money");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.JobShopmonkeyId)
                    .HasConstraintName("FK_Parts_Jobs");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.CustomerShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Phones)
                    .HasColumnName("Phones")
                    .HasMaxLength(25);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.CustomerShopmonkeyId)
                    .HasConstraintName("FK_Phones_Customers");
            });

            modelBuilder.Entity<Subcontract>(entity =>
            {
                entity.HasKey(e => e.ShopmonkeyId);

                entity.Property(e => e.ShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Discount).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.DiscountValueType).HasMaxLength(50);

                entity.Property(e => e.JobShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(4000);

                entity.Property(e => e.RetailCost).HasColumnType("money");

                entity.Property(e => e.WholesaleCost).HasColumnType("money");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Subcontracts)
                    .HasForeignKey(d => d.JobShopmonkeyId)
                    .HasConstraintName("FK_Subcontracts_Jobs");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OrderShopmonkeyId).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.OrderShopmonkeyId)
                    .HasConstraintName("FK_Tags_Orders");
            });

            modelBuilder.Entity<Total>(entity =>
            {
                entity.HasKey(e => e.JobShopmonkeyId);

                entity.Property(e => e.JobShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.DiscountTotal).HasColumnType("money");

                entity.Property(e => e.DiscountTotalPercent).HasColumnType("money");

                entity.Property(e => e.EpaTotal).HasColumnType("money");

                entity.Property(e => e.FeesSubtotal).HasColumnType("money");

                entity.Property(e => e.FeesSubtotalWithoutDiscount).HasColumnType("money");

                entity.Property(e => e.GstTotal).HasColumnType("money");

                entity.Property(e => e.HstTotal).HasColumnType("money");

                entity.Property(e => e.JobDiscountTotal).HasColumnType("money");

                entity.Property(e => e.LaborsSubtotal).HasColumnType("money");

                entity.Property(e => e.LaborsSubtotalWithoutDiscount).HasColumnType("money");

                entity.Property(e => e.LaborsTotalTaxable).HasColumnType("money");

                entity.Property(e => e.PartsSubtotal).HasColumnType("money");

                entity.Property(e => e.PartsSubtotalWithoutDiscount).HasColumnType("money");

                entity.Property(e => e.PartsWholesaleSubtotal).HasColumnType("money");

                entity.Property(e => e.PstTotal).HasColumnType("money");

                entity.Property(e => e.ShopSuppliesTotal).HasColumnType("money");

                entity.Property(e => e.SubcontractsSubtotal).HasColumnType("money");

                entity.Property(e => e.SubcontractsSubtotalWithoutDiscount).HasColumnType("money");

                entity.Property(e => e.SubcontractsTotalTaxable).HasColumnType("money");

                entity.Property(e => e.SubcontractsWholesaleSubtotal).HasColumnType("money");

                entity.Property(e => e.Subtotal).HasColumnType("money");

                entity.Property(e => e.TaxesTotal).HasColumnType("money");

                entity.Property(e => e.TiresSubtotal).HasColumnType("money");

                entity.Property(e => e.TiresSubtotalWithoutDiscount).HasColumnType("money");

                entity.Property(e => e.TiresTotalTaxable).HasColumnType("money");

                entity.Property(e => e.TiresWholesaleSubtotal).HasColumnType("money");

                entity.Property(e => e.TotalPrice).HasColumnName("Total").HasColumnType("money");
            });

            modelBuilder.Entity<VehicleOwner>(entity =>
            {
                entity.HasKey(e => new { e.VehicleShopmonkeyId, e.CustomerShopmonkeyId });

                entity.Property(e => e.VehicleShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.CustomerShopmonkeyId).HasMaxLength(50);

                entity.HasOne(d => d.CustomerShopmonkey)
                    .WithMany(p => p.VehicleOwners)
                    .HasForeignKey(d => d.CustomerShopmonkeyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleOwners_Customers");

                entity.HasOne(d => d.VehicleShopmonkey)
                    .WithMany(p => p.VehicleOwners)
                    .HasForeignKey(d => d.VehicleShopmonkeyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleOwners_Vehicles");
            });

            modelBuilder.Entity<UpdateInfo>(entity =>
            {
                entity.HasKey(p => p.TableName);

                entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.ShopmonkeyId);

                entity.Property(e => e.ShopmonkeyId).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.DriveTrain).HasMaxLength(50);

                entity.Property(e => e.EngineSize).HasMaxLength(50);

                entity.Property(e => e.LicensePlate).HasMaxLength(50);

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Submodel).HasMaxLength(50);

                entity.Property(e => e.Transmission).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(25);

                entity.Property(e => e.UnitNumber).HasMaxLength(50);

                entity.Property(e => e.Vin).HasMaxLength(50);
            });
        }
    }
}
