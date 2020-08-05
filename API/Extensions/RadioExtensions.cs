using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using API.Controllers.Radios.Models;
namespace API.Extensions
{
    public static class RadioExtensions
    {
        public static LocationOutputModel ToLocationOutput(this Radio radio)
            => new LocationOutputModel { Location = radio.Location };
    }
}
