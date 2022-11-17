using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Godkjenning
    {
        [Key]
        public int godkjenning_id { get; set; }
        [DisplayName("Ansatt ID")]
        [Required]
        public int ansatt_id { get; set; }
        [DisplayName("Godkjent eller ikke")]
        [Required]
        public string gkjent_ikke_gkjent { get; set; }
        [DisplayName("0=Ikke Godkjent, 1=Godkjent")]
        [Required]
        public int? type_godkjenning { get; set; }


        public virtual Ansatt Ansatt { get; set; }

    }
}
