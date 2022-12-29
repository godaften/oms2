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

    public List<KontorhusLejer> KontorhusLejere { get; set; } = new List<KontorhusLejer>();

    public void AddLejer(Lejer lejer)
    {
        if (!this.KontorhusLejere.Any(x => x.Lejer != null && x.Lejer.Navn.Equals(lejer.Navn)))
        {
            this.KontorhusLejere.Add(new KontorhusLejer

            {
                LejerID = lejer.LejerID,
                Lejer = lejer,
                KontorhusID = this.KontorhusID,
                Kontorhus = this //this refererer til det nuværende kontorhus af denne klasse
            });

        }
    }

}
