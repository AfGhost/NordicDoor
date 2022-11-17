using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Roller
    {
        [Key]
        public int roller_id { get; set; }
        [DisplayName("Rolle")]
        [Required]
        public string rolle { get; set; }
        [DisplayName("1-For admin, 2-For Teamleder, 3-For Bruker")]
        public int grad { get; set; }


    }
}
