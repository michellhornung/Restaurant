using RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantService
{
    public class Service : IService
    {
        public static List<Meal> meals = new Menu().GetMenu();

        public Order GetOrder(string servingTime, string[] order)
        {
            List<Dish> dishes = new List<Dish>();
            string message = "";
            List<Meal> orderItems = meals.Where(x => x.ServingTime.ToUpper().Equals(servingTime.ToUpper())).ToList();

            if (orderItems.Count == 0)
            {
                return ReturnOrder(new List<Dish> { }, "Serving times are Morning and Night.");
            }

            foreach (string s in order)
            {
                Dish dish = orderItems.Where(x => x.Dish.Type.Id.ToString().Equals(s)).Select(x => x.Dish).FirstOrDefault();
                bool isNotLimitedToOne = orderItems.Where(x => x.Dish.Type.Id.ToString().Equals(s)).Select(x => x.Multiple).FirstOrDefault();

                if (dish != null)
                {
                    if (!dishes.Contains(dish) || (dishes.Contains(dish) && isNotLimitedToOne))
                    {
                        dishes.Add(dish);
                    }
                    else
                    {
                        message = "Item " + s + " is limited to 1 per serving.";
                        return ReturnOrder(dishes, message);
                    }
                }
                else
                {
                    message = "Item " + s + " is not available.";
                    return ReturnOrder(dishes, message);
                }
            }

            return ReturnOrder(dishes, "");
        }

        private Order ReturnOrder(List<Dish> dishes, string message)
        {
            dishes = dishes.OrderBy(x => x.Type.Id).ToList();
            return new Order
            {
                Dishes = dishes.Select(x => x.Name).ToArray(),
                Message = message
            };
        }
    }
}
