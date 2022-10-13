using System;
using System.Collections.Generic;
using System.Text;

namespace MkUrlShorter.Core.Domain.Base
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
    }
}
