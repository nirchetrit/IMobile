using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMobile.Models
{
    public class CartItemAcc
    {
        public int CartItemAccID { get; set; }
        public int AccessorieID { get; set; }
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Accessorie Accessorie { get; set; }
        public int Quantity { get; set; }
    }
}
