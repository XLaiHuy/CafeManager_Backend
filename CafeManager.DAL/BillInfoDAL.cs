using CafeManager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAL
{
    public class BillInfoDAL
    {
        private readonly CafeContext _context;
        public BillInfoDAL(CafeContext context)
        {
            _context = context;
        }

        public bool AddOrUpdateBillInfo(int idBill, int idFood, int count, decimal priceAtSale)
        {
            var info = _context.Billinfos.FirstOrDefault(bi => bi.Idbill == idBill && bi.Idfood == idFood);
            if (info != null)
            {
                info.Count += count;
                if (info.Count <= 0)
                    _context.Billinfos.Remove(info);
            }
            else if (count > 0)
            { 
                var newInfo= new Billinfo
                {
                    Idbill = idBill,
                    Idfood = idFood,
                    Count = count,
                    Priceatsale = priceAtSale
                };
                _context.Billinfos.Add(newInfo);
            }
            return _context.SaveChanges() > 0;

        }


    }
}
