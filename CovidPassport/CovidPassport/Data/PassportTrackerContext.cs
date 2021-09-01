using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CovidPassport
{
    public partial class PassportTrackerContext : DbContext
    {
        public PassportTrackerContext()
        {
        }

        public PassportTrackerContext(DbContextOptions<PassportTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<HealthCentre> HealthCentres { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PassportTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("AddressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HealthCentre>(entity =>
            {
                entity.ToTable("HealthCentre");

                entity.Property(e => e.HealthCentreId)
                    .ValueGeneratedNever()
                    .HasColumnName("HealthCentreID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.HealthCentres)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthCen__Addre__2B3F6F97");
            });

            modelBuilder.Entity<Passport>(entity =>
            {
                entity.ToTable("Passport");

                entity.Property(e => e.PassportId)
                    .ValueGeneratedNever()
                    .HasColumnName("PassportID");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.HealthCentreId).HasColumnName("HealthCentreID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.HealthCentre)
                    .WithMany(p => p.Passports)
                    .HasForeignKey(d => d.HealthCentreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Passport__Health__2F10007B");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Passports)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Passport__Person__2E1BDC42");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfVaccines)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Person__AddressI__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
