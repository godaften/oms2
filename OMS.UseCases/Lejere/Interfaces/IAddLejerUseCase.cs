using OMS.CoreBusiness;

namespace OMS.UseCases.Lejere.Interfaces
{
    public interface IAddLejerUseCase
    {
        Task ExecuteAsync(Lejer lejer);
    }
}