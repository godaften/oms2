using OMS.CoreBusiness;

namespace OMS.UseCases.Kontorhuse.Interfaces
{
    public interface IDeleteKontorhusUseCase
    {
        Task ExecuteAsync(Kontorhus kontorhus);
    }
}