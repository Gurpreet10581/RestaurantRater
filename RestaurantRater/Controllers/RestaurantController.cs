using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller

    {
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant /this is the index method
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList()); // turning all the restaurants into a list and passing to database by creating a new field above _db
        }
    }
}