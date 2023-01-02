﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OMS.Plugins.EFCoreSqlServer;

#nullable disable

namespace OMS.Plugins.EFCoreSqlServer.Migrations
{
    [DbContext(typeof(OMSContext))]
    [Migration("20230102142907_added adresse to lejer")]
    partial class addedadressetolejer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OMS.CoreBusiness.Kontorhus", b =>
                {
                    b.Property<int>("KontorhusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KontorhusID"));

                    b.Property<string>("KontorhusEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontorhusNavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontorhusTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KontorhusID");

                    b.ToTable("Kontorhuse");

                    b.HasData(
                        new
                        {
                            KontorhusID = 1,
                            KontorhusEmail = "johnny@mail.dk",
                            KontorhusNavn = "BusinessHouse",
                            KontorhusTelefon = "12141516"
                        },
                        new
                        {
                            KontorhusID = 2,
                            KontorhusEmail = "johnny@mail.dk",
                            KontorhusNavn = "HappyHouse",
                            KontorhusTelefon = "33341516"
                        });
                });

            modelBuilder.Entity("OMS.CoreBusiness.KontorhusLejer", b =>
                {
                    b.Property<int>("KontorhusID")
                        .HasColumnType("int");

                    b.Property<int>("LejerID")
                        .HasColumnType("int");

                    b.HasKey("KontorhusID", "LejerID");

                    b.HasIndex("LejerID");

                    b.ToTable("KontorhusLejere");

                    b.HasData(
                        new
                        {
                            KontorhusID = 1,
                            LejerID = 1
                        },
                        new
                        {
                            KontorhusID = 1,
                            LejerID = 2
                        });
                });

            modelBuilder.Entity("OMS.CoreBusiness.Lejer", b =>
                {
                    b.Property<int>("LejerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LejerID"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LejerID");

                    b.ToTable("Lejere");

                    b.HasData(
                        new
                        {
                            LejerID = 1,
                            Email = "minmail1@email.dk",
                            Navn = "Askov",
                            Telefon = "12131415"
                        },
                        new
                        {
                            LejerID = 2,
                            Email = "minmail2@email.dk",
                            Navn = "Transportfirmaet",
                            Telefon = "23242526"
                        },
                        new
                        {
                            LejerID = 3,
                            Email = "minmail3@email.dk",
                            Navn = "Tolkemanden",
                            Telefon = "34353637"
                        },
                        new
                        {
                            LejerID = 4,
                            Email = "minmail14@email.dk",
                            Navn = "Larsen",
                            Telefon = "4531415"
                        },
                        new
                        {
                            LejerID = 5,
                            Email = "minmail5@email.dk",
                            Navn = "Petersen Business A/S",
                            Telefon = "53242526"
                        },
                        new
                        {
                            LejerID = 6,
                            Email = "minmail6@email.dk",
                            Navn = "Jensens Super Service ApS",
                            Telefon = "64353637"
                        });
                });

            modelBuilder.Entity("OMS.CoreBusiness.Medarbejder", b =>
                {
                    b.Property<int>("MedarbejderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedarbejderID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedarbejderID");

                    b.ToTable("Medarbejdere");

                    b.HasData(
                        new
                        {
                            MedarbejderID = 1,
                            Email = "lars@test.dk",
                            Navn = "Lars",
                            Telefon = "12131415"
                        },
                        new
                        {
                            MedarbejderID = 2,
                            Email = "kurt@test.dk",
                            Navn = "Kurt",
                            Telefon = "13131415"
                        },
                        new
                        {
                            MedarbejderID = 3,
                            Email = "hans@test.dk",
                            Navn = "Hans",
                            Telefon = "14131415"
                        });
                });

            modelBuilder.Entity("OMS.CoreBusiness.KontorhusLejer", b =>
                {
                    b.HasOne("OMS.CoreBusiness.Kontorhus", "Kontorhus")
                        .WithMany("KontorhusLejere")
                        .HasForeignKey("KontorhusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OMS.CoreBusiness.Lejer", "Lejer")
                        .WithMany("KontorhusLejere")
                        .HasForeignKey("LejerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kontorhus");

                    b.Navigation("Lejer");
                });

            modelBuilder.Entity("OMS.CoreBusiness.Kontorhus", b =>
                {
                    b.Navigation("KontorhusLejere");
                });

            modelBuilder.Entity("OMS.CoreBusiness.Lejer", b =>
                {
                    b.Navigation("KontorhusLejere");
                });
#pragma warning restore 612, 618
        }
    }
}