using OMS.CoreBusiness;

namespace OMS.UseCases.PluginInterfaces
{
    public interface IKontorhusRepository
    {
        Task<IEnumerable<Kontorhus>> GetKontorhuseByNameAsync(string name);

        //Task<IEnumerable<Kontorhus>> GetKontorhuseByNameUseCaseAsync(string name);

        Task AddKontorhusAsync(Kontorhus kontorhus);

    }
}