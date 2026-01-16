using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class TableDTO
    {      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
