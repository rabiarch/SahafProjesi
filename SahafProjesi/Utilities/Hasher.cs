using System.Security.Cryptography;
using System.Text;

namespace SahafProjesi.Utilities
{
    public static class Hasher
    {
        public static string Md5Hasher(string sifre) 
        { 
            MD5 mD5 = MD5.Create(); 

            var hashedData = mD5.ComputeHash(Encoding.UTF8.GetBytes(sifre)); 
            string md5Data = ""; 

            foreach (var item in hashedData) 
            { 
                md5Data += item.ToString("x2"); 
            } 

            return md5Data; 
        }
    }
}
