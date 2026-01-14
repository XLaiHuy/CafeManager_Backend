using CafeManager.BUS;
using CafeManager.DAL;
using CafeManager.DAL.Models;
using CafeManager.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillBUS _billBUS;
        
        public BillController(BillBUS billBUS)
        {
            _billBUS = billBUS;
        }

        [HttpPost]
        public IActionResult CreateBill([FromBody] CreateBillRequest request)
        { 
            int idBill=_billBUS.CreateBill(request);
            if(idBill==-1) return BadRequest("Cannot create bill");
            return Ok(idBill);
        }

        [HttpGet("unpaid/{idTable}")]
        public IActionResult GetUnpaid(int idTable) 
        {
            int idBill=_billBUS.GetUnpaidBillId(idTable);
            return Ok(idBill);
        }


        [HttpGet("detail/{idBill}")]
        public IActionResult GetBillDetail(int idBill)
        { 
            var details=_billBUS.GetBillDetail(idBill);
            return Ok(details);
        
        }

        [HttpPost("switch-table")]
        public IActionResult SwitchTable([FromBody] SwitchTableRequest request)
        {
            bool result = _billBUS.SwtichTable(request);
            if (!result) return BadRequest("Cannot switch table");
            return Ok("Chuyển bàn thành công");
        }

        [HttpPost("checkout/{idBill}")]
        public IActionResult Checkout(int idBill, [FromBody] CheckoutRequest request)
        { 
            bool result=_billBUS.Checkout(idBill, request);
            if(!result) return BadRequest("Cannot checkout");
            return Ok("Thanh toán thành công");
        }
    }
}
