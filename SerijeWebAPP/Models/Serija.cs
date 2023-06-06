using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerijeWebAPP.Models
{
    public class Serija
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//iskljuceno s ovim AUTO_INCREMENT
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Streaming servis")]
        public string StreamingServis { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Broj sezona")]
        public int BrojSezona { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Potrebno Vrijeme")]
        public int PotrebnoVrijeme { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Da li bi Preporucio")]
        public Boolean Preporuka { get; set; }

        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Ilustracija Korice")]
        public string SlikaUrl { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Kategorija")]
        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
