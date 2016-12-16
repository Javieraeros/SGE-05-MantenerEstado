using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!Request.Cookies.AllKeys.Contains("contador"))
            {
                HttpCookie miCookie = new HttpCookie("contador", "0");
                miCookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(miCookie);

                ViewBag.contador = 0;
                /*
                HttpCookie google = new HttpCookie("NID");
                google.Domain = "google.com";
                ViewBag.google = google.Value;*/
            }
            else
            {
                HttpCookie miCookie = Request.Cookies["contador"];

                int contador = Convert.ToInt32(miCookie.Value);

                ViewBag.contador = contador;
            }

            return View();
        }

        [HttpPost,ActionName ("Index")]
        public ActionResult PostIndex()
        {
            HttpCookie miCookie = Request.Cookies["contador"];

            int contador = Convert.ToInt32(miCookie.Value);

            contador = contador + 1;
            ViewBag.contador = contador;

            miCookie.Value = Convert.ToString(contador);
            miCookie.Expires = DateTime.Now.AddDays(7);
            Response.SetCookie(miCookie);


            return RedirectToAction("Index");
        }
    }
}