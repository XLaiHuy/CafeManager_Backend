using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public  class SwitchTableRequest
    {
        public int IdTableOld { get; set; } 
        public int IdTableNew { get; set; }
    }
}
