using FirstChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace FirstChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var comicBooks = ComicBookManager.GetComicBooks();
            return View(comicBooks);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ComicBook comicBook = ComicBookManager.GetComicBooks().FirstOrDefault(c => c.ComicBookId == id);
            if (comicBook == null)
            {
                return HttpNotFound();
            }

            return View(comicBook);

        }
    }


}