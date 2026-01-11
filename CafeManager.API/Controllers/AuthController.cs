using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CafeManager.BUS;
using CafeManager.DTO;
using Microsoft.AspNetCore.Identity.Data;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]// thiết lập đường dẫn cơ sở 
    [ApiController] // đánh dấu lớp này là một API Controller

    public class AuthController : ControllerBase
    {
        private readonly AccountBUS _accountBUS;

        public AuthController(AccountBUS accountBUS)
        {
           _accountBUS = accountBUS;
        }
        public class LoginRequest
        {
            public  string Username { get; set; }
            public string Password { get; set; }
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = _accountBUS.Login(request.Username, request.Password);

            if(result== null)
                return Unauthorized(new { message = "Invalid username or password" });
            return Ok(result);
        }

       
    }
}
