using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Tidsperiode
    {
        [Key]
        public int tperiode_id { get; set; }
        [DisplayName("Varighet")]
        public int varighet { get; set; }
        [DisplayName("Lang/Kortsiktig")]
        public int tperiode { get; set; }
        [DisplayName("0-For kortsiktig, 1-For langsiktig")]
        public int type_tid { get; set; }


    }
}