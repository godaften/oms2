using OMS.CoreBusiness;
using OMS.UseCases.Kontorhuse.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Kontorhuse;

public class AddKontorhusUseCase : IAddKontorhusUseCase
{
    private readonly IKontorhusRepository kontorhusRepository;

    public AddKontorhusUseCase(IKontorhusRepository kontorhusRepository)
    {
        this.kontorhusRepository = kontorhusRepository;
    }

    public async Task ExecuteAsync(Kontorhus kontorhus)
    {
        if (kontorhus == null) return;

        await this.kontorhusRepository.AddKontorhusAsync(kontorhus);

    }


}