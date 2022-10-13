using Microsoft.EntityFrameworkCore;
using MkUrlShorter.Core.Domain.UrlShorters.Entities;
using MkUrlShorter.Infra.Data.SqlServer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MkUrlShorter.Infra.Data.SqlServer.Implements
{
    public class UrlShorterRepository : IUrlShorterRepository
    {
        private readonly MkUrlShorterDbContext context;

        public UrlShorterRepository(MkUrlShorterDbContext context)
        {
            this.context = context;
        }

        public async Task<long> Add(UrlShorter urlShorter)
        {
            await context.UrlShorters.AddAsync(urlShorter);
            return urlShorter.Id;
        }

        public async Task AddViewCount(long id)
        {
            var dbModel = await context.UrlShorters.FindAsync(id);
            dbModel.ViewCount += 1;
            await context.SaveChangesAsync();
        }

        public async Task<bool> AnyByMainUrl(string mainUrl)
        {
            return await context.UrlShorters.AnyAsync(a => a.MainUrl == mainUrl);
        }

        public async Task<UrlShorter> GetByMainUrl(string mainUrl)
        {
            return await context.UrlShorters.FirstOrDefaultAsync(f => f.MainUrl == mainUrl);
        }

        public async Task<UrlShorter> GetByShortUrl(string shortUrl)
        {
            return await context.UrlShorters.FirstOrDefaultAsync(f => f.ShortUrl == shortUrl);
        }
    }
}
