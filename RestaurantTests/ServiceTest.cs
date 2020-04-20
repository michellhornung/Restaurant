using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantService;

namespace RestaurantTests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void OrderTest()
        {
            string resultDishes = "";
            string expectedDisches = "";
            string expectedMessage = "";
            string resultMessage = "";

            Service service = new Service();
            Order order = new Order();

            // Test regular Night order with tem that can be repeated

            order = service.GetOrder("night", new string[] { "1", "2", "2", "3", "4"});
            resultDishes = string.Join(',', order.Dishes);
            expectedDisches = "Steak,Potato,Potato,Wine,Cake";
            Assert.AreEqual(expectedDisches, resultDishes, true, "Expected order not correct.");

            // Test regular Night order with serving time in mixed case

            order = service.GetOrder("NiGhT", new string[] { "1", "2", "3", "4" });
            resultDishes = string.Join(',', order.Dishes);
            expectedDisches = "Steak,Potato,Wine,Cake";
            Assert.AreEqual(expectedDisches, resultDishes, true, "Expected order not correct.");

            // Test not available serving time

            order = service.GetOrder("lunch", new string[] { "1", "2", "3" });
            resultMessage = order.Message;
            expectedMessage = "Serving times are Morning and Night.";
            Assert.AreEqual(expectedMessage, resultMessage, true, "Expected message notcorrect.");

            // Test order with unavailable item

            order = service.GetOrder("morning", new string[] { "1", "2", "3", "4", "3" });
            resultDishes = string.Join(',', order.Dishes);
            resultMessage = order.Message;
            expectedMessage = "Item 4 is not available.";
            expectedDisches = "Eggs,Toast,Cofee";
            Assert.AreEqual(expectedDisches, resultDishes, true, "Expected order not correct.");
            Assert.AreEqual(expectedMessage, resultMessage, true, "Expected message notcorrect.");

            // Test item that cannot be repeated

            order = service.GetOrder("morning", new string[] { "2", "1", "2", "3", "3" });
            resultDishes = string.Join(',', order.Dishes);
            resultMessage = order.Message;
            expectedDisches = "Eggs,Toast";
            expectedMessage = "Item 2 is limited to 1 per serving.";
            Assert.AreEqual(expectedDisches, resultDishes, true, "Expected order not correct.");
            Assert.AreEqual(expectedMessage, resultMessage, true, "Expected message notcorrect.");
        }
    }
}
