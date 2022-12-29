using OMS.CoreBusiness;
using OMS.UseCases.Kontorhuse.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Kontorhuse;

public class ViewKontorhusByIdUseCase : IViewKontorhusByIdUseCase
{
    private readonly IKontorhusRepository kontorhusRepository;

    public ViewKontorhusByIdUseCase(IKontorhusRepository kontorhusRepository)
    {
        this.kontorhusRepository = kontorhusRepository;
    }

    public async Task<Kontorhus?> ExcecuteAsync(int kontorhusId)
    {
        return await this.kontorhusRepository.GetKontorhusById(kontorhusId);

    }
}
