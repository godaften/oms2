using OMS.CoreBusiness;

namespace OMS.UseCases.Medarbejdere.Interfaces
{
    public interface IViewMedarbejderByIdUseCase
    {
        Task<Medarbejder> ExecuteAsync(int medarbejderId);
    }
}