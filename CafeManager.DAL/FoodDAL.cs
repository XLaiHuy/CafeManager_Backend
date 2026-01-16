using CafeManager.DAL.Models;
using CafeManager.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CafeManager.DAL
{
    public class FoodDAL
    {
        private readonly CafeContext _context;
        public FoodDAL(CafeContext context) => _context = context;
        public List<Food> getList()
        {
            return  _context.Foods.Where(f => f.Isdeleted == false).ToList();
        }
        public List<Food> getListByCate(int idc)
        {
            return _context.Foods
                .Where(f => f.Idcategory == idc && f.Isdeleted == false)
                .ToList();
         }
        public Food getByName(string name)
        {
            string trimmedName = name.Trim();
            return _context.Foods.FirstOrDefault(f => f.Name.ToLower() == trimmedName.ToLower() && f.Isdeleted == false);
        }
        public Food getByID(int id)
        {
            return _context.Foods.FirstOrDefault(f => f.Id == id && f.Isdeleted == false);
        }
        public void Add(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }
        public void Update(Food food)
        {
            _context.Foods.Update(food);
            _context.SaveChanges();
        }
        public void Delete(Food food)
        {
            food.Isdeleted = true;
            _context.Foods.Update(food);
            _context.SaveChanges();
        }
    }
    }
