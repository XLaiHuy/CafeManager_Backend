using CafeManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAL
{
    public class ProductCategoryDAL
    {
        private readonly CafeContext _context;
        public ProductCategoryDAL(CafeContext context)
        {
            _context = context;
        }
        public List<Productcategory> GetAllProductCategories()
        {
            return _context.Productcategories.Where(c => c.Isdeleted == false).ToList();
        }
        public Productcategory getByID(int id){ 
            return _context.Productcategories.FirstOrDefault(c => c.Id == id && c.Isdeleted == false);
        }
        public Productcategory getByName(string name)
        {
            string trimmedName = name.Trim();
            return _context.Productcategories.FirstOrDefault(c => c.Name.ToLower() == trimmedName.ToLower() && c.Isdeleted == false);
        }
        public void AddProductCategory(Productcategory category)
        {
            _context.Productcategories.Add(category);
            _context.SaveChanges();
        }
        public void UpdateProductCategory(Productcategory category)
        {
            _context.Productcategories.Update(category);
            _context.SaveChanges();
        }
        public void DeleteProductCategory(Productcategory category)
        {
            category.Isdeleted = true;
            _context.Productcategories.Update(category);
            _context.SaveChanges();
        }

    }
}
