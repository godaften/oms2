using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.CoreBusiness;
using OMS.UseCases.Kontorhuse.Interfaces;
using OMS.UseCases.PluginInterfaces;

namespace OMS.UseCases.Kontorhuse;

public class ViewKontorhusByNameUseCase : IViewKontorhusByNameUseCase
{
    private readonly IKontorhusRepository kontorhusRepository;

    public ViewKontorhusByNameUseCase(IKontorhusRepository kontorhusRepository)
    {
        this.kontorhusRepository = kontorhusRepository;
    }
    public async Task<IEnumerable<Kontorhus>> ExecuteAsync(string name = "")
    {
        return await kontorhusRepository.GetKontorhuseByNameAsync(name);

    }

}
