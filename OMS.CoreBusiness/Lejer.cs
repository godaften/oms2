using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace OMS.CoreBusiness;

public class Lejer
{
    public int LejerID { get; set; }

    [Required]
    [StringLength(100)]
    public string Navn { get; set; } = string.Empty;

    [StringLength(15)]
    public string Telefon { get; set; } = string.Empty;

    [Required]
    [StringLength(15)]
    public string SMSTelefon { get; set; } = string.Empty;

    public string Adresse { get; set; } = string.Empty;

    public string Lokale { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public List<KontorhusLejer> KontorhusLejere { get; set; } = new List<KontorhusLejer>();

    public void AddKontorhus(Kontorhus kontorhus)
    {
        if (!this.KontorhusLejere.Any(x => x.Kontorhus != null && 
        x.Kontorhus.KontorhusNavn.Equals(kontorhus.KontorhusNavn)))
        {
            this.KontorhusLejere.Add(new KontorhusLejer

            {
                KontorhusID = kontorhus.KontorhusID,
                Kontorhus = kontorhus,
                LejerID = LejerID,
                Lejer = this
            });

        }
    }

 

}