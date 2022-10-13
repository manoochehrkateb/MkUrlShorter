using Microsoft.EntityFrameworkCore;
using MkUrlShorter.Core.Domain.Base;
using MkUrlShorter.Core.Domain.UrlShorters.Entities;
using MkUrlShorter.Core.Domain.UrlShorters.Services;
using MkUrlShorter.Infra.Data.SqlServer;
using MkUrlShorter.Infra.Data.SqlServer.Contracts;
using MkUrlShorter.Infra.Data.SqlServer.Implements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MkUrlShorter.Core.ApplicationServices.UrlShorters
{
    public class UrlShorterService : IUrlShorterService
    {
        private readonly IUrlShorterRepository urlShorterRepository;

        public UrlShorterService(IUrlShorterRepository mkUrlShorterDbContext)
        {
            this.urlShorterRepository = mkUrlShorterDbContext;
        }

        public async Task<ServiceResultDto<string>> Add(string mainUrl)
        {
            try
            {
                var dbModel = await urlShorterRepository.GetByMainUrl(mainUrl);
                if (dbModel != null)
                    return ServiceResultDto<string>.Ok(dbModel.ShortUrl);

                dbModel = new UrlShorter()
                {
                    MainUrl = mainUrl,
                    ShortUrl = GenerateShorterUrl()
                };

                return ServiceResultDto<string>.Ok(dbModel.ShortUrl);
            }
            catch (Exception ex)
            {
                return ServiceResultDto<string>.NotOk(ex.Message);
            }
        }


        public async Task<ServiceResultDto<UrlShorter>> GetByShortUrl(string shortUrl)
        {
            var dbModel = await urlShorterRepository.GetByShortUrl(shortUrl);
            if(dbModel == null)
                return ServiceResultDto<UrlShorter>.NotOk("not exist");

            await urlShorterRepository.AddViewCount(dbModel.Id);

            return ServiceResultDto<UrlShorter>.Ok(dbModel);
        }


        #region private methods
        private string GenerateShorterUrl()
        {
            var ticks = new DateTime(2016, 1, 1).Ticks;
            var ans = DateTime.Now.Ticks - ticks;
            return ans.ToString("x");
        }
        #endregion
    }
}
