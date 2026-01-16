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
    public class BillBUS
    {
        private readonly BillDAL _billDAL;
        private readonly CafeContext _context;

        public BillBUS(BillDAL billDAL, CafeContext context)
        {
            _context = context;
            _billDAL = billDAL;
        }

        public int CreateBill(CreateBillRequest request)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                int idBill = _billDAL.CreateBill(request.IdTable, request.IdAccount);

                if(request.IdTable != null)
                {
                    var table = _context.Tablefoods.Find(request.IdTable);
                    if (table != null) table.Status = "Có người";
                    
                }   
                _context.SaveChanges();
                transaction.Commit();
                return idBill;
                

            }
            catch
            {
                transaction.Rollback();
                return -1; 
            }
        
        }

        public bool SwtichTable(SwitchTableRequest request)
        {
            using var transaction = _context.Database.BeginTransaction();
            try 
            {
                int idBill = _billDAL.GetUnpaidBillIdByTableId(request.IdTableOld);
                if (idBill == -1) return false;

                var tableNew= _context.Tablefoods.Find(request.IdTableNew);
                if (tableNew == null || tableNew.Status != "Trống") return false;

                bool success= _billDAL.UpdateBillTable(idBill, request.IdTableOld, request.IdTableNew);

                if (!success) throw new Exception("Lỗi cập nhật dữ liệu");
                transaction.Commit();
                return true;

            }
            catch
            {
                transaction.Rollback();
                return false;

            }
        
        }

        public bool Checkout(int idBill, CheckoutRequest request)
        {   

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var success= _billDAL.CheckoutBill(idBill, request.Discount, request.IdCustomer);

                if(!success) return false; ;

                var bill = _context.Bills.Find(idBill);
                if (bill?.Idtable != null)
                { 
                    var table = _context.Tablefoods.Find(bill.Idtable);
                    if (table != null)
                    { 
                        table.Status = "Trống";
                    }
                }
                _context.SaveChanges();
                transaction.Commit();
                return true;


            }
            catch
            {
                transaction.Rollback();
                return false;
            }

        }
       
        public int GetUnpaidBillId(int idTable)
        {
            
            return _billDAL.GetUnpaidBillIdByTableId(idTable);
        }

        public List<BillDetailDTO> GetBillDetail(int idBill)
        {
           
            return _billDAL.GetBillDetails(idBill); 
        }
    }
}
