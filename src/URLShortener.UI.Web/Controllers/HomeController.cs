using System;
using System.Web.Mvc;
using URLShortener.UI.Web.Models;
using URLShortener.UI.Web.Handlers;

namespace URLShortener.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private static XMLHandler xmlHandler = new XMLHandler();

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Index(String shorturl)
        {
            var url = xmlHandler.GetURLByID(shorturl);
            Response.StatusCode = 302;
            Response.RedirectLocation = url.Original;

            return new ContentResult();
        }

        public ActionResult Preview(String shorturl)
        {
            var url = xmlHandler.GetURLByID(shorturl);

            if (url == null)
                return RedirectToAction("default");

            return View(url);
        }

        public ActionResult About()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HandleForm(string original, string alias)
        {
            // TODO: Validar input de URL vazia
            var url = new Models.URL()
            {
                Original = original,
                Id = alias,
                Created = DateTime.Now,
                CreatedBy = Request.ServerVariables["LOGON_USER"]
            };

            var updatedId = xmlHandler.InsertNewURL(url);
            url.Id = updatedId;

            return RedirectToAction("create", url);
        }

        public ActionResult Create(URL url)
        {
            return View(url);
        }

        public ActionResult Copy(URL url)
        {
            return View(url);
        }
    }
}