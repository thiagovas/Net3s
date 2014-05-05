using System;

namespace ClsLibBLL
{
    public class OidNullException : Exception
    {
        private string Mensagem = "Este Oid é inválido.";
        public override string Message
        {
            get
            {
                return Mensagem;
            }
        }

        public OidNullException()
        { }

        public OidNullException(string msg)
        {
            Mensagem = msg;
        }
    }

    /// <summary>
    /// Exception retornada quando o Oid não estiver no padrão do banco de dados.
    /// </summary>
    public class OidException : Exception
    {
        private string Mensagem = "Este Oid é inválido.";

        public override string Message
        {
            get
            {
                return Mensagem;
            }
        }

        public OidException()
        { }

        public OidException(string msg)
        {
            Mensagem = msg;
        }
    }
}