using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant /this is the index method
        public ActionResult Index()
        {
            return View();
        }
    }
}