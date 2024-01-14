using Microsoft.AspNetCore.Mvc;
using ClassModels;
using ClassInterface;
using Microsoft.AspNetCore.Authorization;

// using System.ComponentModel.DataAnnotation;
namespace pizzaProject.Controllers;
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
        [Authorize(Policy = "Admin")]
        public ActionResult Post(Pizza p)
        {
             _pizza.AddPizza(p);
             return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
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
        [Authorize(Policy = "Admin")]
        public ActionResult Delete(int id)
        {
            _pizza.Delete(id);
            return Ok();
        }



    }
