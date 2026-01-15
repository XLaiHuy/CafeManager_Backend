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
        public IActionResult AddFood([FromBody] AddBillInfoRequest request)
        {
            bool result = _infoBUS.AddFoodToBill(request);
            if (!result) return BadRequest("Không thể thêm món vào hóa đơn");
            return Ok("Thêm món vào hóa đơn thành công");

        }
    }
}
