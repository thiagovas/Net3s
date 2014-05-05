using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica
{
    public class SHA1
    {
        public string criptografar(string texto)
        {
            System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha1.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
