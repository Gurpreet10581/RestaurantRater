using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant// this is being stored in the database created below
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int  Rating { get; set; }

    }


    public class RestaurantDbContext: DbContext//created a database and inheriting from just DbContext. This model is different then IdentityModels
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}