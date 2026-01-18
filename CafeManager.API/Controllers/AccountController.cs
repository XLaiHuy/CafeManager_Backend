using CafeManager.BUS;
using CafeManager.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountBUS _accountBUS;
        public AccountController(AccountBUS accountBUS)
        {
            _accountBUS = accountBUS;
        }
        [HttpPost("create")]
        public IActionResult createAccount([FromBody] AccountInputDTO input)
        {
            try
            {
                _accountBUS.createAccount(input);
                return Ok(new { message = "Account created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult deleteAccount(int id)
        {
            try
            {
                _accountBUS.deleteAccount(id);
                return Ok(new { message = "Account deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult updateAccount(int id,[FromBody] AccountInputDTO input)
        {
            input.Id = id;
            try
            {
                _accountBUS.updateAccount(input);
                return Ok(new { message = "Account updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("list")]
        public IActionResult getAccounts()
        {

            return Ok(_accountBUS.GetAccount1());
        }

    }
}
