using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using API.Validators;
namespace API.Controllers.Radios.Models
{
    // https://github.com/dotnet/runtime/issues/782
    public class RadioInputModel
    {
        [Required]
        [JsonPropertyName("alias")]

        public string Alias { get; set; }
        [Required]
        [JsonPropertyName("allowed_locations")]
        [MustHaveOneElementAttribute(ErrorMessage = "At least one location is required")]
        public List<string> AllowedLocations { get; set; }
    }
}
