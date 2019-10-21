using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMobile.Models
{
    public class Device
    {
        public int DeviceID { get; set; }
        
        [Required]
        public string Manufacture { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public float ScreenSize { get; set; }

        public int Memory { get; set; }

        public int RamMemory { get; set; }

        public int SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }
        public ICollection<CartItemDevice> CartItemDevice { get; set; }
        public int ViewCounter { get; set; } = 0;



    }
}
