using Microsoft.EntityFrameworkCore;
using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OMS.Plugins.EFCoreSqlServer;

public class KontorhusEFCoreRepository : IKontorhusRepository
{
    private readonly IDbContextFactory<OMSContext> contextFactory;

    public KontorhusEFCoreRepository(IDbContextFactory<OMSContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task AddKontorhusAsync(Kontorhus kontorhus)
    {
        //this.db.Kontorhuse.Add(kontorhus);
        //await this.db.SaveChangesAsync();
        using var db = this.contextFactory.CreateDbContext();
        db.Kontorhuse.Add(kontorhus);
        FlagLejereUnchanged(kontorhus, this.db);

        await this.db.SaveChangesAsync();
    }

 

    public async Task<Kontorhus?> GetKontorhusById(int kontorhusId)
    {
        using var db = this.contextFactory.CreateDbContext();
        // include og theninclude... tjek op på
        // Når vi finder det søgte kontorhus, vil vi også gerne se de relevante lejere
        return await db.Kontorhuse.Include(x => x.KontorhusLejere)
            .ThenInclude(x => x.Lejer)
            .FirstOrDefaultAsync(x => x.KontorhusID== kontorhusId);
    }



    public async Task<IEnumerable<Kontorhus>> GetKontorhuseByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();
        return await db.Kontorhuse.Where (x => x.KontorhusNavn.ToLower().IndexOf(name) >= 0).ToListAsync();
    }

    public async Task UpdateKontorhusAsync(Kontorhus kontorhus)
    {
        using var db = this.contextFactory.CreateDbContext();
        // Undgå forskellige kontorhuse med samme navn
        var khus = await db.Kontorhuse
            .Include(x => x.KontorhusLejere)
            .FirstOrDefaultAsync(x => x.KontorhusID == kontorhus.KontorhusID);

        if (khus != null)
        {
            khus.KontorhusNavn = kontorhus.KontorhusNavn;
            khus.KontorhusTelefon = kontorhus.KontorhusTelefon;
            khus.KontorhusEmail = kontorhus.KontorhusEmail;
            khus.KontorhusLejere = kontorhus.KontorhusLejere;
            FlagLejereUnchanged(kontorhus, this.db);

            await this.db.SaveChangesAsync();
        }
    }

    // EF kender ikke til lejerne her, og vil derfor betragte tilføjede lejere som nye,
    // selvom de findes i forvejen. Relevant ved samme lejer, der vil leje lokaler i flere kontorhuse.
    // Her fortæller vi EF at alle lejerne eksisterer allerede og der skal derfor ikke gøres noget med dem
    // Derfor laves nedenstående hjælpemetode
    private void FlagLejereUnchanged(Kontorhus kontorhus, OMSContext db)
    {
        if (kontorhus?.KontorhusLejere != null &&
                    kontorhus.KontorhusLejere.Count > 0)
        {

            foreach (var khusLej in kontorhus.KontorhusLejere)
            {
                if (khusLej.Lejer != null)
                    db.Entry(khusLej.Lejer).State = EntityState.Unchanged;

            }
        }
    }
}
