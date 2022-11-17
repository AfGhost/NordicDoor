using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Kostnad
    {
        [Key]
        public int kostnad_id { get; set; }
        [DisplayName("Kostnad")]
        [Required]
        public string kostnad { get; set; }
        [DisplayName("Med eller uten kostnad")]
        [Required]
        public string med_uten_K { get; set; }
        [DisplayName("0- For Ingen kostnad, 1- For kostnad")]
        [Required]
        public int type_K { get; set; }

    }
}