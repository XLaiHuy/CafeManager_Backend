using CafeManager.DAL.Models;
using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAL
{
    public class ReportDAL
    {
        private readonly CafeContext _context;
        public ReportDAL(CafeContext context)
        {
            _context = context;
        }

        public List<RevenueReportDTO> GetRevenue(DateTime fromDate, DateTime toDate)
        { 
            var query= from b in _context.Bills
                       join t in _context.Tablefoods on b.Idtable equals t.Id
                       where b.Status==1 && b.Datecheckin >= fromDate && b.Datecheckin <= toDate
                       select new RevenueReportDTO
                       {
                           IdBill = b.Id,
                           TableName = t.Name,
                           DateCheckIn = b.Datecheckin,
                           Discount = b.Discount??0,
                           TotalPrice= _context.Billinfos.
                           Where(bi => bi.Idbill==b.Id).Sum(bi => bi.Count * bi.Priceatsale)*(100 -(b.Discount??0)) /100
                       };   

            return query.ToList();
        }

    }
}
