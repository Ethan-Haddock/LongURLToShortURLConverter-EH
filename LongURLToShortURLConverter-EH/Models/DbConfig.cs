using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LongURLToShortURLConverter_EH.Models
{
    public class DbConfig : DbContext
    {
        public DbConfig() : base("StoredUrls")
        {
        }

        public DbSet<Url> UrlInformation { get; set; }
    }
}