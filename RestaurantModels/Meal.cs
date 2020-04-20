using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantModels
{
    public class Meal
    {
        public Dish Dish {get; set;}
        public string ServingTime { get; set; }
        public bool Multiple { get; set; }
    }
}
