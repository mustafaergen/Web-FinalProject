using FinalProject_Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Entities.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public  ProductCreateDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
