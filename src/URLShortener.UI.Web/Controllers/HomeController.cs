using System;
using System.Web.Mvc;
using URLShortener.Models;
using URLShortener.Handlers;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        private static XMLHandler xmlHandler = new XMLHandler();

        public ActionResult Default(URL url)
        {
            return View(url);
        }

        public ActionResult Index(String shorturl)
        {
            var url = xmlHandler.GetURLByID(shorturl);
            xmlHandler.AddHit(shorturl);
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
            var url = new Models.URL()
            {
                Original = original,
                Id = alias,
                Created = DateTime.Now,
                CreatedBy = Request.ServerVariables["LOGON_USER"],
                Hits = 0
            };

            var updatedURL = xmlHandler.InsertNewURL(url);

            switch (updatedURL.Status)
            {
                case Status.AliasExists: return RedirectToAction("default", updatedURL);
                case Status.URLExists:   return RedirectToAction("copy", updatedURL);
                case Status.NewURL:      return RedirectToAction("create", updatedURL);
            }

            return RedirectToAction("default");
        }

        public ActionResult Create(URL url)
        {
            return View(url);
        }

        public ActionResult Copy(URL url)
        {
            return View(url);
        }

        public ActionResult History()
        {
            var currentUser = Request.ServerVariables["LOGON_USER"];
            var urlHistory = xmlHandler.GetURLsByUser(currentUser);

            return View(urlHistory);
        }
    }
}