using OMS.CoreBusiness;

namespace OMS.UseCases.PluginInterfaces;

public interface ILejerRepository
{
    Task<IEnumerable<Lejer>> GetLejereByNameAsync(string name);

    // Skal der være en bool med exists?
    // Task<bool> ExistsAsync(Lejer lejer);

    Task AddLejerAsync(Lejer lejer);
    Task UpdateLejerAsync(Lejer lejer);

    Task<Lejer> GetLejerByIdAsync(int lejerId);


}
