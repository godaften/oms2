using OMS.CoreBusiness;

namespace OMS.UseCases.PluginInterfaces
{
    public interface IKontorhusRepository
    {
        Task<IEnumerable<Kontorhus>> GetKontorhuseByNameAsync(string name);

        Task AddKontorhusAsync(Kontorhus kontorhus);

        Task<Kontorhus?> GetKontorhusById(int kontorhusId);

        Task UpdateKontorhusAsync(Kontorhus kontorhus);
    }
}