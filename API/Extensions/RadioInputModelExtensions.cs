using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using API.Controllers.Radios.Models;
namespace API.Extensions
{
    public static class RadioInputModelExtensions
    {
        public static Radio ToRadioEntity(this RadioInputModel radioInputModel, int id)
            => new Radio { 
                Id = id,
                Alias = radioInputModel.Alias,
                AllowedLocations = radioInputModel.AllowedLocations 
            };
    }
}
