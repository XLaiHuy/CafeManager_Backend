using CafeManager.DAL;
using CafeManager.DAL.Models;
using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.BUS
{
    public class FoodBUS
    {
        private readonly FoodDAL _foodDal;
        private readonly ProductCategoryDAL _cateDal;
        public FoodBUS(FoodDAL foodDal, ProductCategoryDAL cateDal)
        {
            _foodDal = foodDal;
            _cateDal = cateDal;
        }
        public List<FoodDTO> getList()
        {
            return _foodDal.getList().Select(f => new FoodDTO
            {
                Id = f.Id,
                Name = f.Name,
                CategoryId= f.Idcategory,
                Price = (double)f.Price
            }).ToList();
        }
        public List<FoodDTO> GetFoodsByCategory(int idCategory)
        {
            return _foodDal.getListByCate(idCategory).Select(f => new FoodDTO
            {
                Id = f.Id,
                Name = f.Name,
                CategoryId = f.Idcategory,
                Price = (double)f.Price
            }).ToList();
        }
        public void createFood(FoodDTO input)
        {
            var existingFood = _foodDal.getByName(input.Name);
            if (existingFood != null)
            {
                throw new Exception("Món ăn đã tồn tại");
            }
            var category = _cateDal.getByID(input.CategoryId);
            if (category == null)
            {
                throw new Exception("Danh mục không tồn tại");
            }
            if (input.Price < 0) throw new Exception("Giá không được âm");
            _foodDal.Add(new Food
            {
                Name = input.Name,
                Idcategory = input.CategoryId,
                Price = (decimal)input.Price
            });
        }
        public void UpdateFood(FoodDTO input)
        {
            var food = _foodDal.getByID(input.Id);
            if (food == null)
            {
                throw new Exception("Món ăn không tồn tại");
            }
            var category = _cateDal.getByID(input.CategoryId);
            if (category == null)
            {
                throw new Exception("Danh mục không tồn tại");
            }
            if (!string.IsNullOrWhiteSpace(input.Name) && input.Name != "string")
            {
                var exists = _foodDal.getByName(input.Name);
                if (exists != null && exists.Id != input.Id) throw new Exception("Tên món đã trùng");
                food.Name = input.Name;
            }
            if (input.CategoryId> 0)
            {
                var cate = _cateDal.getByID(input.CategoryId);
                if (cate == null) throw new Exception("Danh mục mới không tồn tại");
                food.Idcategory= input.CategoryId;
            }
            if (input.Price < 0)
            {
                throw new Exception("Giá không được âm");
               
            }
            else { food.Price = (decimal)input.Price; }
               

            _foodDal.Update(food);
        }
        public void Delete(int id){
            var food = _foodDal.getByID(id);
            if (food == null) throw new Exception("Không tìm thấy món");
            _foodDal.Delete(food);
        }
    }
    }
   