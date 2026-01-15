using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class AddBillInfoRequest
    {
        public int IdBill { get; set; } 
        public int idFood { get; set; } 

        public int Count { get; set; }  
    }
}
