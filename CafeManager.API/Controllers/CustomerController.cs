using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CafeManager.BUS;
using CafeManager.DTO;
namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerBUS _customerBus;
        public CustomerController(CustomerBUS customerBUS)
        {
            _customerBus = customerBUS;
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string phone)
        {
            return Ok(_customerBus.SearchCustomer(phone));
        }
        [HttpPost("add")]
        public IActionResult AddCustomer([FromBody] CustomerDTO input)
        {
            try
            {
                var newCustomer = _customerBus.CreateCustomer(input);
                return Ok(newCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
