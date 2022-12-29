using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.CoreBusiness;

// Klassen skal matche lejertabel i relation database, da ef core så vil vide, hvordan db skemaet skal laves
public class KontorhusLejer
{
    
    public int KontorhusID { get; set; }

    // Navigation property
    public Kontorhus? Kontorhus { get; set; }


    public int LejerID { get; set; }

    // Navigation property
    public Lejer? Lejer { get; set; }


}
