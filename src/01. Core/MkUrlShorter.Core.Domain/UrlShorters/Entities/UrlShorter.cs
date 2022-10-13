using MkUrlShorter.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MkUrlShorter.Core.Domain.UrlShorters.Entities
{
    public class UrlShorter : BaseEntity
    {
        public long Id { get; set; }
        public long ViewCount { get; set; }
        public string MainUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}
