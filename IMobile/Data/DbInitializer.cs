using IMobile.Models;
using Microsoft.AspNetCore.Identity;
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

            var acc = new Accessorie[]
           {
           new Accessorie{Manufacture="Apple", Name="Charger", Price=90,SupplierID=2},
           new Accessorie{Manufacture="Samsung", Name="Charger", Price=70,SupplierID=4},
           new Accessorie{Manufacture="Xiaomi", Name="Charger", Price=40,SupplierID=1},
           new Accessorie{Manufacture="Apple", Name="headphones", Price=130,SupplierID=2},
           new Accessorie{Manufacture="Samsung", Name="headphones", Price=99,SupplierID=3},
           new Accessorie{Manufacture="Xiaomi", Name="headphones", Price=69,SupplierID=1},
           new Accessorie{Manufacture="Apple", Name="iphone xs max case", Price=49,SupplierID=2},
           new Accessorie{Manufacture="Samsung", Name="galaxy Note 9 case", Price=49,SupplierID=3},
           new Accessorie{Manufacture="Xiaomi", Name="Xiaomi Mi 9 case", Price=49,SupplierID=4},
           new Accessorie{Manufacture="Samsung", Name="galaxy Note 8 case", Price=49,SupplierID=2},
           new Accessorie{Manufacture="Samsung", Name="galaxy S10 case", Price=49,SupplierID=3},
           new Accessorie{Manufacture="Samsung", Name="galaxy A50 case", Price=49,SupplierID=3},
           new Accessorie{Manufacture="Xiaomi", Name="Xiaomi Mi 9  blue case", Price=49,SupplierID=2},
           new Accessorie{Manufacture="Samsung", Name="External charger", Price=199,SupplierID=2},
           new Accessorie{Manufacture="Samsung", Name="galaxy s8 screen protect", Price=49,SupplierID=3},
           new Accessorie{Manufacture="Samsung", Name="galaxy Note 8 Battery", Price=49,SupplierID=4},


           };
            foreach (Accessorie s in acc)
            {
                context.Accessorie.Add(s);
            }
            context.SaveChanges();


            var cart = new Cart[]
            {
                new Cart{UserID="1"}
         
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

    
            var branch = new Branches[]
            {
                new Branches{ Name="PT", Address ="2 Ha'Sivim St. Petah Tikva", Latitude =32.092084, Longitude =34.856792 },
                new Branches{ Name="RL" , Address ="Lishanski 20 Rishon LeZion" ,Latitude = 31.993148 ,Longitude =34.767842 },
                new Branches{ Name="TV" , Address ="10 Hamasger St. Tel Aviv" ,Latitude = 32.061255 ,Longitude =34.784854 },
                new Branches{ Name="TV" , Address ="Dizengoff 50 Tel Aviv" ,Latitude = 32.075610 ,Longitude =34.775363 },
                new Branches{ Name="JR" , Address ="3 HaParsa St. Jerusalem" ,Latitude = 31.752328 ,Longitude =35.209124 },
                new Branches{ Name="MO" , Address ="Yishpro Center, Modi'in" ,Latitude = 31.879569 ,Longitude =34.962446 },
                new Branches{ Name="HER" , Address ="20 Weizmann St. Herzeliya" ,Latitude = 32.165683 ,Longitude =34.836307 },
                new Branches{ Name="HER" , Address ="82 Ben Gurion St. Herzeliya" ,Latitude = 32.154758 ,Longitude =34.842055 },
                new Branches{ Name="NAT" , Address ="6 HaGavish St. Netanya" ,Latitude = 32.288657 ,Longitude =34.861886 },
                new Branches{ Name="RA" , Address ="15 David Remez St. Netanya" ,Latitude = 32.327509 ,Longitude =34.853963 },
                new Branches{ Name="CS" , Address ="19 HaTaasiya St. Raanana" ,Latitude = 32.196475 ,Longitude =34.877981 },
                new Branches{ Name="HA" , Address ="2 Hayotsrim St. Kfar Saba" ,Latitude = 32.173936 ,Longitude =34.927430 },
                new Branches{ Name="HE" , Address ="HaHaroshet St. Hutzot HaMifratz Mall" ,Latitude = 32.807009 ,Longitude =35.056381 },
                new Branches{ Name="HA" , Address ="2 Harav Ovadia Yosef Ave. (HaHerut) Hadera" ,Latitude = 32.442048 ,Longitude =34.911972 },
                new Branches{ Name="CA" , Address ="104 Haazmaot St. Haifa" ,Latitude = 32.820051 ,Longitude =34.998471 },
                new Branches{ Name="NG" , Address ="9 Maale Kamoon St. My Center, Carmiel" ,Latitude = 32.919620 ,Longitude =35.339792 },
                new Branches{ Name="AF" , Address ="12 (Hayezira St. Nof Hagalil (Nazareth Illit" ,Latitude = 32.715199 ,Longitude =35.336007 },
                new Branches{ Name="EI" , Address ="5 Kehila Tsiyon St. Afula" ,Latitude = 32.598943 ,Longitude =35.307022 },
                new Branches{ Name="EI" , Address ="3 Sderot HaTmarim, Eilat" ,Latitude = 29.554805 ,Longitude =34.953855 },
                new Branches{ Name="AS" , Address ="Pninat Eilat Center, Northern Beach promenade" ,Latitude = 29.551073 ,Longitude =34.955617 },
                new Branches{ Name="BS" , Address ="1 Herzel St. ( Unitrade house) Ashdod" ,Latitude = 31.793863 ,Longitude =34.640803 },
                new Branches{ Name="KG" , Address ="125 Toviyaho david Ave. Grand Mall, Beer Sheva" ,Latitude = 31.793863 ,Longitude =34.640803 },
                new Branches{ Name="RH" , Address ="3 Kikar Paz Lev HaIr Mall, Kiryat Gat" ,Latitude = 31.608855 ,Longitude =34.773076 },
                new Branches{ Name="RHO" , Address ="34 Derech Yavne St. Rehovot" ,Latitude = 31.904788 ,Longitude =34.808276 },


            };
            foreach (Branches s in branch)
            {
                context.Branches.Add(s);
            }
            context.SaveChanges();

        }
    }
}
