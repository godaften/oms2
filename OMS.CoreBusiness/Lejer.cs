using System.ComponentModel.DataAnnotations;

namespace OMS.CoreBusiness
{
    public class Lejer
    {

        // Lav flere valideringer
        public int LejerID { get; set; }
        [Required]
        public string Navn { get; set;} = string.Empty;
        [Required]
        public string Telefon { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
       


        // FK
        // kontorfællesskabID
        // public int BygningID { get;}
    }
}