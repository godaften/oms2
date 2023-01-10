using OMS.CoreBusiness;

namespace OMS.UseCases.Lejere.Interfaces;


public interface IEditLejerUseCase
{
    Task ExecuteAsync(Lejer lejer);

}