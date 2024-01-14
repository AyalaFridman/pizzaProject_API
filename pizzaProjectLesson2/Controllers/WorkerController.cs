using Microsoft.AspNetCore.Mvc;
using ClassModels;
using ClassInterface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
// using Polly;

namespace pizzaProject.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private IWorker _worker;
        public WorkerController(IWorker MyWorker)
        {
             _worker=MyWorker;
        }
        [HttpGet]
        public List<Worker> Get()
        {
            return _worker.Get();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Policy = "supperWorker")]
        public ActionResult Delete(int id)
        {
            if (_worker.Delete(id) == null)
            {
                return NotFound();
            }
            _worker.Delete(id);
             return Ok();
        }
        [HttpPost]
        [Authorize(Policy = "admin")]
            public void Post(Worker w)
            {
            //  string r=_worker.printRole(w);
                 _worker.AddWorker(w);
            }

        }
}
