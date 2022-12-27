using OMS.CoreBusiness;

namespace OMS.UseCases.Kontorhuse.Interfaces
{
    public interface IViewKontorhusByNameUseCase
    {

        Task<IEnumerable<Kontorhus>> ExecuteAsync(string name = "");
    }
}