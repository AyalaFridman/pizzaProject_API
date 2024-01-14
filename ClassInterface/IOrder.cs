using ClassModels;
namespace ClassInterface
{
    public interface IOrder
    {
        public DateTime Date { get; set; }
        public string SendOrder(Order order);
        // public List<Order> AddOrder(Order o);
    }
}
