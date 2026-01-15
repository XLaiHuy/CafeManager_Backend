using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace CafeManager.BUS
{
    public class ProductCategoryBUS
    {
        private readonly DAL.ProductCategoryDAL _productCategoryDAL;
        public ProductCategoryBUS(DAL.ProductCategoryDAL productCategoryDAL)
        {
            _productCategoryDAL = productCategoryDAL;
        }
        public List<ProductCategoryDTO> GetAllProductCategories()
        {
          return _productCategoryDAL.GetAllProductCategories().Select(c=>new ProductCategoryDTO{
                Id = c.Id,
                Name = c.Name
        }).ToList();
        }
        public void CreateProductCategory(ProductCategoryDTO input)
        {
            var existing = _productCategoryDAL.getByName(input.Name);
            if (existing != null)
            {
                throw new Exception("Tên danh mục này đã tồn tại!");
            }
            var category = new DAL.Models.Productcategory
            {
                Name = input.Name,
                Isdeleted = false
            };
            _productCategoryDAL.AddProductCategory(category);
        }
        public void Update(ProductCategoryDTO input)
        {
            var cat = _productCategoryDAL.getByID(input.Id);
            if (cat == null) throw new Exception("Danh mục không tồn tại");

            if (!string.IsNullOrWhiteSpace(input.Name) && input.Name != "string")
            {
                var exists = _productCategoryDAL.getByName(input.Name);
                if (exists != null && exists.Id != input.Id) throw new Exception("Tên đã trùng");
                cat.Name = input.Name;
            }
            _productCategoryDAL.UpdateProductCategory(cat);
        }
        public void Delete(int id)
        {
            var cat = _productCategoryDAL.getByID(id);
            if (cat == null) throw new Exception("Danh mục không tồn tại");
            _productCategoryDAL.DeleteProductCategory(cat);
        }
    }
}
