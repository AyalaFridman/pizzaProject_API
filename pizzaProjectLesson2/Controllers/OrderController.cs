
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
             _order=order;
        }
        [HttpGet]
        public List<Order> Get()
        {
            return _order.Get();
        }
        [HttpPost]
        public ActionResult Post(Order o)
        {
            var orderList=_order.Get();
            o.Id=orderList.Last<Order>().Id+1;
             _order.AddOrder(o);
             return Ok();
        }
        // [HttpPost("postItem/{idPizza}/{amount}")]
        // public void PostItem(int idPizza,int amount)
        // {
        //     var orderList=_order.Get();
        //     System.Console.WriteLine("PostItem: "+_order.count);
        //     System.Console.WriteLine("last id: "+orderList.Last<Order>().Id);
        //     if(orderList.Last<Order>().Id<_order.count)
        //     {
        //     System.Console.WriteLine("in if");
        //         var o=new Order();
        //         o.Id=orderList.Last<Order>().Id+1;
        //     System.Console.WriteLine(o.Id);
        //         _order.AddOrder(o); 
        //         System.Console.WriteLine(o);
        //     }
        //      _order.AddPizzaToOrder(orderList.Last<Order>().Id,idPizza,amount);
        // }
    }
}
