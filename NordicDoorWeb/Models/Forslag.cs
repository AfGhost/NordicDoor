using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Forslag
    {
        [Key]
        public int forslag_id { get; set; }
        [DisplayName("Ansatt ID")]
        [Required]
        public int ansatt_id { get; set; }
        [DisplayName("Tittel")]
        [Required]
        public string tittel { get; set; }
        [DisplayName("Nytt Forslag")]
        [Required]
        public string nyttforslag { get; set; }
        [DisplayName("Årsak")]
        public string årsak { get; set; }
        [DisplayName("Mål")]
        public string mål { get; set; }
        [DisplayName("Løsning")]
        public string løsning { get; set; }
        [DisplayName("Dato Registrert")]
        [Required]
        public DateTime dato_registrert { get; set; } = DateTime.Now;
        [DisplayName("Frit")]
        public DateTime frist { get; set; }
        [DisplayName("Bilde")]
        public long? Bilde { get; set; }
        public int navn_id { get; set; }
        [DisplayName("Ansvarlig")]
        public string? ansvarlig { get; set; }
        public int tperiode_id { get; set; }
        public int kostnad_id { get; set; }
        public int teams_id { get; set; }
        public int gkjenning_id { get; set; }
        public int status_id { get; set; }


        public virtual Ansatt Ansatt { get; set; }  
        public virtual Navn Navn { get; set; }
        public virtual Tidsperiode Tidsperiode { get; set; }
        public virtual Kostnad Kostnad { get; set; }
        public virtual Teams Teams { get; set; }
        public virtual Godkjenning Godkjenning { get; set; }
        public virtual Status Status { get; set; }



    }
}
