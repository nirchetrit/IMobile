using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMobile.Models
{
    public class CartItemDevice
    {
        public int CartItemDeviceID { get; set; }
        public int DeviceID { get; set; }
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Device Device { get; set; }
        public int Quantity { get; set; }

    }
}
