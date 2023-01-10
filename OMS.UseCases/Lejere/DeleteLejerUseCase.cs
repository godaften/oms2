using OMS.CoreBusiness;
using OMS.UseCases.Lejere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Lejere;

public class DeleteLejerUseCase : IDeleteLejerUseCase
{
    private readonly ILejerRepository lejerRepository;

    public DeleteLejerUseCase(ILejerRepository lejerRepository)
    {
        this.lejerRepository = lejerRepository;
    }

    public async Task ExecuteAsync (Lejer lejer)
    {
        await this.lejerRepository.DeleteLejerAsync(lejer);
    }

}


