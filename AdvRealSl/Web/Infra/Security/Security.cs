using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Web.Infra.Security
{
    public class Security: ISecurity
    {
        public string Criptography(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(value));

            var criptography = md5.Hash;
            var hash = new StringBuilder();

            for (int i = 0; i < criptography.Length; i++)
            {
                hash.Append(criptography[i].ToString("x"));
            }

            return hash.ToString();
        }
    }
}
