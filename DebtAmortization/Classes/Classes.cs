using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace DebtAmortization.Classes
{
    public static class Hashes
    {
        public static string ComputeHash(string stringToHash, string saltToHash)
        {
            return ComputeHash(Encoding.UTF8.GetBytes(stringToHash), Encoding.UTF8.GetBytes(saltToHash));
        }

        public static string ComputeHash(byte[] bytesToHash, byte[] salt)
        {
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000, HashAlgorithmName.SHA512);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }

        

        public static string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
