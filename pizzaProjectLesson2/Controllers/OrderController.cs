
using Microsoft.AspNetCore.Mvc;
using ClassInterface;
using ClassModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy="Worker")]
        public List<Order> Get()
        {
            return _order.Get();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Policy="Worker")]
        public ActionResult Delete(int id)
        {
            _order.Delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult Post(Order o)
        {
            var orderList=_order.Get();
            o.Id=orderList.Last<Order>().Id+1;
            o.Date=_order.Date;
             _order.AddOrder(o);
             return Ok();
        }

    }
}
