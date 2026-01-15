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
    public class BillInfoBUS
    {
        private readonly BillInfoDAL _infoDAL;
        private readonly CafeContext _context;

        public BillInfoBUS(CafeContext context, BillInfoDAL infoDAL)
        { 
            _context= context;
            _infoDAL= infoDAL;
        }

        public bool AddFoodToBill(AddBillInfoRequest request)
        { 
            var food=_context.Foods.FirstOrDefault(f => f.Id == request.idFood);
            if (food == null) return false;
            return _infoDAL.AddOrUpdateBillInfo(request.IdBill, request.idFood, request.Count, food.Price);

        }

    }
}
