using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.CoreBusiness;


namespace OMS.UseCases.Lejere.Interfaces;

public interface IDeleteLejerUseCase
{   
    Task ExecuteAsync(Lejer lejer);
}

