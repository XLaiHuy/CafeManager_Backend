using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public  class CreateBillRequest
    {
        public int? IdTable { get; set; }
        public int IdAccount { get; set; }  
    }
}
