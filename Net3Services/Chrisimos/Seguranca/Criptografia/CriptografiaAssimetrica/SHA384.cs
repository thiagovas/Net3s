using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica
{
    public class SHA384
    {
        public string criptografar(string texto)
        {
            System.Security.Cryptography.SHA384 sha384 = System.Security.Cryptography.SHA384.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha384.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
