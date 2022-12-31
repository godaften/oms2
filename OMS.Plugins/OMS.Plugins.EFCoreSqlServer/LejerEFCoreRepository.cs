using Microsoft.EntityFrameworkCore;
using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System.Collections.Generic;

namespace OMS.Plugins.EFCoreSqlServer;

// Plugin er afhængig af Use Case -> clean architecture
public class LejerRepository : ILejerRepository
{
    private readonly OMSContext db;

    public LejerRepository(OMSContext db)
    {
        this.db = db;
    }

    public async Task AddLejerAsync(Lejer lejer)
    {
        this.db.Lejere.Add(lejer);

        await db.SaveChangesAsync();
    }



  
    public async Task<IEnumerable<Lejer>> GetLejereByNameAsync(string name)
    {

        // hvis der er 0 eller flere søgte lejere i db, laves de til liste med det samme
        return await this.db.Lejere.Where(
            x => x.Navn.ToLower().IndexOf(name.ToLower()) >= 0 ).ToListAsync();

    }

    public async Task<Lejer> GetLejerByIdAsync(int lejerId)
    {
        var lej = await this.db.Lejere.FindAsync(lejerId);
        if (lej != null) return lej;

        return new Lejer();

    }

    public async Task UpdateLejerAsync(Lejer lejer)
    {
        var lej = await this.db.Lejere.FindAsync(lejer.LejerID);
        if (lej != null)
        {
            lej.Navn = lejer.Navn;
            lej.Telefon= lejer.Telefon;
            lej.Email= lejer.Email;

            await db.SaveChangesAsync();
        }


    }
}