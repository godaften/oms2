using OMS.CoreBusiness;
using OMS.UseCases.Medarbejdere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Medarbejdere;

public class AddMedarbejderUseCase : IAddMedarbejderUseCase
{
    private readonly IMedarbejderRepository medarbejderRepository;

    public AddMedarbejderUseCase(IMedarbejderRepository medarbejderRepository)
    {
        this.medarbejderRepository = medarbejderRepository;
    }

    public async Task ExecuteAsync(Medarbejder medarbejder)
    {
        if (medarbejder == null) return;

        await this.medarbejderRepository.AddMedarbejderAsync(medarbejder);

    }


}