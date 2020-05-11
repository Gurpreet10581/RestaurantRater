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
        private RestaurantDbContext _db = new RestaurantDbContext();// it is a snapshot of database

        // GET: Restaurant /this is the index method
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList()); // turning all the restaurants into a list and passing to database by creating a new field above _db
        }

        //GET: Restaurant/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();// since it was a snapshot now we are saving it to database and bring it upto date
                return RedirectToAction("Index");//Index is entered to redirect it once new object is created and is valid
            }

            return View(restaurant);//added the restaurant so it doesn't clears everything and instead it will take us back to the view.
        }
    }
}