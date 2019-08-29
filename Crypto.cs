using System;
using System.Security.Cryptography;
using System.Text;

namespace FIRERISK
{
    public static class Crypto
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(SHA256.Create()
.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}