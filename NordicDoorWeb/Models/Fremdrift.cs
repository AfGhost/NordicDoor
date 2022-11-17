using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Fremdrift
    {
        [Key]
        public int fremdrift_id { get; set; }
        public int status_id { get; set; }
        public int forslag_id { get; set; }
        [DisplayName("Fremgang")]
        [Required]
        public string? fremgang { get; set; }
        [DisplayName("Forslag aktiv/Ikke aktiv")]        
        public string aktiv_ikke_aktiv { get; set; }
        [DisplayName("0=Ikke aktiv, 1=Aktiv")]
        public int type_aktiv { get; set; }
        [DisplayName("Fullført i %")]
        public decimal prosentvis_fullført { get; set; }
        [DisplayName("Tilordnet team")]
        public int tildelt_team { get; set; }




    }
}