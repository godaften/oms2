using OMS.CoreBusiness;

namespace OMS.UseCases.Kontorhuse.Interfaces
{
    public interface IEditKontorhusUseCase
    {
        Task ExecuteAsync(Kontorhus kontorhus);
    }
}