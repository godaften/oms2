using OMS.CoreBusiness;

namespace OMS.UseCases.Medarbejdere.Interfaces
{
    public interface IAddMedarbejderUseCase
    {
        Task ExecuteAsync(Medarbejder medarbejder);
    }
}