using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantService;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        [HttpGet("{order}")]
        public Order Get(string order)
        {
            Service service = new Service();
            string servingTyme = OrderToArray(order)[0];
            string[] dishes = OrderToArray(order).Where(x => x != servingTyme && !string.IsNullOrEmpty(x)).ToArray();
            Order preparedOrder = service.GetOrder(servingTyme, dishes);
            preparedOrder.Dishes = GroupDishes(preparedOrder.Dishes);
            return preparedOrder;
        }

        private string[] OrderToArray(string order)
        {
            return order.Split(',');
        }

        private string[] GroupDishes(string[] dishes)
        {
            var grouped = dishes.GroupBy(i => i);
            List<string> result = new List<string>();
            foreach (var item in grouped)
            {
                int q = item.Count();
                string s = item.Count() == 1 ? item.Key : item.Key + "(x" + item.Count() + ")";
                result.Add(s);
            }
            return result.ToArray();
        }
    }
}