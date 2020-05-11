using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller

    {
        private RestaurantDbContext _db = new RestaurantDbContext();// it is a snapshot of database

        //Main Index method below some of it was default

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

        //Create method below

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

        //Delete method below 

        //Get: Restaurant/Delete/{id}
        public ActionResult Delete(int? id)// adding int ?=nullable
        {
            if (id == null)//this is if the user doesn't provide a ID# to delete
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = _db.Restaurants.Find(id);//finding restaurant in the database by its key id
            if(restaurant== null)//if restaurant doesn't exist in the data base
            {
                return HttpNotFound();
            }
            return View(restaurant);// if it does find what we looking for 
        }

        //POST: Restaurant/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)//Make sure it is nullable
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Method below

        //GET: Restaurant/Edit/{id}
        //get an id from the user
        //handle if the id is null
        //find a restaurant by that id
        //exceptions- if restaurant doens't exist
        //return the restaurant and the view if it does exist

        public ActionResult Edit(int? id)//Make sure it is nullable
        {
            if (id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant== null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }


        //POST: Restaurant/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;//find the entry on the table and excess its state and tell us it has been modified
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //Detail method below- it just needs get method and no need for post method since we just want detail

        //GET: Restaurant/Details/{id}
        public ActionResult Details(int? id)//Make sure it is nullable
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

    }
}