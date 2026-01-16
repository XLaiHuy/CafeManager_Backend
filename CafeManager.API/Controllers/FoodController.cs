using CafeManager.BUS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodBUS _bus;
        public FoodController(FoodBUS bus)
        {
            _bus = bus;
        }

        [HttpGet("category/{idCategory}")]
        public IActionResult GetFoodsByCategory(int idCategory)
        {
            try
            {
                var foods = _bus.GetFoodsByCategory(idCategory);
                return Ok(foods);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("add")]
        public IActionResult CreateFood([FromBody] DTO.FoodDTO input)
        {
            try
            {
                _bus.createFood(input);
                return Ok(new { message = "Tạo món ăn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteFood(int id)
        {
            try
            {
                _bus.Delete(id);
                return Ok(new { message = "Xóa món ăn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("update{idc}")]
        public IActionResult UpdateFood(int idc,[FromBody] DTO.FoodDTO input)
        {
            try
            {
                input.Id = idc;
                _bus.UpdateFood(input);
                return Ok(new { message = "Cập nhật món ăn thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
