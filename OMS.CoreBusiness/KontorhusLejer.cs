using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.CoreBusiness;

public class KontorhusLejer
{
    public int KontorhusID { get; set; }

    // Navigation property
    public Kontorhus? Kontorhus { get; set; }

    public int LejerID { get; set; }

    // Navigation property
    public Lejer? Lejer { get; set; }

}
