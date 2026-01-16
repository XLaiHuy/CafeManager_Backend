using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly BUS.TableBUS _tableBus;
         public TableController(BUS.TableBUS tableBUS)
        {
            _tableBus = tableBUS;
        }

        [HttpGet("getlist")]
        public IActionResult GetListTables()
        {
            return Ok(_tableBus.GetListTables());   
        }
        [HttpPost("create")]
        public IActionResult CreateTable([FromBody] DTO.TableDTO input)
        {
            try
            {
                _tableBus.createTable(input);
                return Ok(new { message = "Tạo bàn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTable(int id)
        {
            try
            {
                _tableBus.DeleteTable(id);
                return Ok(new { message = "Xóa bàn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateTable(int id,[FromBody] DTO.TableDTO input)
        {
            try
            {   
                input.Id = id;
                _tableBus.UpdateTable(input);
                return Ok(new { message = "Cập nhật bàn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
