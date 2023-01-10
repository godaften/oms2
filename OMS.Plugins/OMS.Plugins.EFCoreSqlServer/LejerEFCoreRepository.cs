using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System.Collections.Generic;
using System.Numerics;

namespace OMS.Plugins.EFCoreSqlServer;


public class LejerEFCoreRepository : ILejerRepository
{
    private readonly IDbContextFactory<OMSContext> contextFactory;

    public LejerEFCoreRepository(IDbContextFactory<OMSContext> contextFactory)
    {

        this.contextFactory = contextFactory;
    }

    public async Task AddLejerAsync(Lejer lejer)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Lejere.Add(lejer);
        await db.SaveChangesAsync();
    }


    public async Task<IEnumerable<Lejer>> GetLejereByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Lejere.Where(
            x => x.Navn.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();

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
        db.Lejere.Update(lejer);

        await db.SaveChangesAsync();
    }


    public async Task DeleteLejerAsync(Lejer lejer)
    {
        using var db = this.contextFactory.CreateDbContext();
        var lej = await db.Lejere.FindAsync(lejer.LejerID);
        if (lej != null)
        {
            db.Lejere.Remove(lej);
        }
      
        await db.SaveChangesAsync();
        
    }
}