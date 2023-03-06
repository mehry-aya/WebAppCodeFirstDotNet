using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCodeFirst.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "take a look")]
        [StringLength(20,MinimumLength = 3, ErrorMessage ="incorrect length")]
        public string Nom { get; set; }
        [Range(1,5, ErrorMessage = "betwen 1 and 5")]
        public int Etoiles { get; set; }
        [Required]
        public string Villes { get; set; }
        [Required, DataType(DataType.Url),Display(Name = "site Web")]
        [Column("SiteW")]
        public string SiteWeb { get; set; }
        
        public virtual ICollection<Appreciation>? Appreciation { get; set;}
     


    }
}
