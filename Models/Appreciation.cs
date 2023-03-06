
using System.ComponentModel.DataAnnotations;

namespace WebAppCodeFirst.Models
{
    public class Appreciation
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Person Name ")]
        public string Name { get; set; }
       
        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        [Display(Name = "Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel? Hotel { get; set; }


    }
}
