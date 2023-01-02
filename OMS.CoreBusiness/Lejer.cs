using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace OMS.CoreBusiness
{
    public class Lejer
    {

        // Lav flere valideringer
        public int LejerID { get; set; }

        [Required]
        [StringLength(100)]
        public string Navn { get; set;} = string.Empty;

        [Required]
        public string Telefon { get; set; } = string.Empty;

        public string? Adresse { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public List<KontorhusLejer> KontorhusLejere { get; set; } = new List<KontorhusLejer>();



        // FK
        // kontorfællesskabID
        // public int BygningID { get;}
    }
}