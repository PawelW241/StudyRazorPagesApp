using System.ComponentModel.DataAnnotations;

namespace Projekt2.Models
{
    public class TablePattern
    {
        public int? Id { get; set; }
        [Display(Name = "Nazwa")]
        public string? Nazwa { get; set; }
        [Display(Name = "Stroj")]
        public string? Stroj { get; set; }
        [Display(Name = "Podgrupa")]
        public string? Podgrupa { get; set; }
        [Display(Name = "Skala")]
        public string? Skala { get; set; }
        [Display(Name = "Opis")]
        public string? Opis { get; set; }
        [Display(Name = "Zdjecie")]
        public string? Zdjecie { get; set; }
    }
}
