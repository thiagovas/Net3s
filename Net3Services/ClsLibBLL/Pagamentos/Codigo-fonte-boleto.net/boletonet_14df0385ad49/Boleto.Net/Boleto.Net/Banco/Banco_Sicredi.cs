using System;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.Text;

[assembly: WebResource("BoletoNet.Imagens.748.jpg", "image/jpg")]
namespace BoletoNet
{
    /// <Author>
    /// Samuel Schmidt - Sicredi Nordeste RS
    /// </Author>
    internal class Banco_Sicredi : AbstractBanco, IBanco
    {

        /// <author>
        /// Classe responsavel em criar os campos do Banco Sicredi.
        /// </author>
        internal Banco_Sicredi()
        {
            this.Codigo = 748;
            this.Digito = 0;
            this.Nome = "Banco Sicredi";
        }

        public override void ValidaBoleto(Boleto boleto)
        {
            //Formata o tamanho do número da agência
            if (boleto.Cedente.ContaBancaria.Agencia.Length < 4)
                boleto.Cedente.ContaBancaria.Agencia = Utils.FormatCode(boleto.Cedente.ContaBancaria.Agencia, 4);
            

            //Formata o tamanho do número da conta corrente
            if (boleto.Cedente.ContaBancaria.Conta.Length < 5)
                boleto.Cedente.ContaBancaria.Conta = Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 5);

            //Atribui o nome do banco ao local de pagamento
            if (boleto.LocalPagamento == "Até o vencimento, preferencialmente no ") 
                boleto.LocalPagamento += Nome;

            //Verifica se o nosso número é válido
            if (Utils.ToInt64(boleto.NossoNumero) == 0)
                throw new NotImplementedException("Nosso número inválido");
            else if (boleto.NossoNumero.Length==8)
                boleto.NossoNumero = boleto.NossoNumero + digSicredi(boleto.NossoNumero);

            //Verifica se data do processamento é valida
            if (boleto.DataProcessamento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataProcessamento = DateTime.Now;

            //Verifica se data do documento é valida
            if (boleto.DataDocumento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataDocumento = DateTime.Now;

            if (boleto.Carteira == "112" || boleto.Carteira == "115" || boleto.Carteira == "104" || boleto.Carteira == "147" || boleto.Carteira == "188" || boleto.Carteira == "108" || boleto.Carteira == "109" || boleto.Carteira == "150" || boleto.Carteira == "121")
                boleto.Carteira = "1";
            else
                boleto.Carteira = "3";

            FormataCodigoBarra(boleto);
            FormataLinhaDigitavel(boleto);       
           
        }

        public override void FormataNossoNumero(Boleto boleto)
        {
            throw new NotImplementedException("Função do FormataNossoNumero não implementada.");
        }

        public override void FormataNumeroDocumento(Boleto boleto)
        {
            throw new NotImplementedException("Função do fomata número do documento não implementada.");
        }

        public string CalcularDigitoNossoNumero(Boleto boleto)
        {
            throw new NotImplementedException("Função CalcularDigitoNossoNumero não implementada.");
        }

        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            //041M2.1AAAd1  CCCCC.CCNNNd2  NNNNN.041XXd3  V FFFF9999999999

            string campo1 = "7489" + boleto.CodigoBarra.Codigo.Substring(19,5);
            int d1 = digSicredi(campo1);

            string campo2 = boleto.CodigoBarra.Codigo.Substring(24, 10);
            int d2 = digSicredi(campo2);

            string campo3 = boleto.CodigoBarra.Codigo.Substring(34, 10);
            int d3 = digSicredi(campo3);

            string campo4 = boleto.CodigoBarra.Codigo.Substring(4, 1);

            string campo5 = boleto.CodigoBarra.Codigo.Substring(5, 14);

            boleto.CodigoBarra.LinhaDigitavel = campo1 + "  " + campo2 + "  " + campo3 + "  " + campo4 + "  " + campo5;
        }


        public override void FormataCodigoBarra(Boleto boleto)
        {
            string valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
            valorBoleto = Utils.FormatCode(valorBoleto, 10);

            string cmp_livre = boleto.Carteira + "1" + boleto.NossoNumero + "010906" + boleto.Cedente.ContaBancaria.Conta + "10";
            boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}", Utils.FormatCode(Codigo.ToString(), 3), boleto.Moeda, FatorVencimento(boleto), valorBoleto, cmp_livre, digSicredi(cmp_livre).ToString());

            int _dacBoleto = digSicredi(boleto.CodigoBarra.Codigo);

            if (_dacBoleto == 0 || _dacBoleto == 9)
                _dacBoleto = 1;


            boleto.CodigoBarra.Codigo = Strings.Left(boleto.CodigoBarra.Codigo, 4) + _dacBoleto + Strings.Right(boleto.CodigoBarra.Codigo, 39);
        }


        public override string GerarDetalheRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _detalhe = " ";

             //   base.GerarDetalheRemessa(boleto, numeroRegistro, tipoArquivo);

                switch (tipoArquivo)
                {
                    case TipoArquivo.CNAB240:
                        _detalhe = GerarDetalheRemessaCNAB240(boleto, numeroRegistro, tipoArquivo);
                        break;
                    case TipoArquivo.CNAB400:
                        _detalhe = GerarDetalheRemessaCNAB400(boleto, numeroRegistro, tipoArquivo);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return _detalhe;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do DETALHE arquivo de REMESSA.", ex);
            }
        }

        public string GerarDetalheRemessaCNAB240(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string detalhe = Utils.FormatCode(Codigo.ToString(), "0", 3, true);
                detalhe += Utils.FormatCode("", "0", 4, true);
                detalhe += "3";
                detalhe += Utils.FormatCode(numeroRegistro.ToString(), 5);
                detalhe += "P 01";
                detalhe += Utils.FormatCode(boleto.Cedente.ContaBancaria.Agencia, 5);
                detalhe += "0";
                detalhe += Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 12);
                detalhe += boleto.Cedente.ContaBancaria.DigitoConta;
                detalhe += " ";
                detalhe += Utils.FormatCode(boleto.NossoNumero,20);
                detalhe += "1";
                detalhe += (Convert.ToInt16(boleto.Carteira) == 1 ? "1" : "2");
                detalhe += "122";
                detalhe += Utils.FormatCode(boleto.NumeroDocumento, 15);
                detalhe += boleto.DataVencimento.ToString("ddMMyyyy");
                string valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 13);
                detalhe += valorBoleto;
                detalhe += "00000 99A";
                detalhe += boleto.DataDocumento.ToString("ddMMyyyy");
                detalhe += "200000000";
                valorBoleto = boleto.JurosMora.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 13);
                detalhe += valorBoleto;
                detalhe += "1";
                detalhe += boleto.DataDesconto.ToString("ddMMyyyy");
                valorBoleto = boleto.ValorDesconto.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 13);
                detalhe += valorBoleto;
                detalhe += Utils.FormatCode("", 26);
                detalhe += Utils.FormatCode("", " ", 25);
                detalhe += "0001060090000000000 ";

                detalhe = Utils.SubstituiCaracteresEspeciais(detalhe);
                return detalhe;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar DETALHE do arquivo CNAB240.", e);
            }
        }

        public string GerarDetalheRemessaCNAB400(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                if (boleto.NossoNumero.Length == 8)
                    boleto.NossoNumero = boleto.NossoNumero + digSicredi(boleto.NossoNumero);
                string detalhe = "1";
                detalhe += (Convert.ToInt16(boleto.Carteira) == 1 ? "AAA" : "C A");
                detalhe += Utils.FormatCode("", " ", 12);
                detalhe += "AAB";
                detalhe += Utils.FormatCode("", " ", 28);
                detalhe += boleto.NossoNumero;
                detalhe += Utils.FormatCode("", " ", 6);
                detalhe += DateTime.Now.ToString("yyyyMMdd"); 
                detalhe += " N B0000    ";
                detalhe += "0000000000";
                string valorBoleto = boleto.JurosMora.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 4);
                detalhe += valorBoleto;
                detalhe += Utils.FormatCode("", " ", 12);
                detalhe += "00";
                detalhe += Utils.FormatCode(boleto.NumeroDocumento, "0", 10, true);
                detalhe += boleto.DataVencimento.ToString("ddMMyy");
                valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 13);
                detalhe += valorBoleto;
                detalhe += Utils.FormatCode("", " ", 9);
                detalhe += "KS";
                detalhe += boleto.DataProcessamento.ToString("ddMMyy");
                detalhe += "0000";
                valorBoleto = boleto.JurosMora.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 13);
                detalhe += valorBoleto;
                detalhe += boleto.DataDesconto.ToString("ddMMyy");
                detalhe += Utils.FormatCode("", 26);
                valorBoleto = boleto.ValorDesconto.ToString("f").Replace(",", "").Replace(".", "");
                valorBoleto = Utils.FormatCode(valorBoleto, 13);
                detalhe += valorBoleto;
                if (boleto.Sacado.CPFCNPJ.Length <= 11)
                    detalhe += "1";  // CPF
                else
                    detalhe += "2"; // CNPJ

                detalhe += "0";
                detalhe += Utils.FormatCode(boleto.Sacado.CPFCNPJ, 14);
                detalhe += Utils.FormatCode(boleto.Sacado.Nome, " ", 40);
                detalhe += Utils.FormatCode(boleto.Sacado.Endereco.End," ", 40);
                detalhe += Utils.FormatCode("", 11);
                detalhe += Utils.FormatCode("", " ", 1);
                detalhe += Utils.FormatCode(boleto.Sacado.Endereco.CEP, 8);
                detalhe += Utils.FormatCode("", 5);
                detalhe += Utils.FormatCode("", 14);
                detalhe += Utils.FormatCode("", " ", 41);
                detalhe += Utils.FormatCode(numeroRegistro.ToString(), 6);
                
                detalhe = Utils.SubstituiCaracteresEspeciais(detalhe);
                return detalhe;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar DETALHE do arquivo CNAB240.", e);
            }
        }

        public override string GerarHeaderRemessa(Cedente cedente, TipoArquivo tipoArquivo, int numeroArquivoRemessa)
        {
            return GerarHeaderRemessa("0", cedente, tipoArquivo, numeroArquivoRemessa);
        }

        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo, int numeroArquivoRemessa)
        {
            try
            {
                string _header = " ";

                base.GerarHeaderRemessa("0", cedente, tipoArquivo, numeroArquivoRemessa);

                switch (tipoArquivo)
                {

                    case TipoArquivo.CNAB240:
                        _header = GerarHeaderRemessaCNAB240(cedente);
                        break;
                    case TipoArquivo.CNAB400:
                        _header = GerarHeaderRemessaCNAB400(0, cedente, numeroArquivoRemessa);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return _header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do HEADER do arquivo de REMESSA.", ex);
            }
        }

        private string GerarHeaderLoteRemessaCNAB240(Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                return GerarHeaderRemessaCNAB240(cedente);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar HEADER DO LOTE do arquivo de remessa.", e);
            }
        }

        public override string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa, TipoArquivo tipoArquivo)
        {
            try
            {
                string header = " ";

                switch (tipoArquivo)
                {

                    case TipoArquivo.CNAB240:
                        header = GerarHeaderLoteRemessaCNAB240(cedente, numeroArquivoRemessa);
                        break;
                    case TipoArquivo.CNAB400:
                        header = GerarHeaderLoteRemessaCNAB400(0, cedente, numeroArquivoRemessa);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do HEADER DO LOTE do arquivo de REMESSA.", ex);
            }
        }

        private string GerarHeaderLoteRemessaCNAB400(int numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            throw new Exception("Função não implementada.");
        }

      
        public string GerarHeaderRemessaCNAB240(Cedente cedente)
        {
            try
            {
                string header = "748";
                header += "0000";
                header += "0";
                header += Utils.FormatCode("", " ", 9);
                header += (cedente.CPFCNPJ.Length == 11 ? "1" : "2");
                header += Utils.FormatCode(cedente.CPFCNPJ, "0", 14, true);
                header += Utils.FormatCode(cedente.Convenio.ToString(), " ", 20);
                header += Utils.FormatCode(cedente.ContaBancaria.Agencia, "0", 5, true);
                header += " ";
                header += Utils.FormatCode(cedente.ContaBancaria.Conta, "0", 12, true);
                header += cedente.ContaBancaria.DigitoConta;
                header += " ";
                header += Utils.FormatCode(cedente.Nome, " ", 30);
                header += Utils.FormatCode("SICREDI", " ", 30);
                header += Utils.FormatCode("", " ", 10);
                header += Utils.FormatCode(cedente.Nome, " ", 30);
                header += "1";
                header += DateTime.Now.ToString("ddMMyyyyHHmmss");
                header += Utils.FormatCode("", "0", 6);
                header += "081";
                header += "01600";
                header += Utils.FormatCode("", " ", 69);
                header = Utils.SubstituiCaracteresEspeciais(header);
                return header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar HEADER do arquivo de remessa do CNAB240.", ex);
            }
        }

        public string GerarHeaderRemessaCNAB400(int numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                string _header;

                _header = "01REMESSA01COBRANCA       ";
                _header += Utils.FormatCode(cedente.ContaBancaria.Conta, "0", 5, true);
                _header += Utils.FormatCode(cedente.CPFCNPJ, "0", 14, true);
                _header += Utils.FormatCode("", " ", 31);
                _header += "748SICREDI        ";
                _header += DateTime.Now.ToString("yyyyMMdd");
                _header += Utils.FormatCode("", " ", 8);
                _header += Utils.FormatCode(numeroArquivoRemessa.ToString(), "0", 7, true);
                _header += Utils.FormatCode("", " ", 273);
                _header += "2.00";
                _header += "000001";

                _header = Utils.SubstituiCaracteresEspeciais(_header);

                return _header;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar HEADER do arquivo de remessa do CNAB400.", ex);
            }
        }

        public override string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo, decimal vltitulostotal)
        {
            try
            {
                string _trailer = " ";

                switch (tipoArquivo)
                {
                    case TipoArquivo.CNAB240:
                        _trailer = GerarTrailerRemessa240(numeroRegistro);
                        break;
                    case TipoArquivo.CNAB400:
                        _trailer = GerarTrailerRemessa400(numeroRegistro);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return _trailer;

            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public string GerarTrailerRemessa240(int numeroRegistro)
        {
            try
            {
                string complemento = new string(' ', 205);
                string _trailer;

                _trailer = "74899999";
                _trailer += Utils.FormatCode("", " ", 9);
                _trailer += Utils.FormatCode("", 6);
                _trailer += Utils.FormatCode(numeroRegistro.ToString(), 6);
                _trailer += Utils.FormatCode("", 6);
                _trailer += complemento;

                _trailer = Utils.SubstituiCaracteresEspeciais(_trailer);

                return _trailer;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro TRAILER do arquivo de REMESSA.", ex);
            }
        }

        public string GerarTrailerRemessa400(int numeroRegistro)
        {
            try
            {
                string complemento = new string(' ', 384);
                string _trailer;

                _trailer = "91748";
                _trailer += Utils.FormatCode("", 5);
                _trailer += complemento;
                _trailer += Utils.FormatCode(numeroRegistro.ToString(), 6);

                _trailer = Utils.SubstituiCaracteresEspeciais(_trailer);

                return _trailer;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a geração do registro TRAILER do arquivo de REMESSA.", ex);
            }
        }

        public int digSicredi(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2, b = 9;

            for (int i = seq.Length - 1; i >= 0; i--)
            {
                s = s + (Convert.ToInt32(seq.Substring(i, 1)) * p);
                if (p < b)
                    p = p + 1;
                else
                    p = 2;
            }

            d = 11 - (s % 11);
            if (d > 9)
                d = 0;
            return d;
        }
    }
}
