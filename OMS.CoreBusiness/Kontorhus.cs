using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.CoreBusiness;

public class Kontorhus
{
    public int KontorhusID { get; set; }

    public string KontorhusNavn { get; set; } = string.Empty;

    public string KontorhusTelefon { get; set; } = string.Empty;

    public string KontorhusEmail { get; set; } = string.Empty;

}
