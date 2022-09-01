using LongURLToShortURLConverter_EH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LongURLToShortURLConverter_EH.Controllers
{
    public class HomeController : Controller
    {
        readonly DbConfig _databaseContext = new DbConfig();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult GenerateShortUrl(string longUrl)
        {
            if(!ValidateUrl(longUrl))
                return RedirectToAction("Error404");

            string shortUrl = "";
            if (_databaseContext.UrlInformation.ToList().Where(x => x.LongUrl == longUrl).Any())
            {
                shortUrl = _databaseContext.UrlInformation.Where(x => x.LongUrl == longUrl)?.FirstOrDefault().ShortUrl;
            }
            else
            {
                shortUrl = GenerateUniqueShortUrl();
                Url url = new Url() { LongUrl = longUrl, ShortUrl = shortUrl };
                _databaseContext.UrlInformation.Add(url);
                _databaseContext.SaveChanges();
            }

            return Json(new { shortUrl });
        }

        public string GenerateUniqueShortUrl()
        {
            Guid guid = Guid.NewGuid();
            string guidString = Convert.ToBase64String(guid.ToByteArray());
            guidString = guidString.Replace("=", "");
            guidString = guidString.Replace("+", "");
            guidString = guidString.Replace("/", "");
            return guidString.Substring(0, 8);
        }
        
        public ActionResult RedirectToLongUrl(string shortUrl)
        {
            var longUrl = _databaseContext.UrlInformation.Where(x => x.ShortUrl == shortUrl)?.FirstOrDefault().LongUrl;
            if (!string.IsNullOrEmpty(longUrl))
                return Redirect(longUrl);

            return RedirectToAction("Error404");
        }

        public bool ValidateUrl(string longUrl)
        {
            return Uri.TryCreate(longUrl, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}