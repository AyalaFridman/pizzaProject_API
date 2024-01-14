
using Microsoft.AspNetCore.Mvc;
using ClassInterface;
using ClassModels;
namespace pizzaProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        
        private IOrder _order;
        public OrderController(IOrder order)
        {
          _order = order;
        }
    [HttpPost]
    [Route("{order}")]
    public string SendOrder(Order order)
    {
        System.Console.WriteLine( "order: "+_order.Date);
        return _order.SendOrder(order);
    }
        // [HttpGet]
        // public void GetOrder()
        // {
        //      System.Console.WriteLine( "order: "+MyOrder.Date);
        // }
        // public List<Order> GetOrder()
        // {
        //      System.Console.WriteLine( "order: "+MyOrder.Date);
        //     return MyOrder.Get();
        // }
        // [HttpPost("CustomerId/{CustomerId}/TotalAmount/{TotalAmount}/Items/{ Items}")]
        // public List<Order> Post(int CustomerId, int totalAmount, List<Pizza> Items)
        // {
        //     var order = new Order() { CustomerId = CustomerId, TotalAmount = totalAmount, Items = Items};
        //     return MyOrder.AddOrder(order);
        // }
    }
}
