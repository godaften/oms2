using OMS.CoreBusiness;
using OMS.UseCases.Kontorhuse.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Kontorhuse;

public class DeleteKontorhusUseCase : IDeleteKontorhusUseCase
{
    private readonly IKontorhusRepository kontorhusRepository;

    public DeleteKontorhusUseCase(IKontorhusRepository kontorhusRepository)
    {
        this.kontorhusRepository = kontorhusRepository;
    }

    public async Task ExecuteAsync(Kontorhus kontorhus)
    {
        await this.kontorhusRepository.DeleteKontorhusAsync(kontorhus);
    }

}
