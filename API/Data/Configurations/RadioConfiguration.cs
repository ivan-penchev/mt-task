using API.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace API.Data.Configurations
{
    public class RadioConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Models.Radio>
    {
        public void Configure(EntityTypeBuilder<Radio> builder)
        {
            builder
                .HasKey(x => x.RecordId);

            builder
                .Property(x => x.Alias)
                .IsRequired();
            builder
                .Property(x => x.Id)
                .IsRequired();

            builder
                .Property(x=>x.AllowedLocations)
                .IsRequired()
                .HasConversion(
                        v => JsonSerializer.Serialize(v, default),
                        v => JsonSerializer.Deserialize<List<string>>(v, default));
        }
    }
}
