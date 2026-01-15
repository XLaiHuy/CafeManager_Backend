using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.BUS
{
    public class ReportBUS
    {
        private readonly DAL.ReportDAL _reportDAL;
        public ReportBUS(DAL.ReportDAL reportDAL)
        {
            _reportDAL = reportDAL;
        }
        public List<DTO.RevenueReportDTO> GetRevenue(DateTime fromDate, DateTime toDate)
        {
              var startDate= fromDate.Date;
              var endDate= toDate.Date.AddDays(1).AddTicks(-1);
              return _reportDAL.GetRevenue(startDate, endDate);
        }
    }
}
