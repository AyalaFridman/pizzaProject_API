
using Microsoft.AspNetCore.Mvc;
using  LoginService;
using System.IdentityModel.Tokens.Jwt;
namespace pizzaProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private  ILogin _ids;

        public LoginController(ILogin identityService)
        {
            _ids = identityService;
        }
        [HttpPost("{name}/{password}")]
        public ActionResult<string> Login(string name,string password)
        {
            var token=_ids.Login(name,password);
            if(token==null)
            {
               throw new UnauthorizedAccessException("Unauthorized");
            }

            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}