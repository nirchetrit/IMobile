using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMobile.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Accessorie> AccList { get; set; }
        public ICollection<Device> DeviceList { get; set; }

    }
}
