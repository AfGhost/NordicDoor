using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class RapporterProblem
    {
        [Key]
        public int rproblem_id { get; set; }
        [DisplayName("Ansatt ID")]
        [HiddenInput]
        public int ansatt_id { get; set; }
        [DisplayName("Problem Tittel")]
        [Required]
        public string problem_tittel { get; set; }
        [DisplayName("Problem Tekst")]
        [Required]
        public string problem_tekst { get; set; }



        public virtual Ansatt Ansatt { get; set; }


    }
}