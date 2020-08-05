using Microsoft.EntityFrameworkCore;
using API.Data.Models;
using System.Reflection;

namespace API.Data
{
    public class RadioDbContext: DbContext
    {
        public RadioDbContext(DbContextOptions<RadioDbContext> options)
           : base(options)
        {
        }

        public DbSet<Radio> Radios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
