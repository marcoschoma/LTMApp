using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LTM.Infra
{
    public sealed class Cryptography
    {
        private const string passwordSalt = "12D4B2EB-B481-489F-B055-0F0C174C605E E5AC6E94-6E64-401D-B87A-20B69A757F59 5B285613-064B-43F3-A687-471A8B98156B";

        public static string Hash(string value)
        {
            return Hash(Encoding.Default.GetBytes(value), Encoding.Default.GetBytes(passwordSalt));
        }

        private static string Hash(byte[] value, byte[] salt)
        {
            var saltedValue = new byte[value.Length + salt.Length];
            value.CopyTo(saltedValue, 0);
            salt.CopyTo(saltedValue, value.Length);

            return Encoding.Default.GetString(new SHA256Managed().ComputeHash(saltedValue));
        }
    }
}
