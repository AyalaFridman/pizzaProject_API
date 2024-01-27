
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
        public void Post(Order o)
        {
            _order.AddOrder(o);
        }
        [HttpPost("postItem/{idOrder}/{idPizza}/{amount}")]
        public void PostItem(int idOrder,int idPizza,int amount)
        {
             _order.AddPizzaToOrder(idOrder,idPizza,amount);
        }
    }
}
