using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class Radio
    {
        public int RecordId { get; set; }

        public int Id { get; set; }

        public string Alias { get; set; }
        public string Location { get; set; }
        public List<string> AllowedLocations { get; set; }

        public bool HasLocation() => !string.IsNullOrWhiteSpace(Location);

        public string GetAllowedLocationIfExist(string location)
        => AllowedLocations
                .Where(x => x.ToLower().Contains(location.ToLowerInvariant()))
                .FirstOrDefault();

        public bool CanBePlaced(string location)
        {
            var allowedLocation = GetAllowedLocationIfExist(location);

            bool canBePlaced = allowedLocation == null ? false : true;

            return canBePlaced;
        }

        public void PlaceAtLocation(string location)
        {
            var allowedLocation = GetAllowedLocationIfExist(location);
            if (allowedLocation != null)
                Location = allowedLocation;
        }
    }
}
