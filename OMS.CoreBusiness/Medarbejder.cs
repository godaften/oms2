using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.CoreBusiness;

public class Medarbejder
{
    public int MedarbejderID { get; set; }
    [Required]
    public string Navn { get; set; } = string.Empty;
    [Required]
    public string Telefon { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;


    /// <summary>
    /// SKAL FIXES
    /// </summary>
    public int? LejerID { get; set; }
    public Lejer? Lejer { get; set; }


}
