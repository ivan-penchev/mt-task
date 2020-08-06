using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace API.Controllers.Radios.Models
{
    public class LocationInputModel
    {
        [Required]
        public string Location { get; set; }
    }
}
