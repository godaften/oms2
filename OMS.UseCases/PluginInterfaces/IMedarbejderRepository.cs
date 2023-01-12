﻿using OMS.CoreBusiness;
using System.Xml.Linq;

namespace OMS.UseCases.PluginInterfaces;

public interface IMedarbejderRepository
{
    public Task<IEnumerable<Medarbejder>> GetMedarbejdereByNameAsync(string name);

    Task AddMedarbejderAsync(Medarbejder medarbejder);

    Task<Medarbejder> GetMedarbejderByIdAsync(int medarbejderId);
}