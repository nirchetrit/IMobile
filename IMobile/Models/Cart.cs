using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMobile.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserID { get; set; }
        public ICollection<CartItemAcc> AccList { get; set; }
        public ICollection<CartItemDevice> DeviceList { get; set; }
    }
}
