using OMS.CoreBusiness;

namespace OMS.UseCases.Kontorhuse.Interfaces
{
    public interface IViewKontorhusByIdUseCase
    {
        Task<Kontorhus?> ExcecuteAsync(int kontorhusId);
    }
}