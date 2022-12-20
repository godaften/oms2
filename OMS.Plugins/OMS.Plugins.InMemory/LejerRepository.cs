using OMS.CoreBusiness;
using OMS.UseCases.PluginInterfaces;

namespace OMS.Plugins.InMemory
{
    // Plugin er afhængig af Use Case -> clean architecture
    public class LejerRepository : ILejerRepository
    {
        private List<Lejer> _lejere;

        public LejerRepository()
        {
            _lejere = new List<Lejer>()
            {
                new Lejer { LejerID = 1, Navn = "Askov", Telefon ="12131415" },
                new Lejer { LejerID = 2, Navn = "Transportfirmaet", Telefon="23242526" },
                new Lejer { LejerID = 3, Navn = "Tolkemanden", Telefon="34353637" }
            };
        }
        public async Task<IEnumerable<Lejer>> GetLejereByNameUseCaseAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_lejere);

            // 'Where' returnerer IEnumerable
            return _lejere.Where(x => x.Navn.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}