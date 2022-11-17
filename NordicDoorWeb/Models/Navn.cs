using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Navn
    {
        [Key]
        public int navn_id { get; set; }
        [DisplayName("Fornavn")]
        [Required]
        public string fornavn { get; set; }
        [DisplayName("Mellomnavn")]
        public string mellomnavn { get; set; }
        [DisplayName("Etternavn")]
        [Required]
        public string etternavn { get; set; }
        [DisplayName("Brukernavn")]
        [Required]
        public string brukernavn { get; set; }


    }
}
