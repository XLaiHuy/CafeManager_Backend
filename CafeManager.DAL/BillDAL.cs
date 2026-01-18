using CafeManager.DAL.Models;
using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAL
{
    public class BillDAL
    {
        private readonly CafeContext _context;

        public BillDAL(CafeContext context)
        {
            _context = context;
        }

        public int GetUnpaidBillIdByTableId(int tableId) // tìm hóa đơn chưa thanh toán của 1 bàn
        {
            var bill = _context.Bills.FirstOrDefault(b => b.Idtable == tableId && b.Status == 0 && b.Isdeleted == false);
            return bill?.Id ?? -1;
        }

        public int CreateBill(int? idTable, int idAccount)
        {
            var newBill = new Bill
            {
                Idtable = idTable,
                Idaccount=idAccount,
                Datecheckin= DateTime.Now,
                Status=0,
                Discount=0,
                Isdeleted= false

            };
            _context.Bills.Add(newBill);
            _context.SaveChanges();
            return newBill.Id;
        }
        
        public List<BillDetailDTO> GetBillDetails(int idBill)
        {
            var query = from bi in _context.Billinfos
                        join f in _context.Foods on bi.Idfood equals f.Id
                        where bi.Idbill == idBill
                        select new BillDetailDTO
                        {
                            FoodName = f.Name,
                            Count = bi.Count,
                            Price = bi.Priceatsale
                        };
            return query.ToList();
        }

        public bool UpdateBillTable(int idBill,int idOldTable ,int idNewTable)
        {
            var bill = _context.Bills.Find(idBill);
            var tableOld= _context.Tablefoods.Find(idOldTable);
            var tableNew= _context.Tablefoods.Find(idNewTable);

            if (bill == null || tableOld == null || tableNew == null)
                return false;

            bill.Idtable = idNewTable;
            tableOld.Status = "Trống";
            tableNew.Status = "Có người";
            return _context.SaveChanges() > 0;
        }


        public bool CheckoutBill(int idBill, int discount, int? idCustomer)
        {
            var bill = _context.Bills.Find(idBill);
            if (bill == null) return false;

            bill.Status = 1;
            bill.Discount= discount;
            bill.Datecheckin = DateTime.Now;
            if (idCustomer == 0) bill.Idcustomer = null;
            else bill.Idcustomer = idCustomer;
            return true;
        
        }

    }
}
