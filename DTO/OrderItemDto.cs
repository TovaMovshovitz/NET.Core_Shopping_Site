using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderItemDto
    {
       
        //public string? ProuctName { get; set; }
        public int ProuctId { get; set; }
        public int Quantity { get; set; }

        
    }
}
