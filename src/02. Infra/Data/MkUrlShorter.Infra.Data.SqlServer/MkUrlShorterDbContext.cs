using Microsoft.EntityFrameworkCore;
using MkUrlShorter.Core.Domain.UrlShorters.Entities;
using System;

namespace MkUrlShorter.Infra.Data.SqlServer
{
    public class MkUrlShorterDbContext : DbContext
    {
        public MkUrlShorterDbContext(DbContextOptions<MkUrlShorterDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }


        public DbSet<UrlShorter> UrlShorters { get; set; }
    }
}
