using ClassModels;
namespace ClassInterface
{
    public interface IOrder
    {
        public DateTime Date { get; set; }
        public void UpDateOrder(Order o);
        public List<Order> Get();
        public void AddOrder(Order o);
        public void AddPizzaToOrder(int idOrder,int idPizza,int amount);

    }
}
