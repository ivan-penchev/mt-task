using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Services;
using API.Data.Models;

namespace API.Services
{
    public interface IRadioService : IDataService<Radio>
    {
        Task<Radio> FindById(int id);
    }
}
