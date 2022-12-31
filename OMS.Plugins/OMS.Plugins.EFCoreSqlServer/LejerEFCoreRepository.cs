using Microsoft.EntityFrameworkCore;
using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System.Collections.Generic;

namespace OMS.Plugins.EFCoreSqlServer;

// Plugin er afhængig af Use Case -> clean architecture
public class LejerEFCoreRepository : ILejerRepository
{
    private readonly IDbContextFactory<OMSContext> contextFactory;

    //private readonly OMSContext db;


    //public LejerEFCoreRepository(OMSContext db)
    //{
    //    this.db = db;
    //}

    public LejerEFCoreRepository(IDbContextFactory<OMSContext> contextFactory)
    {
       
        this.contextFactory = contextFactory;
    }

    public async Task AddLejerAsync(Lejer lejer)
    {
        // vi bruger laver en dbcontext, som slettes når scope er slut, som er ved slutningen af metoden
        using var db = this.contextFactory.CreateDbContext();
        //this.db.Lejere.Add(lejer);
        db.Lejere.Add(lejer);
        await db.SaveChangesAsync();
    }



  
    public async Task<IEnumerable<Lejer>> GetLejereByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();
        // hvis der er 0 eller flere søgte lejere i db, laves de til liste med det samme
        return await db.Lejere.Where(
            x => x.Navn.ToLower().IndexOf(name.ToLower()) >= 0 ).ToListAsync();

    }

    public async Task<Lejer> GetLejerByIdAsync(int lejerId)
    {
        using var db = this.contextFactory.CreateDbContext();
        var lej = await db.Lejere.FindAsync(lejerId);
        if (lej != null) return lej;

        return new Lejer();

    }

    public async Task UpdateLejerAsync(Lejer lejer)
    {
        using var db = this.contextFactory.CreateDbContext();
        var lej = await db.Lejere.FindAsync(lejer.LejerID);
        if (lej != null)
        {
            lej.Navn = lejer.Navn;
            lej.Telefon= lejer.Telefon;
            lej.Email= lejer.Email;

            await db.SaveChangesAsync();
        }


    }
}