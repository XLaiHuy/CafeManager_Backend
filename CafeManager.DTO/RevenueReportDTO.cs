using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class RevenueReportDTO
    {
        public int IdBill { get; set; }
        public string TableName { get; set; }   
        public DateTime DateCheckIn { get; set; }

        public int Discount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
