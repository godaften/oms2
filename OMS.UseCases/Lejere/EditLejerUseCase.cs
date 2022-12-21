using OMS.CoreBusiness;
using OMS.UseCases.Lejere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Lejere
{
    public class EditLejerUseCase : IEditLejerUseCase
    {
        private readonly ILejerRepository lejerRepository;

        public EditLejerUseCase(ILejerRepository lejerRepository)
        {
            this.lejerRepository = lejerRepository;
        }
        public async Task ExecuteAsync(Lejer lejer)
        {
            await this.lejerRepository.UpdateLejerAsync(lejer);

        }
    }
}
