using Auth.Models.DTO;
using Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/auth")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]

    public class AuthController : Controller
    {
        IUserService userService { get; set; }
        public AuthController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody] UserDto model)
        {
            return await userService.Login(model.Username, model.Password);
        }
    }
}
