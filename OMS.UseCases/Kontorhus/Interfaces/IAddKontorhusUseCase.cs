using OMS.CoreBusiness;

namespace OMS.UseCases.Kontorhuse.Interfaces
{
    public interface IAddKontorhusUseCase
    {
        Task ExecuteAsync(Kontorhus kontorhus);
    }
}