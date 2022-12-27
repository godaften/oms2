using OMS.CoreBusiness;
using OMS.UseCases.Lejere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Lejere;

public class ViewLejereByNameUseCase : IViewLejereByNameUseCase
{
    private readonly ILejerRepository lejerRepository;

    public ViewLejereByNameUseCase(ILejerRepository lejerRepository)
    {
        this.lejerRepository = lejerRepository;
    }

    public async Task<IEnumerable<Lejer>> ExecuteAsync(string name = "")
    {
        return await lejerRepository.GetLejereByNameAsync(name);
    }
}
