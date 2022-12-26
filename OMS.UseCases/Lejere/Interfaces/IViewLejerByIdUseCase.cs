using OMS.CoreBusiness;

namespace OMS.UseCases.Lejere.Interfaces
{
    public interface IViewLejerByIdUseCase
    {
        Task<Lejer> ExecuteAsync(int lejerId);
    }
}