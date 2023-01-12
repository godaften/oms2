using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.CoreBusiness;
using OMS.UseCases.Medarbejdere.Interfaces;
using OMS.UseCases.PluginInterfaces;

namespace OMS.UseCases.Medarbejdere;

public class ViewMedarbejderByIdUseCase : IViewMedarbejderByIdUseCase
{
    private readonly IMedarbejderRepository medarbejderRepository;

    public ViewMedarbejderByIdUseCase(IMedarbejderRepository medarbejderRepository)
    {
        this.medarbejderRepository = medarbejderRepository;
    }
    public async Task<Medarbejder> ExecuteAsync(int medarbejderId)
    {
        return await medarbejderRepository.GetMedarbejderByIdAsync(medarbejderId);
    }
}
