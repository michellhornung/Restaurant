using System.Collections.Generic;

namespace RestaurantModels
{
    public interface IMenu
    {
        List<Meal> GetMenu();
        void SetMenu();
    }
}