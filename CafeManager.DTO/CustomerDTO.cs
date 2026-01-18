using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CafeManager.DTO
{
    public class CustomerDTO
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
