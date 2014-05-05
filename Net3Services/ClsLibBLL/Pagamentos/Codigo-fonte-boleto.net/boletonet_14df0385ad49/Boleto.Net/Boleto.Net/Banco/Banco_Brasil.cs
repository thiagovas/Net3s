
using System;
using System.Web.UI;
using Microsoft.VisualBasic;

[assembly: WebResource("BoletoNet.Imagens.001.jpg", "image/jpg")]
namespace BoletoNet
{
    /// <summary>
    /// Classe referente ao Banco do Brasil
    /// </summary>
    internal class Banco_Brasil : AbstractBanco, IBanco
    {

        #region Vari�veis

        private string _dacNossoNumero = string.Empty;
        private int _dacBoleto = 0;

        #endregion

        #region Construtores

        internal Banco_Brasil()
        {
            try
            {
                this.Codigo = 1;
                this.Digito = 9;
                this.Nome = "Banco do Brasil";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao instanciar objeto.", ex);
            }
        }
        #endregion

        #region M�todos de Inst�ncia

        /// <summary>
        /// Valida��es particulares do Banco do Brasil
        /// </summary>
        public override void ValidaBoleto(Boleto boleto)
        {
            if (string.IsNullOrEmpty(boleto.Carteira))
                throw new NotImplementedException("Carteira n�o informada. Utilize a carteira 16, 17, 17-019, 18, 18-019, 18-027, 18-035 ou 18-140.");

            //Verifica as carteiras implementadas
            if (!boleto.Carteira.Equals("16") &
                !boleto.Carteira.Equals("17") &
                !boleto.Carteira.Equals("17-019") &
                !boleto.Carteira.Equals("18") &
                !boleto.Carteira.Equals("18-019") &
                !boleto.Carteira.Equals("18-027") &
                !boleto.Carteira.Equals("18-035") &
                !boleto.Carteira.Equals("18-140"))

                throw new NotImplementedException("Carteira n�o informada. Utilize a carteira 16, 17, 17-019, 18, 18-019, 18-027, 18-035 ou 18-140.");

            //Verifica se o nosso n�mero � v�lido
            if (Utils.ToString(boleto.NossoNumero) == string.Empty)
                throw new NotImplementedException("Nosso n�mero inv�lido");

            #region Carteira 16
            //Carteira 18 com nosso n�mero de 11 posi��es
            if (boleto.Carteira.Equals("16"))
            {
                if (!boleto.TipoModalidade.Equals("21"))
                {
                    if (boleto.NossoNumero.Length > 11)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 11 de posi��es para o nosso n�mero", boleto.Carteira));

                    if (boleto.Cedente.Convenio.ToString().Length == 6)
                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 11));
                    else
                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
                }
                else
                {
                    if (boleto.Cedente.Convenio.ToString().Length != 6)
                        throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o n�mero do conv�nio s�o de 6 posi��es", boleto.Carteira));

                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                }
            }
            #endregion Carteira 16

            #region Carteira 17
            //Carteira 17
            if (boleto.Carteira.Equals("17"))
            {
                switch (boleto.Cedente.Convenio.ToString().Length)
                {
                    //O BB manda como padr�o 7 posi��es, mas � poss�vel solicitar um conv�nio com 6 posi��es na carteira 17
                    case 6:
                        if (boleto.NossoNumero.Length > 12)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 12 de posi��es para o nosso n�mero", boleto.Carteira));
                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 12);
                        break;
                    case 7:
                        if (boleto.NossoNumero.Length > 17)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 10 de posi��es para o nosso n�mero", boleto.Carteira));
                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                        break;
                    default:
                        throw new NotImplementedException(string.Format("Para a carteira {0}, o n�mero do conv�nio deve ter 6 ou 7 posi��es", boleto.Carteira));
                }
            }
            #endregion Carteira 17

            #region Carteira 17-019
            //Carteira 17, com varia��o 019
            if (boleto.Carteira.Equals("17-019"))
            {
                /*
                 * Conv�nio de 7 posi��es
                 * Nosso N�mero com 17 posi��es
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 10 de posi��es para o nosso n�mero", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Conv�nio de 6 posi��es
                 * Nosso N�mero com 11 posi��es
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Nosso N�mero com 17 posi��es
                    if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 11 de posi��es para o nosso n�mero. Onde o nosso n�mero � formado por CCCCCCNNNNN-X: C -> n�mero do conv�nio fornecido pelo Banco, N -> seq�encial atribu�do pelo cliente e X -> d�gito verificador do �Nosso-N�mero�.", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                }
                /*
                  * Conv�nio de 4 posi��es
                  * Nosso N�mero com 11 posi��es
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 7 de posi��es para o nosso n�mero [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 17-019

            #region Carteira 18
            //Carteira 18 com nosso n�mero de 11 posi��es
            if (boleto.Carteira.Equals("18"))
                boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            #endregion Carteira 18

            #region Carteira 18-019
            //Carteira 18, com varia��o 019
            if (boleto.Carteira.Equals("18-019"))
            {
                /*
                 * Conv�nio de 7 posi��es
                 * Nosso N�mero com 17 posi��es
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 10 de posi��es para o nosso n�mero", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Conv�nio de 6 posi��es
                 * Nosso N�mero com 11 posi��es
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobran�a Sem Registro � Carteira 16 e 18
                    //Nosso N�mero com 17 posi��es
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 11 de posi��es para o nosso n�mero. Onde o nosso n�mero � formado por CCCCCCNNNNN-X: C -> n�mero do conv�nio fornecido pelo Banco, N -> seq�encial atribu�do pelo cliente e X -> d�gito verificador do �Nosso-N�mero�.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o n�mero do conv�nio s�o de 6 posi��es", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Conv�nio de 4 posi��es
                  * Nosso N�mero com 11 posi��es
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 7 de posi��es para o nosso n�mero [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-019


            //Para atender o cliente Fiemg foi adaptado no c�digo na varia��o 18-027 as varia��es 18-035 e 18-140
            #region Carteira 18-027
            //Carteira 18, com varia��o 019
            if (boleto.Carteira.Equals("18-027"))
            {
                /*
                 * Conv�nio de 7 posi��es
                 * Nosso N�mero com 17 posi��es
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 10 de posi��es para o nosso n�mero", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Conv�nio de 6 posi��es
                 * Nosso N�mero com 11 posi��es
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobran�a Sem Registro � Carteira 16 e 18
                    //Nosso N�mero com 17 posi��es
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 11 de posi��es para o nosso n�mero. Onde o nosso n�mero � formado por CCCCCCNNNNN-X: C -> n�mero do conv�nio fornecido pelo Banco, N -> seq�encial atribu�do pelo cliente e X -> d�gito verificador do �Nosso-N�mero�.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o n�mero do conv�nio s�o de 6 posi��es", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Conv�nio de 4 posi��es
                  * Nosso N�mero com 11 posi��es
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 7 de posi��es para o nosso n�mero [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-027

            #region Carteira 18-035
            //Carteira 18, com varia��o 019
            if (boleto.Carteira.Equals("18-035"))
            {
                /*
                 * Conv�nio de 7 posi��es
                 * Nosso N�mero com 17 posi��es
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 10 de posi��es para o nosso n�mero", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Conv�nio de 6 posi��es
                 * Nosso N�mero com 11 posi��es
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobran�a Sem Registro � Carteira 16 e 18
                    //Nosso N�mero com 17 posi��es
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 11 de posi��es para o nosso n�mero. Onde o nosso n�mero � formado por CCCCCCNNNNN-X: C -> n�mero do conv�nio fornecido pelo Banco, N -> seq�encial atribu�do pelo cliente e X -> d�gito verificador do �Nosso-N�mero�.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o n�mero do conv�nio s�o de 6 posi��es", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Conv�nio de 4 posi��es
                  * Nosso N�mero com 11 posi��es
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 7 de posi��es para o nosso n�mero [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-035

            #region Carteira 18-140
            //Carteira 18, com varia��o 019
            if (boleto.Carteira.Equals("18-140"))
            {
                /*
                 * Conv�nio de 7 posi��es
                 * Nosso N�mero com 17 posi��es
                 */
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    if (boleto.NossoNumero.Length > 10)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 10 de posi��es para o nosso n�mero", boleto.Carteira));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 10));
                }
                /*
                 * Conv�nio de 6 posi��es
                 * Nosso N�mero com 11 posi��es
                 */
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    //Modalidades de Cobran�a Sem Registro � Carteira 16 e 18
                    //Nosso N�mero com 17 posi��es
                    if (!boleto.TipoModalidade.Equals("21"))
                    {
                        if ((boleto.Cedente.Codigo.ToString().Length + boleto.NossoNumero.Length) > 11)
                            throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 11 de posi��es para o nosso n�mero. Onde o nosso n�mero � formado por CCCCCCNNNNN-X: C -> n�mero do conv�nio fornecido pelo Banco, N -> seq�encial atribu�do pelo cliente e X -> d�gito verificador do �Nosso-N�mero�.", boleto.Carteira));

                        boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5));
                    }
                    else
                    {
                        if (boleto.Cedente.Convenio.ToString().Length != 6)
                            throw new NotImplementedException(string.Format("Para a carteira {0} e o tipo da modalidade 21, o n�mero do conv�nio s�o de 6 posi��es", boleto.Carteira));

                        boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 17);
                    }
                }
                /*
                  * Conv�nio de 4 posi��es
                  * Nosso N�mero com 11 posi��es
                  */
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    if (boleto.NossoNumero.Length > 7)
                        throw new NotImplementedException(string.Format("Para a carteira {0}, a quantidade m�xima s�o de 7 de posi��es para o nosso n�mero [{1}]", boleto.Carteira, boleto.NossoNumero));

                    boleto.NossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                }
                else
                    boleto.NossoNumero = Utils.FormatCode(boleto.NossoNumero, 11);
            }
            #endregion Carteira 18-140


            #region Ag�ncia e Conta Corrente
            //Verificar se a Agencia esta correta
            if (boleto.Cedente.ContaBancaria.Agencia.Length > 4)
                throw new NotImplementedException("A quantidade de d�gitos da Ag�ncia " + boleto.Cedente.ContaBancaria.Agencia + ", s�o de 4 n�meros.");
            else if (boleto.Cedente.ContaBancaria.Agencia.Length < 4)
                boleto.Cedente.ContaBancaria.Agencia = Utils.FormatCode(boleto.Cedente.ContaBancaria.Agencia, 4);

            //Verificar se a Conta esta correta
            if (boleto.Cedente.ContaBancaria.Conta.Length > 8)
                throw new NotImplementedException("A quantidade de d�gitos da Conta " + boleto.Cedente.ContaBancaria.Conta + ", s�o de 8 n�meros.");
            else if (boleto.Cedente.ContaBancaria.Conta.Length < 8)
                boleto.Cedente.ContaBancaria.Conta = Utils.FormatCode(boleto.Cedente.ContaBancaria.Conta, 8);
            #endregion Ag�ncia e Conta Corrente

            //Atribui o nome do banco ao local de pagamento
            boleto.LocalPagamento += Nome + "";

            //Verifica se data do processamento � valida
            if (boleto.DataProcessamento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataProcessamento = DateTime.Now;

            //Verifica se data do documento � valida
            if (boleto.DataDocumento.ToString("dd/MM/yyyy") == "01/01/0001")
                boleto.DataDocumento = DateTime.Now;

            boleto.QuantidadeMoeda = 0;

            FormataCodigoBarra(boleto);
            FormataLinhaDigitavel(boleto);
            FormataNossoNumero(boleto);
        }

        # endregion

        private string LimparCarteira(string carteira)
        {
            return carteira.Split('-')[0];
        }

        #region M�todos de formata��o do boleto

        public override void FormataCodigoBarra(Boleto boleto)
        {
            string valorBoleto = boleto.ValorBoleto.ToString("f").Replace(",", "").Replace(".", "");
            valorBoleto = Utils.FormatCode(valorBoleto, 10);

            #region Carteira 16
            if (boleto.Carteira.Equals("16"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                }
                else
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        boleto.Carteira);
                }
            }
            #endregion Carteira 16

            #region Carteira 17
            if (boleto.Carteira.Equals("17"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        Strings.Mid(boleto.NossoNumero, 1, 11),
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        boleto.Carteira);
                }
                else
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        boleto.Carteira);
                }
            }
            #endregion Carteira 17

            #region Carteira 17-019
            if (boleto.Carteira.Equals("17-019"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especifica��o Conv�nio 7 posi��es
                    /*
                    Posi��o     Tamanho     Picture     Conte�do
                    01 a 03         03      9(3)            C�digo do Banco na C�mara de Compensa��o = �001�
                    04 a 04         01      9(1)            C�digo da Moeda = '9'
                    05 a 05         01      9(1)            DV do C�digo de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-N�mero, sem o DV
                    26 a 32         9       (7)             N�mero do Conv�nio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-N�mero, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobran�a
                     */
                    #endregion Especifica��o Conv�nio 7 posi��es

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 17-019

            #region Carteira 18
            if (boleto.Carteira.Equals("18"))
            {
                boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                    Utils.FormatCode(Codigo.ToString(), 3),
                    boleto.Moeda,
                    FatorVencimento(boleto),
                    valorBoleto,
                    boleto.NossoNumero,
                    boleto.Cedente.ContaBancaria.Agencia,
                    boleto.Cedente.ContaBancaria.Conta,
                    boleto.Carteira);
            }
            #endregion Carteira 18

            #region Carteira 18-019
            if (boleto.Carteira.Equals("18-019"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especifica��o Conv�nio 7 posi��es
                    /*
                    Posi��o     Tamanho     Picture     Conte�do
                    01 a 03         03      9(3)            C�digo do Banco na C�mara de Compensa��o = �001�
                    04 a 04         01      9(1)            C�digo da Moeda = '9'
                    05 a 05         01      9(1)            DV do C�digo de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-N�mero, sem o DV
                    26 a 32         9       (7)             N�mero do Conv�nio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-N�mero, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobran�a
                     */
                    #endregion Especifica��o Conv�nio 7 posi��es

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-019

            //Para atender o cliente Fiemg foi adptado no c�digo na varia��o 18-027 as varia��es 18-035 e 18-140
            #region Carteira 18-027
            if (boleto.Carteira.Equals("18-027"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especifica��o Conv�nio 7 posi��es
                    /*
                    Posi��o     Tamanho     Picture     Conte�do
                    01 a 03         03      9(3)            C�digo do Banco na C�mara de Compensa��o = �001�
                    04 a 04         01      9(1)            C�digo da Moeda = '9'
                    05 a 05         01      9(1)            DV do C�digo de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-N�mero, sem o DV
                    26 a 32         9       (7)             N�mero do Conv�nio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-N�mero, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobran�a
                     */
                    #endregion Especifica��o Conv�nio 7 posi��es

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto).ToString("0000"),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-027

            #region Carteira 18-035
            if (boleto.Carteira.Equals("18-035"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especifica��o Conv�nio 7 posi��es
                    /*
                    Posi��o     Tamanho     Picture     Conte�do
                    01 a 03         03      9(3)            C�digo do Banco na C�mara de Compensa��o = �001�
                    04 a 04         01      9(1)            C�digo da Moeda = '9'
                    05 a 05         01      9(1)            DV do C�digo de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-N�mero, sem o DV
                    26 a 32         9       (7)             N�mero do Conv�nio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-N�mero, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobran�a
                     */
                    #endregion Especifica��o Conv�nio 7 posi��es

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto).ToString("0000"),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-035

            #region Carteira 18-140
            if (boleto.Carteira.Equals("18-140"))
            {
                if (boleto.Cedente.Convenio.ToString().Length == 7)
                {
                    #region Especifica��o Conv�nio 7 posi��es
                    /*
                    Posi��o     Tamanho     Picture     Conte�do
                    01 a 03         03      9(3)            C�digo do Banco na C�mara de Compensa��o = �001�
                    04 a 04         01      9(1)            C�digo da Moeda = '9'
                    05 a 05         01      9(1)            DV do C�digo de Barras (Anexo 10)
                    06 a 09         04      9(04)           Fator de Vencimento (Anexo 8)
                    10 a 19         10      9(08)           V(2) Valor
                    20 a 25         06      9(6)            Zeros
                    26 a 42         17      9(17)           Nosso-N�mero, sem o DV
                    26 a 32         9       (7)             N�mero do Conv�nio fornecido pelo Banco (CCCCCCC)
                    33 a 42         9       (10)            Complemento do Nosso-N�mero, sem DV (NNNNNNNNNN)
                    43 a 44         02      9(2)            Tipo de Carteira/Modalidade de Cobran�a
                     */
                    #endregion Especifica��o Conv�nio 7 posi��es

                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto).ToString("0000"),
                        valorBoleto,
                        "000000",
                        boleto.NossoNumero,
                        Utils.FormatCode(LimparCarteira(boleto.Carteira), 2));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 6)
                {
                    if (boleto.TipoModalidade.Equals("21"))
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.Cedente.Convenio,
                            boleto.NossoNumero,
                            "21");
                    else
                        boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                            Utils.FormatCode(Codigo.ToString(), 3),
                            boleto.Moeda,
                            FatorVencimento(boleto),
                            valorBoleto,
                            boleto.NossoNumero,
                            boleto.Cedente.ContaBancaria.Agencia,
                            boleto.Cedente.ContaBancaria.Conta,
                            LimparCarteira(boleto.Carteira));
                }
                else if (boleto.Cedente.Convenio.ToString().Length == 4)
                {
                    boleto.CodigoBarra.Codigo = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                        Utils.FormatCode(Codigo.ToString(), 3),
                        boleto.Moeda,
                        FatorVencimento(boleto),
                        valorBoleto,
                        boleto.NossoNumero,
                        boleto.Cedente.ContaBancaria.Agencia,
                        boleto.Cedente.ContaBancaria.Conta,
                        LimparCarteira(boleto.Carteira));
                }
            }
            #endregion Carteira 18-140
            _dacBoleto = Mod11(boleto.CodigoBarra.Codigo, 9);

            boleto.CodigoBarra.Codigo = Strings.Left(boleto.CodigoBarra.Codigo, 4) + _dacBoleto + Strings.Right(boleto.CodigoBarra.Codigo, 39);
        }

        public override void FormataLinhaDigitavel(Boleto boleto)
        {
            string cmplivre = string.Empty;
            string campo1 = string.Empty;
            string campo2 = string.Empty;
            string campo3 = string.Empty;
            string campo4 = string.Empty;
            string campo5 = string.Empty;
            long icampo5 = 0;
            int digitoMod = 0;

            /*
            Campos 1 (AAABC.CCCCX):
            A = C�digo do Banco na C�mara de Compensa��o �001�
            B = C�digo da moeda "9" (*)
            C = Posi��o 20 a 24 do c�digo de barras
            X = DV que amarra o campo 1 (M�dulo 10, contido no Anexo 7)
             */

            cmplivre = Strings.Mid(boleto.CodigoBarra.Codigo, 20, 25);

            campo1 = Strings.Left(boleto.CodigoBarra.Codigo, 4) + Strings.Mid(cmplivre, 1, 5);
            digitoMod = Mod10(campo1);
            campo1 = campo1 + digitoMod.ToString();
            campo1 = Strings.Mid(campo1, 1, 5) + "." + Strings.Mid(campo1, 6, 5);
            /*
            Campo 2 (DDDDD.DDDDDY)
            D = Posi��o 25 a 34 do c�digo de barras
            Y = DV que amarra o campo 2 (M�dulo 10, contido no Anexo 7)
             */
            campo2 = Strings.Mid(cmplivre, 6, 10);
            digitoMod = Mod10(campo2);
            campo2 = campo2 + digitoMod.ToString();
            campo2 = Strings.Mid(campo2, 1, 5) + "." + Strings.Mid(campo2, 6, 6);


            /*
            Campo 3 (EEEEE.EEEEEZ)
            E = Posi��o 35 a 44 do c�digo de barras
            Z = DV que amarra o campo 3 (M�dulo 10, contido no Anexo 7)
             */
            campo3 = Strings.Mid(cmplivre, 16, 10);
            digitoMod = Mod10(campo3);
            campo3 = campo3 + digitoMod;
            campo3 = Strings.Mid(campo3, 1, 5) + "." + Strings.Mid(campo3, 6, 6);

            /*
            Campo 4 (K)
            K = DV do C�digo de Barras (M�dulo 11, contido no Anexo 10)
             */
            campo4 = Strings.Mid(boleto.CodigoBarra.Codigo, 5, 1);

            /*
            Campo 5 (UUUUVVVVVVVVVV)
            U = Fator de Vencimento ( Anexo 10)
            V = Valor do T�tulo (*)
             */
            icampo5 = Convert.ToInt64(Strings.Mid(boleto.CodigoBarra.Codigo, 6, 14));

            if (icampo5 == 0)
                campo5 = "000";
            else
                campo5 = icampo5.ToString();

            boleto.CodigoBarra.LinhaDigitavel = campo1 + "  " + campo2 + "  " + campo3 + "  " + campo4 + "  " + campo5;
        }

        /// <summary>
        /// Formata o nosso n�mero para ser mostrado no boleto.
        /// </summary>
        /// <remarks>
        /// �ltima a atualiza��o por Transis em 26/09/2011
        /// </remarks>
        /// <param name="boleto"></param>
        public override void FormataNossoNumero(Boleto boleto)
        {
            if (boleto.Carteira.Equals("18-019"))
                boleto.NossoNumero = string.Format("{0}/{1}", LimparCarteira(boleto.Carteira), boleto.NossoNumero);
            else if (boleto.Carteira.Equals("17-019"))
                boleto.NossoNumero = string.Format("{0}/{1}", LimparCarteira(boleto.Carteira), boleto.NossoNumero);
            else if (boleto.Carteira.Equals("18-027"))
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
            //Para atender o cliente Fiemg foi adptado no c�digo na varia��o 18-027 as varia��es 18-035 e 18-140
            else if (boleto.Carteira.Equals("18-035"))
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
            else if (boleto.Carteira.Equals("18-140"))
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
            //somente monta o digito verificador no nosso numero se o convenio tiver 6 posi��es
            else if (boleto.Cedente.Convenio.ToString().Length == 6)
                boleto.NossoNumero = string.Format("{0}/{1}-{2}", LimparCarteira(boleto.Carteira), boleto.NossoNumero, Mod11BancoBrasil(boleto.NossoNumero));
            else
                boleto.NossoNumero = string.Format("{0}", boleto.NossoNumero);
        }


        public override void FormataNumeroDocumento(Boleto boleto)
        {
        }

        # endregion

        # region M�todos de gera��o do arquivo remessa CNAB240

        # region HEADER

        /// <summary>
        /// HEADER do arquivo CNAB
        /// Gera o HEADER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarHeaderRemessa(string numeroConvenio, Cedente cedente, TipoArquivo tipoArquivo, int numeroArquivoRemessa)
        {
            try
            {
                string _header = " ";

                base.GerarHeaderRemessa(numeroConvenio, cedente, tipoArquivo, numeroArquivoRemessa);

                switch (tipoArquivo)
                {

                    case TipoArquivo.CNAB240:
                        _header = GerarHeaderRemessaCNAB240(cedente);
                        break;
                    case TipoArquivo.CNAB400:
                        _header = GerarHeaderRemessaCNAB400(cedente);
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return _header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do HEADER do arquivo de REMESSA.", ex);
            }
        }

        // HEADER ARQUIVO REMESSA CNAB240
        public string GerarHeaderRemessaCNAB240(Cedente cedente)
        {
            try
            {
                string _brancos20 = new string(' ', 20);
                string _brancos10 = new string(' ', 10);
                string _header;

                _header = "00100000         ";
                if (cedente.CPFCNPJ.Length <= 11)
                    _header += "1";
                else
                    _header += "2";
                _header += Utils.FitStringLength(cedente.CPFCNPJ, 14, 14, '0', 0, true, true, true);
                _header += _brancos20;
                _header += Utils.FitStringLength(cedente.ContaBancaria.Agencia, 5, 5, '0', 0, true, true, true);
                _header += Utils.FitStringLength(cedente.ContaBancaria.DigitoAgencia, 1, 1, ' ', 0, true, true, false);
                _header += Utils.FitStringLength(cedente.ContaBancaria.Conta, 12, 12, '0', 0, true, true, true);
                _header += Utils.FitStringLength(cedente.ContaBancaria.DigitoConta, 1, 1, ' ', 0, true, true, false);
                _header += " "; // D�GITO VERIFICADOR DA AG./CONTA
                _header += Utils.FitStringLength(cedente.Nome, 30, 30, ' ', 0, true, true, false);
                _header += Utils.FitStringLength("BANCO DO BRASIL S.A.", 30, 30, ' ', 0, true, true, false);
                _header += _brancos10;
                _header += "1";
                _header += DateTime.Now.ToString("ddMMyyyy");
                _header += DateTime.Now.ToString("hhMMss");
                // N�MERO SEQUENCIAL DO ARQUIVO *EVOLUIR UM N�MERO A CADA HEADER DE ARQUIVO
                _header += "000001";
                // Campo n�o criticado pelo sistema, informar ZEROS ou n� da vers�o do layout do arquivo que foi utilizado
                // para a formata��o dos campos.
                // Como n�o sei onde pegar esse n�, deixei como padr�o.
                _header += "000";
                _header += "00000";
                _header += _brancos20;
                _header += _brancos20;
                _header += _brancos10;
                _header += "    ";
                _header += "000  ";
                _header += _brancos10;

                _header = Utils.SubstituiCaracteresEspeciais(_header);

                return _header;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do HEADER DE ARQUIVO do arquivo de REMESSA.", ex);
            }
        }
        // HEADER ARQUIVO REMESSA CNAB400
        public string GerarHeaderRemessaCNAB400(Cedente cedente)
        {
            try
            {
                throw new NotImplementedException("Fun�ao n�o implementada!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do HEADER do arquivo de REMESSA.", ex);
            }
        }

        # endregion

        # region HEADER DE LOTE

        /// <summary>
        /// HEADER DE LOTE do arquivo CNAB
        /// Gera o HEADER de Lote do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarHeaderLoteRemessa(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa, TipoArquivo tipoArquivo)
        {
            try
            {
                string header = " ";

                base.GerarHeaderLoteRemessa(numeroConvenio, cedente, numeroArquivoRemessa, tipoArquivo);

                switch (tipoArquivo)
                {
                    case TipoArquivo.CNAB240:
                        header = GerarHeaderLoteRemessaCNAB240(numeroConvenio, cedente, numeroArquivoRemessa);
                        break;
                    case TipoArquivo.CNAB400:
                        header = "";
                        break;
                    case TipoArquivo.Outro:
                        throw new Exception("Tipo de arquivo inexistente.");
                }

                return header;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do HEADER DO LOTE do arquivo de REMESSA.", ex);
            }
        }

        // HEADER DE LOTE REMESSA CNAB240
        private string GerarHeaderLoteRemessaCNAB240(string numeroConvenio, Cedente cedente, int numeroArquivoRemessa)
        {
            try
            {
                string _brancos40 = new string(' ', 40);
                string _brancos33 = new string(' ', 33);
                string _headerLote;

                _headerLote = "00100011R0100";
                // Campo n�o criticado pelo sistema, informar ZEROS ou n� da vers�o do layout do arquivo que foi utilizado
                // para a formata��o dos campos.
                // Como n�o sei onde pegar esse n�, deixei como padr�o.
                _headerLote += "020";
                _headerLote += " ";

                if (cedente.CPFCNPJ.Length <= 11)
                    _headerLote += "1";
                else
                    _headerLote += "2";

                _headerLote += Utils.FitStringLength(cedente.CPFCNPJ, 15, 15, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(numeroConvenio, 9, 9, '0', 0, true, true, true);
                _headerLote += "0014";
                // O C�digo da carteira � dividida em 2 partes:
                // - n� da carteira 9(02)
                // - varia��o (se houver) 9(03)
                if (cedente.Carteira.Length == 2)
                    _headerLote += cedente.Carteira.ToString() + "000  ";
                else
                    _headerLote += cedente.Carteira.Replace("-", "") + "  ";

                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.Agencia, 5, 5, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.DigitoAgencia, 1, 1, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.Conta, 12, 12, '0', 0, true, true, true);
                _headerLote += Utils.FitStringLength(cedente.ContaBancaria.DigitoConta, 1, 1, '0', 0, true, true, true);
                // D�gito verificador  da Ag�ncia/Conta.  Campo n�o tratado pelo BB.  Informar ESPA�O ou ZERO.
                _headerLote += "0";
                _headerLote += Utils.FitStringLength(cedente.Nome, 30, 30, ' ', 0, true, true, false);
                _headerLote += _brancos40;
                _headerLote += _brancos40;
                // Campo n�o tratado pelo BB. Sugerem utilizar n� sequencial para controle da empresa.  N�o especifica se � controle de arquivo.
                // Em todo caso, coloquei o n� sequencial do arquivo remessa.
                _headerLote += Utils.FitStringLength(numeroArquivoRemessa.ToString(), 8, 8, '0', 0, true, true, true);
                _headerLote += DateTime.Now.ToString("ddMMyyyy");
                _headerLote += "00000000";
                _headerLote += _brancos33;

                _headerLote = Utils.SubstituiCaracteresEspeciais(_headerLote);

                return _headerLote;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do HEADER DE LOTE do arquivo de REMESSA.", ex);
            }
        }

        # endregion

        # region DETALHE

        /// <summary>
        /// DETALHE do arquivo CNAB
        /// Gera o DETALHE do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarDetalheRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _detalhe = " ";

                base.GerarDetalheRemessa(boleto, numeroRegistro, tipoArquivo);

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
                throw new Exception("Erro durante a gera��o do DETALHE arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoPRemessa(Boleto boleto, int numeroRegistro, string numeroConvenio)
        {
            try
            {
                string _segmentoP;
                string _nossoNumero;

                _segmentoP = "00100013";
                _segmentoP += Utils.FitStringLength(numeroRegistro.ToString(), 5, 5, '0', 0, true, true, true);
                _segmentoP += "P 01";
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Agencia, 5, 5, '0', 0, true, true, true);
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.DigitoAgencia, 1, 1, '0', 0, true, true, true);
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.Conta, 12, 12, '0', 0, true, true, true);
                _segmentoP += Utils.FitStringLength(boleto.Cedente.ContaBancaria.DigitoConta, 1, 1, '0', 0, true, true, true);
                // D�gito verificador  da Ag�ncia/Conta.  Campo n�o tratado pelo BB.  Informar ESPA�O ou ZERO.
                _segmentoP += "0";

                //=====================================================================================================
                //Ajustes efetuados de acordo com manual Julho/2011 - Retirado por jsoda - em 11/05/2012
                //
                //int totalCaracteres = numeroConvenio.Length - 9;
                //_segmentoP += numeroConvenio.Substring(0, totalCaracteres);

                //_nossoNumero = Utils.FitStringLength(boleto.NumeroDocumento, 10, 10, '0', 0, true, true, true);
                //int _total = numeroConvenio.Substring(0, totalCaracteres).Length + _nossoNumero.Length;
                //int subtotal = 0;
                //subtotal = 20 - _total;
                //string _comnplemento = new string(' ', subtotal);
                //_segmentoP += _nossoNumero;
                //_segmentoP += _comnplemento;
                //=====================================================================================================

                switch (boleto.Cedente.Convenio.ToString().Length)
                {
                    case 4:
                        // Se conv�nio de 4 posi��es - normalmente carteira 17 - (0001 � 9999), informar NossoNumero com 11 caracteres, com DV, sendo:
                        // 4 posi��es do n� do conv�nio e 7 posi��es do n� de controle (n� do documento) e DV.
                        _nossoNumero = string.Format("{0}{1}{2}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7), Mod11BancoBrasil(boleto.NossoNumero));
                        break;
                    case 6:
                        // Se conv�nio de 6 posi��es (acima de 10.000 � 999.999), informar NossoNumero com 11 caracteres + DV, sendo:
                        // 6 posi��es do n� do conv�nio e 5 posi��es do n� de controle (n� do documento) e DV do nosso numero.
                        _nossoNumero = string.Format("{0}{1}{2}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 5), Mod11BancoBrasil(boleto.NossoNumero));
                        break;
                    case 7:
                        // Se conv�nio de 7 posi��es (acima de 1.000.000 � 9.999.999), informar NossoNumero com 17 caracteres, sem DV, sendo:
                        // 7 posi��es do n� do conv�nio e 10 posi��es do n� de controle (n� do documento)
                        _nossoNumero = string.Format("{0}{1}", boleto.Cedente.Convenio, Utils.FormatCode(boleto.NossoNumero, 7));
                        break;
                    default:
                        throw new Exception("Posi��es do n� de conv�nio deve ser 4, 6 ou 7.");
                }

                // Importante: Nosso n�mero, alinhar � esquerda com brancos � direita (conforme manual)
                _segmentoP += Utils.FitStringLength(_nossoNumero, 20, 20, ' ', 0, true, true, false);

                // Informar 1 � para carteira 11/12 na modalidade Simples; 
                // 2 ou 3 � para carteira 11/17 modalidade Vinculada/Caucionada e carteira 31; 
                // 4 � para carteira 11/17 modalidade Descontada e carteira 51; 
                // 7 � para carteira 17 modalidade Simples.
                if (boleto.Carteira.Equals("17-019"))
                    _segmentoP += "7";
                else
                    _segmentoP += "0";

                // Campo n�o tratado pelo BB. Forma de cadastramento do t�tulo no banco. Pode ser branco/espa�o, 0, 1=cobran�a registrada, 2=sem registro.
                _segmentoP += "1";
                // Campo n�o tratado pelo BB. Tipo de documento. Pode ser branco, 0, 1=tradicional, 2=escritural.
                _segmentoP += "1";
                // Campo n�o tratado pelo BB. Identifica��o de emiss�o do boleto. Pode ser branco/espa�o, 0, ou:
                // No caso de carteira 11/12/31/51, utilizar c�digo 1 � Banco emite, 4 � Banco reemite, 5 � Banco n�o reemite, por�m nestes dois �ltimos casos, 
                // o c�digo de Movimento Remessa (posi��es 16 a 17) deve ser c�digo '31'.
                // Altera��o de outros dados (para t�tulos que j� est�o registrados no Banco do Brasil). 
                // No caso de carteira 17, podem ser usados os c�digos: 1 � Banco emite, 2 � Cliente emite, 3 � Banco pre-emite e cliente complementa, 6 � Cobran�a sem papel. 
                // Permite ainda, c�digos 4 � Banco reemite e 5 � Banco n�o reemite, por�m o c�digo de Movimento Remessa (posi��es 16 a 17) deve ser c�digo '31' 
                // Altera��o de outros dados (para t�tulos que j� est�o registrados no Banco do Brasil). 
                // Obs.: Quando utilizar c�digo, informar de acordo com o que foi cadastrado para a carteira junto ao Banco do Brasil, consulte seu gerente de relacionamento.
                _segmentoP += "2";
                // Campo n�o tratado pelo BB. Informar 'branco' (espa�o) OU zero ou de acordo com a carteira e quem far� a distribui��o dos bloquetos. 
                // Para carteira 11/12/31/51 utilizar c�digo 1� Banco distribui. 
                // Para carteira 17, pode ser utilizado c�digo 1 � Banco distribui, 2 � Cliente distribui ou 3 � Banco envia e-mail (nesse caso complementar com registro S), 
                // de acordo com o que foi cadastrado para a carteira junto ao Banco do Brasil, consulte seu gerente de relacionamento.
                _segmentoP += "2";
                _segmentoP += Utils.FitStringLength(boleto.NumeroDocumento, 15, 15, ' ', 0, true, true, false);
                _segmentoP += Utils.FitStringLength(boleto.DataVencimento.ToString("ddMMyyyy"), 8, 8, ' ', 0, true, true, false);
                _segmentoP += Utils.FitStringLength(boleto.ValorBoleto.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                _segmentoP += "00000 ";
                _segmentoP += Utils.FitStringLength(boleto.EspecieDocumento.Codigo.ToString(), 2, 2, '0', 0, true, true, true);
                _segmentoP += "N";
                _segmentoP += Utils.FitStringLength(boleto.DataDocumento.ToString("ddMMyyyy"), 8, 8, ' ', 0, true, true, false);

                if (boleto.JurosMora > 0)
                {
                    _segmentoP += "1";
                    _segmentoP += Utils.FitStringLength(boleto.DataVencimento.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, false);
                    _segmentoP += Utils.FitStringLength(boleto.JurosMora.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                }
                else
                {
                    _segmentoP += "3";
                    _segmentoP += "00000000";
                    _segmentoP += "000000000000000";
                }

                if (boleto.ValorDesconto > 0)
                {
                    _segmentoP += "1";
                    _segmentoP += Utils.FitStringLength(boleto.DataVencimento.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, false);
                    _segmentoP += Utils.FitStringLength(boleto.ValorDesconto.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                }
                else
                    _segmentoP += "000000000000000000000000";

                _segmentoP += "000000000000000";
                _segmentoP += "000000000000000";
                _segmentoP += Utils.FitStringLength(boleto.NumeroDocumento, 25, 25, ' ', 0, true, true, false);

                if (boleto.Instrucoes.Count > 1 && boleto.Instrucoes[0].QuantidadeDias > 0)
                {
                    _segmentoP += "2";
                    _segmentoP += Utils.FitStringLength(boleto.Instrucoes[0].QuantidadeDias.ToString(), 2, 2, '0', 0, true, true, true);
                }
                else
                    _segmentoP += "300";

                _segmentoP += "2000090000000000 ";

                _segmentoP = Utils.SubstituiCaracteresEspeciais(_segmentoP);

                return _segmentoP;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do SEGMENTO P DO DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoQRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _zeros16 = new string('0', 16);
                string _brancos28 = new string(' ', 28);
                string _brancos40 = new string(' ', 40);

                string _segmentoQ;

                _segmentoQ = "00100013";
                _segmentoQ += Utils.FitStringLength(numeroRegistro.ToString(), 5, 5, '0', 0, true, true, true);
                _segmentoQ += "Q 01";

                if (boleto.Sacado.CPFCNPJ.Length <= 11)
                    _segmentoQ += "1";
                else
                    _segmentoQ += "2";

                _segmentoQ += Utils.FitStringLength(boleto.Sacado.CPFCNPJ, 15, 15, '0', 0, true, true, true);
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Nome.TrimStart(' '), 40, 40, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.End.TrimStart(' '), 40, 40, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.Bairro.TrimStart(' '), 15, 15, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.CEP, 8, 8, ' ', 0, true, true, false).ToUpper(); ;
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.Cidade.TrimStart(' '), 15, 15, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += Utils.FitStringLength(boleto.Sacado.Endereco.UF, 2, 2, ' ', 0, true, true, false).ToUpper();
                _segmentoQ += _zeros16;
                _segmentoQ += _brancos40;
                _segmentoQ += "000";
                _segmentoQ += _brancos28;

                _segmentoQ = Utils.SubstituiCaracteresEspeciais(_segmentoQ);

                return _segmentoQ;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do SEGMENTO Q DO DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarDetalheSegmentoRRemessa(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            try
            {
                string _brancos110 = new string(' ', 110);
                string _brancos9 = new string(' ', 9);

                string _segmentoR;

                _segmentoR = "00100013";
                _segmentoR += Utils.FitStringLength(numeroRegistro.ToString(), 5, 5, '0', 0, true, true, true);
                _segmentoR += "R 01";
                // Desconto 2
                _segmentoR += "000000000000000000000000"; //24 zeros
                // Desconto 3
                _segmentoR += "000000000000000000000000"; //24 zeros
                // C�digo da multa 2 - percentual
                _segmentoR += "2";
                _segmentoR += Utils.FitStringLength(boleto.DataMulta.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, false);
                _segmentoR += Utils.FitStringLength(boleto.ValorMulta.ToString("0.00").Replace(",", ""), 15, 15, '0', 0, true, true, true);
                _segmentoR += _brancos110;
                _segmentoR += "0000000000000000"; //16 zeros
                _segmentoR += " "; //1 branco
                _segmentoR += "000000000000"; //12 zeros
                _segmentoR += "  "; //2 brancos
                _segmentoR += "0"; //1 zero
                _segmentoR += _brancos9;

                _segmentoR = Utils.SubstituiCaracteresEspeciais(_segmentoR);

                return _segmentoR;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do SEGMENTO R DO DETALHE do arquivo de REMESSA.", ex);
            }
        }

        public string GerarDetalheRemessaCNAB240(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Fun��o n�o implementada.");
        }

        public string GerarDetalheRemessaCNAB400(Boleto boleto, int numeroRegistro, TipoArquivo tipoArquivo)
        {
            throw new NotImplementedException("Fun��o n�o implementada.");
        }

        # endregion DETALHE

        # region TRAILER

        /// <summary>
        /// TRAILER do arquivo CNAB
        /// Gera o TRAILER do arquivo remessa de acordo com o lay-out informado
        /// </summary>
        public override string GerarTrailerRemessa(int numeroRegistro, TipoArquivo tipoArquivo, decimal vltitulostotal)
        {
            try
            {
                string _trailer = " ";

                base.GerarTrailerRemessa(numeroRegistro, tipoArquivo, vltitulostotal);

                switch (tipoArquivo)
                {
                    case TipoArquivo.CNAB240:
                        _trailer = GerarTrailerRemessa240();
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
                throw new Exception("Erro durante a gera��o do TRAILER do arquivo de REMESSA.", ex);
            }
        }

        public string GerarTrailerRemessa240()
        {
            throw new NotImplementedException("Fun��o n�o implementada.");
        }

        public string GerarTrailerRemessa400(int numeroRegistro)
        {
            try
            {
                string complemento = new string(' ', 393);
                string _trailer;

                _trailer = "9";
                _trailer += complemento;
                _trailer += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true); // N�mero sequencial do registro no arquivo.

                _trailer = Utils.SubstituiCaracteresEspeciais(_trailer);

                return _trailer;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do registro TRAILER do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarTrailerLoteRemessa(int numeroRegistro)
        {
            try
            {
                string _brancos217 = new string(' ', 217);

                string _trailerLote;

                _trailerLote = "00100015         ";
                _trailerLote += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true);
                _trailerLote += _brancos217;

                _trailerLote = Utils.SubstituiCaracteresEspeciais(_trailerLote);

                return _trailerLote;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a gera��o do TRAILER de lote do arquivo de REMESSA.", ex);
            }
        }

        public override string GerarTrailerArquivoRemessa(int numeroRegistro)
        {
            try
            {
                string _brancos205 = new string(' ', 205);

                string _trailerArquivo;

                _trailerArquivo = "00199999         000001";
                _trailerArquivo += Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true);
                _trailerArquivo += "000000";
                _trailerArquivo += _brancos205;

                _trailerArquivo = Utils.SubstituiCaracteresEspeciais(_trailerArquivo);

                return _trailerArquivo;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        # endregion

        #endregion

        internal static string Mod11BancoBrasil(string value)
        {
            #region Trecho do manual DVMD11.doc
            /* 
            Multiplicar cada algarismo que comp�e o n�mero pelo seu respectivo multiplicador (PESO).
            Os multiplicadores(PESOS) variam de 9 a 2.
            O primeiro d�gito da direita para a esquerda dever� ser multiplicado por 9, o segundo por 8 e assim sucessivamente.
            O resultados das multiplica��es devem ser somados:
            72+35+24+27+4+9+8=179
            O total da soma dever� ser dividido por 11:
            179 / 11=16
            RESTO=3

            Se o resto da divis�o for igual a 10 o D.V. ser� igual a X. 
            Se o resto da divis�o for igual a 0 o D.V. ser� igual a 0.
            Se o resto for menor que 10, o D.V.  ser� igual ao resto.

            No exemplo acima, o d�gito verificador ser� igual a 3
            */
            #endregion

            /* d - D�gito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            string d;
            int s = 0, p = 9, b = 2;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                s += (int.Parse(value[i].ToString()) * p);
                if (p == b)
                    p = 9;
                else
                    p--;
            }

            int r = (s % 11);
            if (r == 10)
                d = "X";
            else if (r == 0)
                d = "0";
            else
                d = r.ToString();

            return d;
        }

    }
}
