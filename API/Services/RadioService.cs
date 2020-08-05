using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Services;
using API.Data.Models;
namespace API.Services
{
    public class RadioService : DataService<Radio>, IRadioService
    {
        public RadioService(DbContext db) : base(db)
        {
        }

        public async Task<Radio> FindById(int id)
        => await this.All()
            .FirstOrDefaultAsync(g => g.Id == id);
    }
}
