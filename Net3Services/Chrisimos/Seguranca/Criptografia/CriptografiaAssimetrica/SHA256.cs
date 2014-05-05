using System.Text;

namespace Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica
{
    public class SHA256
    {
        public string criptografar(string texto)
        {
            System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha256.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
