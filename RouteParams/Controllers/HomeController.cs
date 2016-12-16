using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouteParams.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.contador = id;
            return View();
        }
        /// <summary>
        /// Método al que llama
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,ActionName("Index")]
        public ActionResult PostIndex(int? id)
        {
            int contador = 1;
            if (id != null)
            {
                contador = (int)id + 1;
            }
            ViewBag.contador = id;

            return RedirectToAction("Index", new { id = contador });
        }
    }
}