using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerijeWebAPP.Models
{
    public class Kategorija
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//iskljuceno s ovim AUTO_INCREMEN
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set; }
        public List<Serija> Serija { get; set; }
       
    }
}
