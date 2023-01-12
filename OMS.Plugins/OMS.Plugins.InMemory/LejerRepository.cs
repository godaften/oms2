using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System.Collections.Generic;

namespace OMS.Plugins.InMemory;

public class LejerRepository : ILejerRepository
{
    private List<Lejer> _lejere;

    public LejerRepository()
    {
        _lejere = new List<Lejer>()
        {
            new Lejer { LejerID = 1, Navn = "Askov", Telefon ="12131415", Email ="minmail1@email.dk" },
            new Lejer { LejerID = 2, Navn = "Transportfirmaet", Telefon="23242526", Email ="minmail2@email.dk" },
            new Lejer { LejerID = 3, Navn = "Tolkemanden", Telefon="34353637", Email ="minmail3@email.dk" },
            new Lejer { LejerID = 4, Navn = "Larsen", Telefon ="4531415", Email ="minmail14@email.dk" },
            new Lejer { LejerID = 5, Navn = "Petersen Business A/S", Telefon="53242526", Email ="minmail5@email.dk" },
            new Lejer { LejerID = 6, Navn = "Jensens Super Service ApS", Telefon="64353637", Email ="minmail6@email.dk" }
        };

    }

    public Task AddLejerAsync(Lejer lejer)
    {
        if (_lejere.Any(x => x.Navn.Equals(lejer.Navn, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        _lejere.Add(lejer);

        var maxId = _lejere.Max(x => x.LejerID);
        lejer.LejerID = maxId + 1;

        return Task.CompletedTask;
    }


    public Task DeleteLejerAsync(Lejer lejer)
    {
        var lej = _lejere.FirstOrDefault(x => x.LejerID == lejer.LejerID);

       // using var db = this.contextFactory.CreateDbContext();
        //var lej = await db.Lejere.FindAsync(lejer.LejerID);
       
        if (lej != null)
        {
            _lejere.Remove(lej);
        }


         return Task.CompletedTask;

    }

    public async Task<Lejer> GetLejerByIdAsync(int lejerId)
    {

        // Because of InMemory a new object of Lejer is made to prevent changes to the object before hitting "Gem" button
        var lej = _lejere.First(x => x.LejerID == lejerId);

        var newLej = new Lejer
        {
            LejerID = lej.LejerID,
            Navn = lej.Navn,
            Telefon = lej.Telefon,
            Email = lej.Email
        };

        return await Task.FromResult(newLej);

    }

    public async Task<IEnumerable<Lejer>> GetLejereByNameAsync(string name)

    {
        if (string.IsNullOrEmpty(name)) return await Task.FromResult(_lejere);

        return _lejere.Where(x => x.Navn.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task UpdateLejerAsync(Lejer lejer)
    {

        if (_lejere.Any(x => x.LejerID == lejer.LejerID &&
        x.Navn.Equals(lejer.Navn, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var lej = _lejere.FirstOrDefault(x => x.LejerID == lejer.LejerID);

        if (lej != null)
        {
            lej.Navn = lejer.Navn;
            lej.Telefon = lejer.Telefon;
            lej.Email = lejer.Email;
        }

        return Task.CompletedTask;
    }
}