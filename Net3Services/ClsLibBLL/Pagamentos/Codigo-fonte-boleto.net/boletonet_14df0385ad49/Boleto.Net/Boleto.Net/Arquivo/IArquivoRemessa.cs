using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    public interface IArquivoRemessa
    {
        /// <summary>
        /// Gera arquivo de remessa
        /// </summary>
        void GerarArquivoRemessa(string numeroConvenio, IBanco banco, Cedente cedente, Boletos boletos, Stream arquivo, int numeroArquivoRemessa);

        Boletos Boletos { get; }
        Cedente Cedente { get; }
        IBanco Banco{ get; }
        string NumeroConvenio { get; set; }
        int NumeroArquivoRemessa { get; set; }
        TipoArquivo TipoArquivo { get; }

        event EventHandler<LinhaDeArquivoGeradaArgs> LinhaDeArquivoGerada;
    }
}
