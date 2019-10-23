using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace IMobile.Models
{
    public class Branches
    {
        public int  ID { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


    }
}
