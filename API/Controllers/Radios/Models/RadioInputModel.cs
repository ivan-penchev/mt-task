using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Controllers.Radios.Models
{
    // https://github.com/dotnet/runtime/issues/782
    public class RadioInputModel
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }
        [JsonPropertyName("allowed_locations")]
        public List<string> AllowedLocations { get; set; }
    }
}
