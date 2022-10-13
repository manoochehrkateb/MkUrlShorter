using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MkUrlShorter.Core.Domain.UrlShorters.Entities;

namespace MkUrlShorter.Infra.Data.SqlServer.Configs
{
    public class UrlShortesConfigs : IEntityTypeConfiguration<UrlShorter>
    {
        public void Configure(EntityTypeBuilder<UrlShorter> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(bc => bc.MainUrl).HasMaxLength(1048576).IsRequired();
            builder.Property(bc => bc.ShortUrl).HasMaxLength(1024).IsRequired();
        }
    }
}
