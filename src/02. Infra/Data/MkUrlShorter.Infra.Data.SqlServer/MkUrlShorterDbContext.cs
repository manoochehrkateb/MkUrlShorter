using Microsoft.EntityFrameworkCore;
using System;

namespace MkUrlShorter.Infra.Data.SqlServer
{
    public class MkUrlShorterDbContext : DbContext
    {
        public MkUrlShorterDbContext(DbContextOptions<MkUrlShorterDbContext> options) : base(options)
        {
        }
    }
}
