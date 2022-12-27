using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Plugins.InMemory;

public class MedarbejderRepository : IMedarbejderRepository
{
    private List<Medarbejder> _medarbejdere;

    public MedarbejderRepository()
    {
        _medarbejdere = new List<Medarbejder>()
        {
            new Medarbejder()
            {
                MedarbejderID = 1,
                Navn ="Lars",
                Telefon ="12131415",
                Email ="lars@test.dk"
            },

            new Medarbejder()
            {
                MedarbejderID = 2,
                Navn ="Kurt",
                Telefon ="13131415",
                Email ="kurt@test.dk"
            },

            new Medarbejder()
            {
                MedarbejderID = 3,
                Navn ="Hans",
                Telefon ="14131415",
                Email ="hans@test.dk"
            }
        };
    }

    public Task AddMedarbejderAsync(Medarbejder medarbejder)
    {
        // Hvis der er en medarbejder med samme navn allerede, returnerer vi uden at gøre mere
        if (_medarbejdere.Any(x => x.Navn.Equals(medarbejder.Navn, StringComparison.OrdinalIgnoreCase)))
        return Task.CompletedTask;

        _medarbejdere.Add(medarbejder);

        var maxId = _medarbejdere.Max(x => x.MedarbejderID);
        medarbejder.MedarbejderID = maxId + 1;

        return Task.CompletedTask;
        
    }

    // Inmemoryrepository - simulerer async, så det ligner entity framework metoder
    public async Task<IEnumerable<Medarbejder>> GetMedarbejdereByNameAsync(string name)
    {
        // returnerer alle hvis søgefeltet er tomt
        if (string.IsNullOrEmpty(name)) return await Task.FromResult(_medarbejdere);

        // returnerer det der blev søgt 
        return _medarbejdere.Where(x => x.Navn.Contains(name, StringComparison.OrdinalIgnoreCase));


    }
}
