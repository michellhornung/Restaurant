namespace RestaurantService
{
    public interface IService
    {
        Order GetOrder(string servingTime, string[] order);
    }
}