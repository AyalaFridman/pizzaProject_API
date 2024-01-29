using Microsoft.AspNetCore.Mvc;
using ClassModels;
using ClassInterface;
using Microsoft.AspNetCore.Authorization;

// using System.ComponentModel.DataAnnotation;
namespace pizzaProject.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private IPizza _pizza;
        public PizzaController(IPizza myPizza)
        {
            _pizza=myPizza;
        }
        [HttpGet]
        public List<Pizza> Get()
        {
            return _pizza.Get();
        }
        [HttpGet("GetById/{id}")]
        
        public ActionResult<Pizza> GetByID(int id)
        {
            var Pizza = _pizza.GetById(id);
            if (Pizza==null)
            {
                return NotFound();
            }
            return Pizza;

        }
        [HttpPost]
        [Authorize(Policy="Worker")]
        public ActionResult Post(Pizza p)
        {
            var pizzaList=_pizza.Get();
            Console.Write(pizzaList.Count());
            p.Id=pizzaList.Last<Pizza>().Id+1;
             _pizza.AddPizza(p);
             return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Policy="Worker")]
        public ActionResult Put(int id,Pizza p)
        {
            var pizza= _pizza.UpDate(id, p);
            if (pizza==false)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Policy="Worker")]
        public ActionResult Delete(int id)
        {
            _pizza.Delete(id);
            return Ok();
        }



    }
}