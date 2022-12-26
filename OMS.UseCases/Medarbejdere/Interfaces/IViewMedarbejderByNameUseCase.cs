using OMS.CoreBusiness;

namespace OMS.UseCases.Medarbejdere.Interfaces
{
    public interface IViewMedarbejderByNameUseCase
    {
        Task<IEnumerable<Medarbejder>> ExecuteAsync(string name = "");
    }
}