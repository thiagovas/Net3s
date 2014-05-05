﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica
{
    public class MD5
    {
        public string criptografar(string texto)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
