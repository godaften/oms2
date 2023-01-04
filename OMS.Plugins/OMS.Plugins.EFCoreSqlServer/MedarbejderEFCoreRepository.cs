using Microsoft.EntityFrameworkCore;
using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Plugins.EFCoreSqlServer;

public class MedarbejderEFCoreRepository : IMedarbejderRepository
{
    private readonly IDbContextFactory<OMSContext> contextFactory;

    public MedarbejderEFCoreRepository(IDbContextFactory<OMSContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task AddMedarbejderAsync(Medarbejder medarbejder)
    {
        using var db = this.contextFactory.CreateDbContext();

        db.Medarbejdere.Add(medarbejder);
        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Medarbejder>> GetMedarbejdereByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Medarbejdere.Where(
            x => x.Navn.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();
    }
}
