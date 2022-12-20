using OMS.CoreBusiness;

namespace OMS.UseCases.Lejere.Interfaces
{
    public interface IViewLejereByNameUseCase
    {
        Task<IEnumerable<Lejer>> ExecuteAsync(string name = "");
    }
}