using MongoDB;

namespace ClsLibBLL
{
    public class ClsUsuLogado
    {
        public static Oid IdUsuario { get; set; }
        public static string Login { get; set; }
        public static string Pais { get; set; }
        public static string Uf { get; set; }
        public static string Cidade { get; set; }
        public static string CpfCnpj { get; set; }
        public static string Rg { get; set; }

        public static void LimparPropriedades()
        {
            IdUsuario = null;
            Login = null;
            Pais = null;
            Uf = null;
            Cidade = null;
            CpfCnpj = null;
            Rg = null;
        }
    }
}