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

        public List<BillDetailDTO> AddAndReload(int idBill, int idFood, int count, decimal price)
        { 
            bool isAdded = _infoDAL.AddOrUpdateBillInfo(idBill, idFood, count, price);
            if (isAdded)
            {
                return _context.Billinfos.
                    Where(bi => bi.Idbill == idBill)
                    .Select(bi => new BillDetailDTO
                    {
                        FoodName = bi.IdfoodNavigation.Name,
                        Count = bi.Count,
                        Price = bi.Priceatsale
                    }).ToList();   
            }
            return new List<BillDetailDTO>();
        }
    }
}
