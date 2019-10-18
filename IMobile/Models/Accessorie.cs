using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMobile.Models
{
    public class Accessorie
    {
        [Required]
        public int AccessorieID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacture { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }


        public string Description { get; set; }

        [Required]
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public ICollection<CartItemAcc> CartItemAcc { get; set; }

    }
}
