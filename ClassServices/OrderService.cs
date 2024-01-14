
using ClassModels;
using ClassInterface;
using FileService;
using System.Text;
using System.Text.Json;
namespace ClassServices
{
    public class OrderService:IOrder
    {
        public DateTime Date { get; set; }
        // public List<Order> Orders { get; set; }
        public OrderService(IFileService rw)
        {
            this.Date=DateTime.Now;
            // Orders = new List<Order>(); 
        }
         public string SendOrder(Order order)
        {
            var jsonOrder = JsonSerializer.Serialize<Order>(order);           
            return "the order was send succesfully!!  " + jsonOrder;
        }
        // public List<Order> AddOrder(Order o)
        // {
        //     Orders.Add(o);
        //     return Orders;
        // }
                // public List<Order> Get()
        // {
        //     System.Console.WriteLine( this.Date);
        //     return Orders;
        // }
    }
}
