using OMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.PluginInterfaces
{
    public interface ILejerRepository
    {
        Task<IEnumerable<Lejer>> GetLejereByNameUseCaseAsync(string name);

        // Skal der være en bool med exists?
        // Task<bool> ExistsAsync(Lejer lejer);

        Task AddLejerAsync(Lejer lejer);
        Task UpdateLejerAsync(Lejer lejer);

        Task<Lejer> GetLejerByIdAsync(int lejerId);


    }
}
