using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sessions.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,ActionName("Index")]
        public ActionResult IndexPost(string boton,string txtNombre)
        {
            switch (boton)
            {
                case "Log In":
                    Session["usuario"] =Request.Form["txtNombre"];

                    Session["usuario"] = txtNombre;
                    break;
                case "+ 1":
                    Session["contador"]=Convert.ToInt32(Session["contador"])+1;
                    break;

                case "Cerrar Sesion":
                    Session.Clear();
                    Session.Abandon();
                    break;
            }
            return View();
        }
    }
}