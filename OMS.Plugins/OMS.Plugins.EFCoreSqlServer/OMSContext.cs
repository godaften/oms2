using Microsoft.EntityFrameworkCore;
using OMS.CoreBusiness;

namespace OMS.Plugins.EFCoreSqlServer;

public class OMSContext : DbContext
{
    public OMSContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Lejer> Lejere { get; set; }
    public DbSet<Kontorhus> Kontorhuse { get; set; }
    public DbSet<KontorhusLejer> KontorhusLejere { get; set; }
    public DbSet<Medarbejder> Medarbejdere { get; set; }

    // Seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KontorhusLejer>()
    .HasKey(pi => new { pi.KontorhusID, pi.LejerID });

        modelBuilder.Entity<KontorhusLejer>()
            .HasOne(pi => pi.Kontorhus)
            .WithMany(p => p.KontorhusLejere)
            .HasForeignKey(pi => pi.KontorhusID);

        modelBuilder.Entity<KontorhusLejer>()
            .HasOne(pi => pi.Lejer)
            .WithMany(i => i.KontorhusLejere)
            .HasForeignKey(pi => pi.LejerID);


        modelBuilder.Entity<Lejer>().HasData(

        new Lejer { LejerID = 1, Navn = "Askov", Telefon = "12131415", Email = "minmail1@email.dk" },
        new Lejer { LejerID = 2, Navn = "Transportfirmaet", Telefon = "23242526", Email = "minmail2@email.dk" },
        new Lejer { LejerID = 3, Navn = "Tolkemanden", Telefon = "34353637", Email = "minmail3@email.dk" },
        new Lejer { LejerID = 4, Navn = "Larsen", Telefon = "4531415", Email = "minmail14@email.dk" },
        new Lejer { LejerID = 5, Navn = "Petersen Business A/S", Telefon = "53242526", Email = "minmail5@email.dk" },
        new Lejer { LejerID = 6, Navn = "Jensens Super Service ApS", Telefon = "64353637", Email = "minmail6@email.dk" }

        );

        modelBuilder.Entity<Kontorhus>().HasData(
        new Kontorhus()
        {
            KontorhusID = 1,
            KontorhusNavn = "BusinessHouse",
            KontorhusTelefon = "12141516",
            KontorhusEmail = "johnny@mail.dk"
        },

        new Kontorhus()
        {
            KontorhusID = 2,
            KontorhusNavn = "HappyHouse",
            KontorhusTelefon = "33341516",
            KontorhusEmail = "johnny@mail.dk"
        }
    );

        modelBuilder.Entity<KontorhusLejer>().HasData(

               new KontorhusLejer { KontorhusID = 1, LejerID = 1 },
               new KontorhusLejer { KontorhusID = 1, LejerID = 2 }

               );

        modelBuilder.Entity<Medarbejder>().HasData(
              new Medarbejder()
              {
                  MedarbejderID = 1,
                  Navn = "Lars",
                  Telefon = "12131415",
                  Email = "lars@test.dk"
              },

             new Medarbejder()
             {
                 MedarbejderID = 2,
                 Navn = "Kurt",
                 Telefon = "13131415",
                 Email = "kurt@test.dk"
             },

             new Medarbejder()
             {
                 MedarbejderID = 3,
                 Navn = "Hans",
                 Telefon = "14131415",
                 Email = "hans@test.dk"
             }
             );
    }




}