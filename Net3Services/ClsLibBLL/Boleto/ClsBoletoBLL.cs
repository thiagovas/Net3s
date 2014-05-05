using System;
using BoletoNet;
using Models;
using MongoDB;

namespace ClsLibBLL.Boleto
{
    public class ClsBoletoBLL
    {
        /// <summary>
        /// Método que gera um boleto bancário.
        /// </summary>
        /// <param name="idOrcamento">Id do orçamento</param>
        /// <param name="idContaBancaria">Id da conta bancária a ser usada para a emissão do boleto, a conta é do prestador</param>
        /// <param name="Vencimento">Vencimento do boleto.</param>
        /// <param name="CodigoCedente">Código do prestador no banco em que ele tem conta.</param>
        /// <param name="carteira">Não sei ainda o q é.</param>
        /// <param name="nossoNumero">Não sei ainda o q é.</param>
        /// <param name="numeroDocumento">Não sei ainda o q é.</param>
        /// <returns>Retorna um objeto do tipo BoletoBancario.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public BoletoBancario GerarBoleto(Oid idOrcamento, Oid idContaBancaria, DateTime Vencimento, int CodigoCedente,
                              string carteira, string nossoNumero, string numeroDocumento, string descricaoBoleto)
        {
            if (Vencimento <= DateTime.Today) throw new Exception("Vencimento inválido. O vencimento tem que ser de no mínimo um dia após a emissão do boleto.");

            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            ClsOrcamentoBLL orcamentoBLL = new ClsOrcamentoBLL();
            ClsContaBancariaBLL contaBancariaBLL = new ClsContaBancariaBLL();

            Orcamento objOrcamento = orcamentoBLL.BuscarOrcamentoPorID(idOrcamento);
            Usuario objPrestador = usuarioBLL.BuscarUsuarioPorID(objOrcamento.prestador);
            Usuario objContratante = usuarioBLL.BuscarUsuarioPorID(objOrcamento.contratante);
            Models.InformacoesBancarias contBanc = contaBancariaBLL.BuscarContaPorId(idContaBancaria);
            
            BoletoBancario bb = new BoletoBancario();
            bb.MostrarComprovanteEntrega = false;
            bb.CodigoBanco = Convert.ToInt16(contBanc.Banco);

            Cedente ced = new Cedente(objPrestador.cpf_cnpj, objPrestador.nome, contBanc.Agencia.ToString(), contBanc.DigitoAgencia.ToString(),
                contBanc.Conta.ToString(), contBanc.DigitoConta.ToString());

            //É necessário informar o código do cedente(o banco fornece este código), algumas carteiras exigem este código.
            ced.Codigo = CodigoCedente;

            BoletoNet.Boleto b = new BoletoNet.Boleto(Vencimento, objOrcamento.preco, carteira, nossoNumero, ced);
            b.NumeroDocumento = numeroDocumento; //Dependendo da carteira é necessário o número do documento.
            b.Sacado = new Sacado(objContratante.cpf_cnpj, objContratante.nome);

            if(String.IsNullOrEmpty(descricaoBoleto))
                descricaoBoleto = "Não receber após o vencimento";


            //Espécie.
            //Cheque = 1, //CH – CHEQUE
            //DuplicataMercantil = 2, //DM – DUPLICATA MERCANTIL
            //DuplicataMercantilIndicacao = 3, //DMI – DUPLICATA MERCANTIL P/ INDICAÇÃO
            //DuplicataServico = 4, //DS – DUPLICATA DE SERVIÇO
            //DuplicataServicoIndicacao = 5, //DSI – DUPLICATA DE SERVIÇO P/ INDICAÇÃO
            //DuplicataRural = 6, //DR – DUPLICATA RURAL
            //LetraCambio = 7, //LC – LETRA DE CAMBIO
            //NotaCreditoComercial = 8, //NCC – NOTA DE CRÉDITO COMERCIAL
            //NotaCreditoExportacao = 9, //NCE – NOTA DE CRÉDITO A EXPORTAÇÃO
            //NotaCreditoIndustrial = 10, //NCI – NOTA DE CRÉDITO INDUSTRIAL
            //NotaCreditoRural = 11, //NCR – NOTA DE CRÉDITO RURAL
            //NotaPromissoria = 12, //NP – NOTA PROMISSÓRIA
            //NotaPromissoriaRural = 13, //NPR –NOTA PROMISSÓRIA RURAL
            //TriplicataMercantil = 14, //TM – TRIPLICATA MERCANTIL
            //TriplicataServico = 15, //TS – TRIPLICATA DE SERVIÇO
            //NotaSeguro = 16, //NS – NOTA DE SEGURO
            //Recibo = 17, //RC – RECIBO
            //Fatura = 18, //FAT – FATURA
            //NotaDebito = 19, //ND – NOTA DE DÉBITO
            //ApoliceSeguro = 20, //AP – APÓLICE DE SEGURO
            //MensalidadeEscolar = 21, //ME – MENSALIDADE ESCOLAR
            //ParcelaConsorcio = 22, //PC – PARCELA DE CONSÓRCIO
            //Outros = 23 //OUTROS

            switch (contBanc.Banco)
            { 
                case bancos.BancoBrasil:
                    Instrucao_BancoBrasil i1 = new Instrucao_BancoBrasil();
                    i1.Descricao = descricaoBoleto;
                    b.Instrucoes.Add(i1);
                    b.EspecieDocumento = new EspecieDocumento_BancoBrasil(2);
                    break;
                case bancos.BancoSantander:
                    Instrucao_Santander i2 = new Instrucao_Santander();
                    i2.Descricao = descricaoBoleto;
                    b.Instrucoes.Add(i2);
                    b.EspecieDocumento = new EspecieDocumento_Santander(17);
                    break;
                case bancos.BancoBradesco:
                    Instrucao_Bradesco i3 = new Instrucao_Bradesco();
                    i3.Descricao = descricaoBoleto;
                    b.Instrucoes.Add(i3);
                    b.EspecieDocumento = new EspecieDocumento_Bradesco(17);
                    break;
                case bancos.BancoItau:
                    Instrucao_Itau i4 = new Instrucao_Itau();
                    i4.Descricao = descricaoBoleto;
                    b.Instrucoes.Add(i4);
                    b.EspecieDocumento = new EspecieDocumento_Itau(99); //TODO: Entender pq tenho q informar 99 como parâmetro.
                    break;
                case bancos.BancoSafra:
                    Instrucao_Safra i5 = new Instrucao_Safra();
                    i5.Descricao = descricaoBoleto;
                    b.Instrucoes.Add(i5);
                    b.EspecieDocumento = new EspecieDocumento(Convert.ToInt32(bancos.BancoSafra), 17);
                    break;
                case bancos.BancoUnibanco:
                    Instrucao i6 = new Instrucao(Convert.ToInt32(bancos.BancoUnibanco));
                    i6.Descricao = descricaoBoleto;
                    b.Instrucoes.Add(i6);
                    b.EspecieDocumento = new EspecieDocumento(Convert.ToInt32(bancos.BancoUnibanco), 17);
                    break;
                case bancos.CaixaEconomicaFederal:
                    Instrucao_Caixa i7 = new Instrucao_Caixa();
                    i7.Descricao = descricaoBoleto;
                    b.Instrucoes.Add(i7);
                    b.EspecieDocumento = new EspecieDocumento_Caixa(17);
                    break;
            }
            
            b.Valida();
            bb.Boleto = b;
            return bb;
        }
    }
}