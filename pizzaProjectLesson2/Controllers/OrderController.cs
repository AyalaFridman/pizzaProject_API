
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
        [HttpPut]
        public void Put(Order o)
        {
            // var orderList=_order.Get();
            // o.Id=orderList.Last<Order>().Id+1;
            _order.UpDateOrder(o);
        }
        [HttpPost("postItem/{idOrder}/{idPizza}/{amount}")]
        public void PostItem(int idOrder,int idPizza,int amount)
        {
            var orderList=_order.Get();
            if(orderList.Last<Order>().Id<idOrder)
            {
                var o=new Order();
                o.Id=orderList.Last<Order>().Id+1;
                _order.AddOrder(o); 
            }
             _order.AddPizzaToOrder(idOrder,idPizza,amount);
        }
    }
}
