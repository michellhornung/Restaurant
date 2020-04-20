using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantModels
{
    public class Menu : IMenu
    {
        private List<Meal> Meals { get; set; }

        public Menu()
        {
            SetMenu();
        }

        public void SetMenu()
        {
            Meal meal;
            Meals = new List<Meal>();

            meal = new Meal
            {
                Dish = new Dish
                {
                    Type = new DishType
                    {
                        Id = 1,
                        Name = "Entrée"
                    },
                    Name = "Eggs",
                },
                ServingTime = "Morning",
                Multiple = false
            };

            Meals.Add(meal);

            meal = new Meal
            {
                Dish = new Dish
                {
                    Type = new DishType
                    {
                        Id = 1,
                        Name = "Entrée"
                    },
                    Name = "Steak",
                },
                ServingTime = "Night",
                Multiple = false
            };

            Meals.Add(meal);

            meal = new Meal
            {
                Dish = new Dish
                {
                    Type = new DishType
                    {
                        Id = 2,
                        Name = "Side"
                    },
                    Name = "Toast",
                },
                ServingTime = "Morning",
                Multiple = false
            };

            Meals.Add(meal);

            meal = new Meal
            {
                Dish = new Dish
                {
                    Type = new DishType
                    {
                        Id = 2,
                        Name = "Side"
                    },
                    Name = "Potato",
                },
                ServingTime = "Night",
                Multiple = true
            };

            Meals.Add(meal);

            meal = new Meal
            {
                Dish = new Dish
                {
                    Type = new DishType
                    {
                        Id = 3,
                        Name = "Drink"
                    },
                    Name = "Cofee",
                },
                ServingTime = "Morning",
                Multiple = true
            };

            Meals.Add(meal);

            meal = new Meal
            {
                Dish = new Dish
                {
                    Type = new DishType
                    {
                        Id = 3,
                        Name = "Drink"
                    },
                    Name = "Wine",
                },
                ServingTime = "Night",
                Multiple = false
            };

            Meals.Add(meal);

            meal = new Meal
            {
                Dish = new Dish
                {
                    Type = new DishType
                    {
                        Id = 4,
                        Name = "Dessert"
                    },
                    Name = "Cake",
                },
                ServingTime = "Night",
                Multiple = false
            };

            Meals.Add(meal);
        }

        public List<Meal> GetMenu()
        {
            return Meals;
        }
    }
}
