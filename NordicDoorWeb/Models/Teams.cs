using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Teams
    {
        [Key]
        public int teams_id { get; set; }
        [DisplayName("Team")]
        public int team { get; set; }


    }
}