﻿using MkUrlShorter.Core.Domain.Base;
using MkUrlShorter.Core.Domain.UrlShorters.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MkUrlShorter.Core.Domain.UrlShorters.Services
{
    public interface IUrlShorterService
    {
        Task<ServiceResultDto<string>> Add(string mainUrl);
        Task<ServiceResultDto<UrlShorter>> GetByShortUrl(string shortUrl);
        Task<ServiceResultDto<IList<UrlShorter>>> GetPaging(int pageIndex = 0, int pageSize = 10);
    }
}
