using CafeManager.BUS;
using CafeManager.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillInfoController : ControllerBase
    {
        private readonly BillInfoBUS _infoBUS;

        public BillInfoController(BillInfoBUS infoBUS)
        {
            _infoBUS = infoBUS;
        }

        [HttpPost]
        public IActionResult AddFoodToBill([FromBody] AddBillInfoRequest request)
        {
          var updatedList= _infoBUS.AddAndReload(
            request.IdBill,
            request.idFood,
            request.Count,
            request.Price);

            if(updatedList != null)
            {
                return Ok(updatedList);
            }
            else
            {
                return BadRequest("Failed to add food to bill.");
            }

        }

    }
}
