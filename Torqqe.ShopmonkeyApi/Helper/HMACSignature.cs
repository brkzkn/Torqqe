using System;
using System.Security.Cryptography;
using System.Text;

namespace Torqqe.ShopmonkeyApi.Helper
{
    public class HMACSignature
    {
        public static string GenerateSignature(string input, string secret)
        {

            var secretKeyByteArray = (new ASCIIEncoding()).GetBytes(secret);
            byte[] signature = Encoding.UTF8.GetBytes(input);
            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);

                return Convert.ToBase64String(signatureBytes);
            }
        }
    }
}
