using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LongURLToShortURLConverter_EH.Models
{
    public class Url
    {
        public int Id { get; set; }

        public string LongUrl { get; set; }

        public string ShortUrl { get; set; }
    }
}