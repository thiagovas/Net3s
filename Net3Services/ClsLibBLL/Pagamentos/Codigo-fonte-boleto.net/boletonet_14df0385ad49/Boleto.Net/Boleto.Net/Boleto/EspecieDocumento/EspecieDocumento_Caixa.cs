using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerador

    public enum EnumEspecieDocumento_Caixa
    {
        Cheque = 1, //CH � CHEQUE
        DuplicataMercantil = 2, //DM � DUPLICATA MERCANTIL
        DuplicataMercantilIndicacao = 3, //DMI � DUPLICATA MERCANTIL P/ INDICA��O
        DuplicataServico = 4, //DS �  DUPLICATA DE SERVI�O
        DuplicataServicoIndicacao = 5, //DSI �  DUPLICATA DE SERVI�O P/ INDICA��O
        DuplicataRural = 6, //DR � DUPLICATA RURAL
        LetraCambio = 7, //LC � LETRA DE CAMBIO
        NotaCreditoComercial = 8, //NCC � NOTA DE CR�DITO COMERCIAL
        NotaCreditoExportacao = 9, //NCE � NOTA DE CR�DITO A EXPORTA��O
        NotaCreditoIndustrial = 10, //NCI � NOTA DE CR�DITO INDUSTRIAL
        NotaCreditoRural = 11, //NCR � NOTA DE CR�DITO RURAL
        NotaPromissoria = 12, //NP � NOTA PROMISS�RIA
        NotaPromissoriaRural = 13, //NPR �NOTA PROMISS�RIA RURAL
        TriplicataMercantil = 14, //TM � TRIPLICATA MERCANTIL
        TriplicataServico = 15, //TS �  TRIPLICATA DE SERVI�O
        NotaSeguro = 16, //NS � NOTA DE SEGURO
        Recibo = 17, //RC � RECIBO
        Fatura = 18, //FAT � FATURA
        NotaDebito = 19, //ND �  NOTA DE D�BITO
        ApoliceSeguro = 20, //AP �  AP�LICE DE SEGURO
        MensalidadeEscolar = 21, //ME � MENSALIDADE ESCOLAR
        ParcelaConsorcio = 22, //PC �  PARCELA DE CONS�RCIO
        Outros = 23 //OUTROS
    }

    #endregion

    public class EspecieDocumento_Caixa : AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores

        public EspecieDocumento_Caixa()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public EspecieDocumento_Caixa(int codigo)
        {
            try
            {
                this.carregar(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        #endregion

        #region Metodos Privados

        private void carregar(int idCodigo)
        {
            try
            {
                this.Banco = new Banco_Caixa();

                switch ((EnumEspecieDocumento_Caixa)idCodigo)
                {
                    case EnumEspecieDocumento_Caixa.Cheque:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.Cheque;
                        this.Especie = "CHEQUE";
                        this.Sigla = "CH";
                        break;
                    case EnumEspecieDocumento_Caixa.DuplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.DuplicataMercantil;
                        this.Especie = "DUPLICATA MERCANTIL";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_Caixa.DuplicataMercantilIndicacao:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.DuplicataMercantilIndicacao;
                        this.Especie = "DUPLICATA MERCANTIL P/ INDICA��O";
                        this.Sigla = "DMI";
                        break;
                    case EnumEspecieDocumento_Caixa.DuplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.DuplicataServico;
                        this.Especie = "DUPLICATA DE SERVI�O";
                        this.Sigla = "DS";
                        break;
                    case EnumEspecieDocumento_Caixa.DuplicataServicoIndicacao:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.DuplicataServicoIndicacao;
                        this.Especie = "DUPLICATA DE SERVI�O P/ INDICA��O";
                        this.Sigla = "DSI";
                        break;
                    case EnumEspecieDocumento_Caixa.DuplicataRural:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.DuplicataRural;
                        this.Especie = "DUPLICATA RURAL";
                        this.Sigla = "DR";
                        break;
                    case EnumEspecieDocumento_Caixa.LetraCambio:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.LetraCambio;
                        this.Especie = "LETRA DE CAMBIO";
                        this.Sigla = "LC";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaCreditoComercial:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaCreditoComercial;
                        this.Especie = "NOTA DE CR�DITO COMERCIAL";
                        this.Sigla = "NCC";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaCreditoExportacao:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaCreditoExportacao;
                        this.Especie = "NOTA DE CR�DITO A EXPORTA��O";
                        this.Sigla = "NCE";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaCreditoIndustrial:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaCreditoIndustrial;
                        this.Especie = "NOTA DE CR�DITO INDUSTRIAL";
                        this.Sigla = "NCI";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaCreditoRural:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaCreditoRural;
                        this.Especie = "NOTA DE CR�DITO RURAL";
                        this.Sigla = "NCR";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaPromissoria:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaPromissoria;
                        this.Especie = "NOTA PROMISS�RIA";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaPromissoriaRural:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaPromissoriaRural;
                        this.Especie = "NOTA PROMISS�RIA RURAL";
                        this.Sigla = "NPR";
                        break;
                    case EnumEspecieDocumento_Caixa.TriplicataMercantil:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.TriplicataMercantil;
                        this.Especie = "TRIPLICATA MERCANTIL";
                        this.Sigla = "TM";
                        break;
                    case EnumEspecieDocumento_Caixa.TriplicataServico:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.TriplicataServico;
                        this.Especie = "TRIPLICATA DE SERVI�O";
                        this.Sigla = "TS";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaSeguro;
                        this.Especie = "NOTA DE SEGURO";
                        this.Sigla = "NS";
                        break;
                    case EnumEspecieDocumento_Caixa.Recibo:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.Recibo;
                        this.Especie = "RECIBO";
                        this.Sigla = "RC";
                        break;
                    case EnumEspecieDocumento_Caixa.Fatura:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.Fatura;
                        this.Especie = "FATURA";
                        this.Sigla = "FAT";
                        break;
                    case EnumEspecieDocumento_Caixa.NotaDebito:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.NotaDebito;
                        this.Especie = "NOTA DE D�BITO";
                        this.Sigla = "ND";
                        break;
                    case EnumEspecieDocumento_Caixa.ApoliceSeguro:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.ApoliceSeguro;
                        this.Especie = "AP�LICE DE SEGURO";
                        this.Sigla = "AP";
                        break;
                    case EnumEspecieDocumento_Caixa.MensalidadeEscolar:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.MensalidadeEscolar;
                        this.Especie = "MENSALIDADE ESCOLAR";
                        this.Sigla = "ME";
                        break;
                    case EnumEspecieDocumento_Caixa.ParcelaConsorcio:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.ParcelaConsorcio;
                        this.Especie = "PARCELA DE CONS�RCIO";
                        this.Sigla = "PC";
                        break;
                    case EnumEspecieDocumento_Caixa.Outros:
                        this.Codigo = (int)EnumEspecieDocumento_Caixa.Outros;
                        this.Especie = "OUTROS";
                        this.Sigla = "OUTROS";
                        break;
                    default:
                        this.Codigo = 0;
                        this.Especie = "( Selecione )";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public static EspeciesDocumento CarregaTodas()
        {
            EspeciesDocumento especiesDocumento = new EspeciesDocumento();

            foreach (EnumEspecieDocumento_Caixa item in Enum.GetValues(typeof(EnumEspecieDocumento_Caixa)))
                especiesDocumento.Add(new EspecieDocumento_Caixa((int)item));

            return especiesDocumento;
        }

        #endregion
    }
}
