using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constant
{
    public static class Message
    {
        public static string Added = "Urun Eklendi";
        public static string NotAdded = "Urun Eklenemedi";
        public static string Deleted = "Urun Silindi";
        public static string NotDeleted = "Urun Silinemedi";
        public static string Updated = "Urun Guncellendi";
        public static string NotUpdated = "Urun Guncellenemedi";
        public static string DataListted = "Urunler Listelendi";
        public static string NotDataListted = "Urunler Listelenemedi";
        public static string listted = "urunun ozellikleri guruntelendi";
        public static string Notlistted = "urunun ozellikleri guruntelenemedi";
        internal static string ErrorByImageCount="5 ten fazla fotoğraf eklenemez";
        internal static string AuthorizationDenied ="yetkilendirilme rededildi";
        internal static string UserRegistered="kullanıcı kaydedildi";
        internal static string UserAlreadyExists="kullanıcı mevcut";
        internal static string AccessTokenCreated="kabul jetonu olusturuldu";
        internal static string SuccessfulLogin="başarılı giriş";
        internal static string PasswordError ="hatalı parola";
        internal static string UserNotFound = "kullanıcı bulunamadı";
    }
}
