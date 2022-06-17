using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static readonly User userNotFound;
        public static string CarAdded = "Yeni Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string BrandAdded = "Yeni Araba markası eklendi";
        public static string BrandUpdated = "Araba markası güncellendi";
        public static string BrandDeleted = "Araba markası silindi";
        public static string ColorAdded = "Yeni boya eklendi";
        public static string ColorDeleted = " boya silindi";
        public static string ColorUpdated = " boya güncellendi";
        public static string UserAdded = "kullanıcı eklendi";
        public static string UserDeleted = "kullanıcı silindi";
        public static string UserUpdated = "kullanıcı güncellendi";
        public static string CustomerAdded = "müşteri eklendi";
        public static string CustomerDeleted = "müşteri silindi";
        public static string CustomerUpdated = "müşteri güncellendi";
        public static string RentalAdded = "araba kiralama eklendi";
        public static string RentalDeleted = "araba kiralama silindi";
        public static string RentalUpdated = "araba kiralama güncellendi";
        public static string CarsListed = "arabalar listelendi";
        public static string ImageAdded = "Araba resimleri eklendi";
       public static string ImageDeleted;
        public static string ImageUpdated;
        public static string ImageCountOverLimit;
        public static string TokenCreated;
        public static string userWrongPassword;
        public static string UserMailFound;
        public static string UserRegistered;
        public static string AuthorizationDenied;
        public static string UserNotRegister = " kullanıcı mevcut!";
    }
}
