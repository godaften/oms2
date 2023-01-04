using OMS.CoreBusiness;
using OMS.UseCases.Lejere.Interfaces;
using OMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.UseCases.Lejere
{
    public class ViewLejerByIdUseCase : IViewLejerByIdUseCase
    {
        private readonly ILejerRepository lejerRepository;

        public ViewLejerByIdUseCase(ILejerRepository lejerRepository)
        {
            this.lejerRepository = lejerRepository;
        }
        public async Task<Lejer> ExecuteAsync(int lejerId)
        {
            return await this.lejerRepository.GetLejerByIdAsync(lejerId);
        }

        //public async Task<Lejer> GetLejerAsync(int lejerId)
        //{
        //    return await this.lejerRepository.GetLejerById(lejerId);
        //}

        //public async Task<Lejer> RemoveLejerAsync(int lejerId)
        //{
        //    return await this.lejerRepository.RemoveLejer(lejerId);

        //}
    }
}
