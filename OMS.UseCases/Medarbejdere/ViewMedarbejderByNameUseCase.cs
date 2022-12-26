using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.CoreBusiness;
using OMS.UseCases.Medarbejdere.Interfaces;
using OMS.UseCases.PluginInterfaces;

namespace OMS.UseCases.Medarbejdere
{
    public class ViewMedarbejderByNameUseCase : IViewMedarbejderByNameUseCase
    {
        private readonly IMedarbejderRepository medarbejderRepository;

        public ViewMedarbejderByNameUseCase(IMedarbejderRepository medarbejderRepository)
        {
            this.medarbejderRepository = medarbejderRepository;
        }
        public async Task<IEnumerable<Medarbejder>> ExecuteAsync(string name = "")
        {
            return await medarbejderRepository.GetMedarbejdereByNameAsync(name);
        }
    }
}
