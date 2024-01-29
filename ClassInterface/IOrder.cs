using ClassModels;
namespace ClassInterface
{
    public interface IOrder
    {
        public DateTime Date { get; set; }
        // public void UpDateOrder(Order o);
        public List<Order> Get();
        public void AddOrder(Order o);
        List<Order>? Delete(int id) ;

        // public void AddPizzaToOrder(int idOrder,int idPizza,int amount);

    }
}
