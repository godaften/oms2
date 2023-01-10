using OMS.CoreBusiness;

namespace OMS.UseCases.PluginInterfaces;

public interface ILejerRepository
{
    Task<IEnumerable<Lejer>> GetLejereByNameAsync(string name);
    
    Task AddLejerAsync(Lejer lejer);
    
    Task UpdateLejerAsync(Lejer lejer);
    
    Task<Lejer?> GetLejerByIdAsync(int lejerId);
    Task DeleteLejerAsync(Lejer lejer);
}
