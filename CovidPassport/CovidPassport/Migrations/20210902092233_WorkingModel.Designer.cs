// <auto-generated />
using System;
using CovidPassport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CovidPassport.Migrations
{
    [DbContext(typeof(PassportTrackerContext))]
    [Migration("20210902092233_WorkingModel")]
    partial class WorkingModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CovidPassport.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CovidPassport.HealthCentre", b =>
                {
                    b.Property<int>("HealthCentreId")
                        .HasColumnType("int")
                        .HasColumnName("HealthCentreID");

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.HasKey("HealthCentreId");

                    b.HasIndex("AddressId");

                    b.ToTable("HealthCentre");
                });

            modelBuilder.Entity("CovidPassport.Passport", b =>
                {
                    b.Property<int>("PassportId")
                        .HasColumnType("int")
                        .HasColumnName("PassportID");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<int>("HealthCentreId")
                        .HasColumnType("int")
                        .HasColumnName("HealthCentreID");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PersonID");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.HasKey("PassportId");

                    b.HasIndex("HealthCentreId");

                    b.HasIndex("PersonId");

                    b.ToTable("Passport");
                });

            modelBuilder.Entity("CovidPassport.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .HasMaxLength(9)
                        .HasColumnType("int")
                        .HasColumnName("PersonID");

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NoOfVaccines")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("CovidPassport.HealthCentre", b =>
                {
                    b.HasOne("CovidPassport.Address", "Address")
                        .WithMany("HealthCentres")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK__HealthCen__Addre__2B3F6F97")
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CovidPassport.Passport", b =>
                {
                    b.HasOne("CovidPassport.HealthCentre", "HealthCentre")
                        .WithMany("Passports")
                        .HasForeignKey("HealthCentreId")
                        .HasConstraintName("FK__Passport__Health__2F10007B")
                        .IsRequired();

                    b.HasOne("CovidPassport.Person", "Person")
                        .WithMany("Passports")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("FK__Passport__Person__2E1BDC42")
                        .IsRequired();

                    b.Navigation("HealthCentre");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CovidPassport.Person", b =>
                {
                    b.HasOne("CovidPassport.Address", "Address")
                        .WithMany("People")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK__Person__AddressI__286302EC")
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CovidPassport.Address", b =>
                {
                    b.Navigation("HealthCentres");

                    b.Navigation("People");
                });

            modelBuilder.Entity("CovidPassport.HealthCentre", b =>
                {
                    b.Navigation("Passports");
                });

            modelBuilder.Entity("CovidPassport.Person", b =>
                {
                    b.Navigation("Passports");
                });
#pragma warning restore 612, 618
        }
    }
}
