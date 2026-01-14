using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class CheckoutRequest
    {
        public int Discount { get; set; } 
        public int? IdCustomer { get; set; }

    }
}
