using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class T_medlemmer
    {
        [Key]
        public int t_medlemmer_id { get; set; }
        [HiddenInput]
        public int navn_id { get; set; }
        [HiddenInput]
        public int teams_id { get; set; }


        public virtual Navn Navn { get; set; }
        public virtual Teams Teams { get; set; }


    }
}