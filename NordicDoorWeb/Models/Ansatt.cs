using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Ansatt
    {
        [Key]
        public int ansatt_id { get; set; }
        [DisplayName("Epost")]                
        public string? epost { get; set; }
        [DisplayName("Passord")]
        [Required]
        public string passord { get; set; }
        [DisplayName("Ansatt Tilstand")]
        [Required]
        public string? ansatt_tilstand { get; set; }
        public int navn_id { get; set; }
        public int teams_id { get; set; }
        public int roller_id { get; set; }
        public int t_medlemmer_id { get; set; }


        public virtual Navn Navn { get; set; }
        public virtual Teams Teams { get; set; }
        public virtual Roller Roller { get; set; }
        public virtual T_medlemmer T_medlemmer { get; set; }


    }
}
