using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MkUrlShorter.Core.Domain.UrlShorters.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MkUrlShorter.Infra.Data.SqlServer.Contracts
{
    public interface IUrlShorterRepository
    {
        Task<long> Add(UrlShorter urlShorter);
        Task<bool> AnyByMainUrl(string mainUrl);
        Task AddViewCount(long id);
        Task<UrlShorter> GetByMainUrl(string mainUrl);
        Task<UrlShorter> GetByShortUrl(string shortUrl);
    }
}
