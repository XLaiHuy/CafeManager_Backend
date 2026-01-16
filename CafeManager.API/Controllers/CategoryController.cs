using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BUS.ProductCategoryBUS _productCategoryBUS;
        public CategoryController(BUS.ProductCategoryBUS productCategoryBUS)
        {
            _productCategoryBUS = productCategoryBUS;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllCategories()
        {
           return Ok( _productCategoryBUS.GetAllProductCategories());
        }

        [HttpPost("create")]
        public IActionResult CreateCategory([FromBody] DTO.ProductCategoryDTO input)
        {
            try
            {
                _productCategoryBUS.CreateProductCategory(input);
                return Ok(new { message = "Tạo danh mục thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateCategory(int id,[FromBody] DTO.ProductCategoryDTO input)
        {
            try
            {
                input.Id = id;
                _productCategoryBUS.Update(input);
                return Ok(new { message = "Cập nhật danh mục thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _productCategoryBUS.Delete(id);
                return Ok(new { message = "Xóa danh mục thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
