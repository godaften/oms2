using OMS.CoreBusiness;
using OMS.UseCases.Lejere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Lejere;

public class AddLejerUseCase : IAddLejerUseCase
{
    private readonly ILejerRepository lejerRepository;

    public AddLejerUseCase(ILejerRepository lejerRepository)
    {
        this.lejerRepository = lejerRepository;
    }

    public async Task ExecuteAsync(Lejer lejer)
    {
        if (lejer == null) return;

        await this.lejerRepository.AddLejerAsync(lejer);
    }

}
