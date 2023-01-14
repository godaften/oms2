﻿using Microsoft.EntityFrameworkCore;
using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
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

    public async Task AddKontorhusAsync(Kontorhus kontorhus)
    {
        using var db = this.contextFactory.CreateDbContext();
        db.Kontorhuse.Add(kontorhus);

        FlagLejereUnchanged(kontorhus, db);

        await db.SaveChangesAsync();
    }

    public async Task UpdateKontorhusAsync(Kontorhus kontorhus)
    {
        using var db = this.contextFactory.CreateDbContext();
        var khus = await db.Kontorhuse
            .Include(x => x.KontorhusLejere)
            .FirstOrDefaultAsync(x => x.KontorhusID == kontorhus.KontorhusID);

        if (khus != null)
        {
            khus.KontorhusNavn = kontorhus.KontorhusNavn;
            khus.KontorhusEmail = kontorhus.KontorhusEmail;
            khus.KontorhusLejere = kontorhus.KontorhusLejere;

            FlagLejereUnchanged(kontorhus, db);

            await db.SaveChangesAsync();
        }
    }


    public async Task<Kontorhus?> GetKontorhusById(int kontorhusId)
    {
        using var db = this.contextFactory.CreateDbContext();

        return await db.Kontorhuse.Include(x => x.KontorhusLejere)
            .ThenInclude(x => x.Lejer)
            .FirstOrDefaultAsync(x => x.KontorhusID == kontorhusId);
    }

    public async Task<IEnumerable<Kontorhus>> GetKontorhuseByNameAsync(string name)
    {
        using var db = this.contextFactory.CreateDbContext();
        return await db.Kontorhuse.Where(x => x.KontorhusNavn.ToLower().IndexOf(name) >= 0).ToListAsync();
    }


    public async Task DeleteKontorhusAsync(Kontorhus kontorhus)
    {
        using var db = this.contextFactory.CreateDbContext();
        var khus = await db.Kontorhuse.FindAsync(kontorhus.KontorhusID);
        if (khus != null)
        {
            db.Kontorhuse.Remove(khus);
        }

        await db.SaveChangesAsync();

    }

  
}
