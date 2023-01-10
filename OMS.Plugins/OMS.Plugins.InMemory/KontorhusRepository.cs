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

        if (_kontorhuse.Any(x => x.KontorhusNavn.Equals(kontorhus.KontorhusNavn, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        _kontorhuse.Add(kontorhus);

        var maxId = _kontorhuse.Max(x => x.KontorhusID);
        kontorhus.KontorhusID = maxId + 1;

        return Task.CompletedTask;
    }


    // LAV SENERE - SE LEJERREPO
    public Task DeleteKontorhusAsync(Kontorhus kontorhus)
    {
        var khus = _kontorhuse.FirstOrDefault(x => x.KontorhusID == kontorhus.KontorhusID);

        if (khus != null)
        {
            _kontorhuse.Remove(khus);
        }

        return Task.CompletedTask;
    }



    public async Task<Kontorhus?> GetKontorhusById(int kontorhusId)
    {

        var khus = _kontorhuse.FirstOrDefault(x => x.KontorhusID == kontorhusId);

        var newKhus = new Kontorhus();
        if (khus != null)
        {
            newKhus.KontorhusID = khus.KontorhusID;
            newKhus.KontorhusNavn = khus.KontorhusNavn;
            newKhus.KontorhusTelefon = khus.KontorhusTelefon;
            newKhus.KontorhusEmail = khus.KontorhusEmail;
            newKhus.KontorhusLejere = new List<KontorhusLejer>();

            if (khus.KontorhusLejere != null && khus.KontorhusLejere.Count > 0)
            {
                foreach (var khusLejer in khus.KontorhusLejere)
                {
                    var newKhusLejer = new KontorhusLejer
                    {
                        LejerID = khusLejer.LejerID,
                        KontorhusID = khus.KontorhusID,
                        Kontorhus = khus,
                        Lejer = new Lejer()

                    };
                    if (khusLejer.Lejer != null)
                    {
                        newKhusLejer.Lejer.LejerID = khusLejer.Lejer.LejerID;
                        newKhusLejer.Lejer.Navn = khusLejer.Lejer.Navn;
                        newKhusLejer.Lejer.Telefon = khusLejer.Lejer.Telefon;
                        newKhusLejer.Lejer.Email = khusLejer.Lejer.Email;


                    }
                    newKhus.KontorhusLejere.Add(newKhusLejer);

                }

            }
        }
        return await Task.FromResult(newKhus);
    }


    public async Task<IEnumerable<Kontorhus>> GetKontorhuseByNameAsync(string name)
    {
        return await Task.FromResult(_kontorhuse.Where(x => x.KontorhusNavn.Contains(name, StringComparison.OrdinalIgnoreCase)));
    }

    public Task UpdateKontorhusAsync(Kontorhus kontorhus)
    {

        if (_kontorhuse.Any(x => x.KontorhusID != kontorhus.KontorhusID &&
        x.KontorhusNavn.ToLower() == kontorhus.KontorhusNavn.ToLower()))
            return Task.CompletedTask;

        var khus = _kontorhuse.FirstOrDefault(x => x.KontorhusID == kontorhus.KontorhusID);
        if (khus != null)
        {
            khus.KontorhusNavn = kontorhus.KontorhusNavn;
            khus.KontorhusTelefon = kontorhus.KontorhusTelefon;
            khus.KontorhusEmail = kontorhus.KontorhusEmail;
            khus.KontorhusLejere = kontorhus.KontorhusLejere;
        }

        return Task.CompletedTask;
    }
}
