using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoorWeb.Models
{
    public class Status
    {
        [Key]
        public int status_id { get; set; }
        [DisplayName("Fremdrift")]
        [HiddenInput]
        [Required]
        public string fremdrift_id { get; set; }


        public virtual Fremdrift Fremdrift { get; set; }


    }
}
