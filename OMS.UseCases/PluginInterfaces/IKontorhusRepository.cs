using OMS.CoreBusiness;

namespace OMS.UseCases.PluginInterfaces
{
    public interface IKontorhusRepository
    {
        Task<IEnumerable<Kontorhus>> GetKontorhuseByNameAsync(string name);

        //Task<IEnumerable<Kontorhus>> GetKontorhuseByNameUseCaseAsync(string name);

        Task AddKontorhusAsync(Kontorhus kontorhus);

        // Hvis den får et id, der ikke findes, skal den have mulighed for at være null
        Task<Kontorhus?> GetKontorhusById(int kontorhusId);
        Task UpdateKontorhusAsync(Kontorhus kontorhus);
    }
}