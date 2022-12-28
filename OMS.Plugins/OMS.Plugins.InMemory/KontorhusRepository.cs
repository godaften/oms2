using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OMS.Plugins.InMemory;

public class KontorhusRepository : IKontorhusRepository
{
    private List<Kontorhus> _kontorhuse;

    public KontorhusRepository()
    {
        _kontorhuse = new List<Kontorhus>() {

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
        };

    }

    public Task AddKontorhusAsync(Kontorhus kontorhus)
    {
        // Hvis der er et kontorhus med samme navn allerede, returnerer vi uden at gøre mere
        if (_kontorhuse.Any(x => x.KontorhusNavn.Equals(kontorhus.KontorhusNavn, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        _kontorhuse.Add(kontorhus);

        var maxId = _kontorhuse.Max(x => x.KontorhusID);
        kontorhus.KontorhusID = maxId + 1;

        return Task.CompletedTask;
    }


    public async Task<IEnumerable<Kontorhus>> GetKontorhuseByNameAsync(string name)
    {
        return _kontorhuse.Where(x => x.KontorhusNavn.Contains(name, StringComparison.OrdinalIgnoreCase));
    }


    //Task<IEnumerable<Kontorhus>> IKontorhusRepository.GetKontorhuseByNameUseCaseAsync(string name)
    //{
    //    throw new NotImplementedException();
    //}
}
