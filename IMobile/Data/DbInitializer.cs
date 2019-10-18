using IMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMobile.Data
{
    public class DbInitializer
    {
        public static void Initialize(IMobileContext context)
        {
            context.Database.EnsureCreated();
            
             // Look for any students.
             if (context.Device.Any())
             {
                 return;   // DB has been seeded
             }

            var acc = new Accessorie[]
           {
           new Accessorie{Manufacture="Apple", Name="Charger", Price=90,SupplierID=2},
           new Accessorie{Manufacture="Samsung", Name="Charger", Price=70,SupplierID=4},
           new Accessorie{Manufacture="Xiaomi", Name="Charger", Price=40,SupplierID=1},


           };
            foreach (Accessorie s in acc)
            {
                context.Accessorie.Add(s);
            }
            context.SaveChanges();



            
           var suppliers = new Supplier[]
           {
           new Supplier{ Name= "Nir"},
           new Supplier{ Name= "Ido"},
           new Supplier{ Name= "Tal"},
           new Supplier{ Name= "Or"},
           };
           foreach (Supplier s in suppliers)
           {
               context.Supplier.Add(s);
           }
           context.SaveChanges();

           var devices = new Device[]
           {
           new Device{Manufacture="Samsung", Name="Galaxy s10", Memory=128, RamMemory=6, ScreenSize= 5.8F, Price=3200, SupplierID=1},
           new Device{Manufacture="Samsung", Name="Galaxy s9", Memory=128, RamMemory=6, ScreenSize= 5.8F, Price=2800, SupplierID=1 },
           new Device{Manufacture="Samsung", Name="Galaxy s10", Memory=64, RamMemory=6, ScreenSize= 5.8F, Price=3000, SupplierID=1},
           new Device{Manufacture="Samsung", Name="Galaxy s9", Memory=64, RamMemory=6, ScreenSize= 5.8F, Price=2600, SupplierID=1},
           new Device{Manufacture="Apple", Name="Iphone 10", Memory=64, RamMemory=6, ScreenSize= 5.8F, Price=5000, SupplierID=2},
           new Device{Manufacture="Apple", Name="Iphone 9", Memory=64, RamMemory=6, ScreenSize= 5.8F, Price=4600, SupplierID=2},
           new Device{Manufacture="Apple", Name="Iphone 8", Memory=64, RamMemory=6, ScreenSize= 5.8F, Price=4000, SupplierID=2},
           new Device{Manufacture="Google", Name="Pixel 3", Memory=64, RamMemory=4, ScreenSize= 5.8F, Price=2500, SupplierID=2},
           new Device{Manufacture="Google", Name="Pixel 2", Memory=64, RamMemory=4, ScreenSize= 5.8F, Price=2000, SupplierID=2},
           new Device{Manufacture="Google", Name="Pixel 3L", Memory=64, RamMemory=4, ScreenSize= 6.2F, Price=2700, SupplierID=2},
           new Device{Manufacture="Xiaomi", Name="Mi 9", Memory=64, RamMemory=6, ScreenSize= 6.2F, Price=1600, SupplierID=1},
           new Device{Manufacture="Xiaomi", Name="Mi 8", Memory=64, RamMemory=6, ScreenSize= 6.2F, Price=1300, SupplierID=1},
           new Device{Manufacture="Xiaomi", Name="Mi 6", Memory=64, RamMemory=6, ScreenSize= 6.2F, Price=1000, SupplierID=1},

           };
           foreach (Device s in devices)
           {
               context.Device.Add(s);
           }
           context.SaveChanges();
            

            var cart = new Cart[]
            {
                new Cart{UserID=1}
         
            };
           
            foreach (Cart s in cart)
            {
                context.Cart.Add(s);
            }
            context.SaveChanges();



            var cartitemdevice = new CartItemDevice[]
            {
            new CartItemDevice{CartID=1, DeviceID=2,Quantity=1},
            new CartItemDevice{CartID=1, DeviceID=3,Quantity=1},
            new CartItemDevice{CartID=1, DeviceID=4,Quantity=1},
            new CartItemDevice{CartID=1, DeviceID=5,Quantity=1},
            new CartItemDevice{CartID=1, DeviceID=6,Quantity=1},
            new CartItemDevice{CartID=1, DeviceID=7,Quantity=4},
            new CartItemDevice{CartID=1, DeviceID=8,Quantity=3},
            new CartItemDevice{CartID=1, DeviceID=9,Quantity=1},
            };

            foreach (CartItemDevice s in cartitemdevice)
            {
                context.CartItemDevice.Add(s);
            }
            context.SaveChanges();
        }
    }
}
