using FFC.Framework.WebServicesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFC.Framework.WebServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ForecastManager fm = new ForecastManager();

            //fm.GetProductItems();

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
