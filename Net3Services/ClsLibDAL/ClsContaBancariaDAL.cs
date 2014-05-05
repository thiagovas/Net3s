using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsContaBancariaDAL
    {
        /// <summary>
        /// Método que insere uma conta bancária no documento de usuário.
        /// </summary>
        /// <param name="obj">Objeto a ser inserido no documento de usuário.</param>
        /// <param name="idUsuario">Id do usuário.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirConta(InformacoesBancarias obj, Oid idUsuario)
        {
            Repository rep = new Repository();
            Document doc = rep.ProcurarUm(new Document(NomeCompBd.usuario_id, idUsuario), NomeCompBd.collecUsuarios);
            Document docConta = MontarDocumentoSemId(obj);
            docConta[NomeCompBd.usuContaBancId] = new OidGen().Generate();

            List<Document> lstContas = doc[NomeCompBd.usuArrayContasBancarias] != null ? (List<Document>)doc[NomeCompBd.usuArrayContasBancarias] : new List<Document>();
            lstContas.Add(docConta);
            doc[NomeCompBd.usuArrayContasBancarias] = lstContas;
            rep.Save(doc, NomeCompBd.collecUsuarios);
        }

        /// <summary>
        /// Edita uma conta bancária de um usuário.
        /// </summary>
        /// <param name="obj">Objeto da conta bancária.</param>
        public void EditarConta(InformacoesBancarias obj, Oid idUsuario)
        { 
            
        }

        /// <summary>
        /// Exclui uma conta bancária do banco.
        /// </summary>
        /// <param name="idContaBancaria">Id da conta bancária.</param>
        public void ExcluirConta(Oid idContaBancaria, Oid idUsu)
        {
            Repository rep = new Repository();
            ClsUsuDAL usuDAL = new ClsUsuDAL();
            Document docUsu = rep.ProcurarUm(new Document(NomeCompBd.usuario_id, idUsu), NomeCompBd.collecUsuarios);
            Usuario usu = usuDAL.MontarObjeto(docUsu);

            Predicate<InformacoesBancarias> predInfBanc = new Predicate<InformacoesBancarias>(delegate(InformacoesBancarias i){
                return i.idContaBancaria == idContaBancaria;
            });

            usu.contaBanc.RemoveAt(usu.contaBanc.FindIndex(predInfBanc));
            rep.Save(usuDAL.MontarDocumento(usu), NomeCompBd.collecUsuarios);
        }

        /// <summary>
        /// Busca a lista de contas bancárias de um usuário.
        /// </summary>
        /// <param name="idUsuario">Id do usuário, usado como filtro de busca.</param>
        /// <returns>Retorna uma lista de objetos do tipo ContaBancaria.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<InformacoesBancarias> BuscarContasPorIdUsuario(Oid idUsuario)
        {
            Repository rep = new Repository();
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsuario;
            List<Document> lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            if (lstResposta != null && lstResposta.Count > 0)
            {
                return lstResposta[0][NomeCompBd.usuArrayContasBancarias] != null ? 
                    MontarListaObjetos((List<Document>)lstResposta[0][NomeCompBd.usuArrayContasBancarias])
                    : null;
            }
            else
                return null;
        }

        /// <summary>
        /// Busca uma conta bancária pelo seu id.
        /// </summary>
        /// <param name="idContaBancaria">Id da conta bancária, usado como filtro para a busca.</param>
        /// <returns>Retorna um objeto do tipo ContaBancaria.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public InformacoesBancarias BuscarContaPorId(Oid idContaBancaria)
        {
            Document retorno = BuscarDocContaPorId(idContaBancaria);
            return retorno != null ? MontarObjeto(retorno) : null;
        }

        /// <summary>
        /// Função que busca o documento de uma conta bancária.
        /// </summary>
        /// <param name="idContaBancaria">Id da conta bancária.</param>
        /// <returns>Retorna um documento da conta bancária.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private Document BuscarDocContaPorId(Oid idContaBancaria)
        {
            Document doc = new Document();
            List<Document> lstContas = new List<Document>();
            Document docConta = new Document();
            Document docElemMatch = new Document();
            docElemMatch.Add(NomeCompBd.usuContaBancId, idContaBancaria);
            docConta.Add("$elemMatch", docElemMatch);
            lstContas.Add(docConta);
            doc.Add(NomeCompBd.usuArrayContasBancarias, lstContas);

            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
            lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);

            if (lstResposta != null && lstResposta.Count > 0)
            {
                if (lstResposta[0][NomeCompBd.usuArrayContasBancarias] != null)
                {
                    lstContas = (List<Document>)lstResposta[0][NomeCompBd.usuArrayContasBancarias];
                    Predicate<Document> prdProcurarConta = new Predicate<Document>(delegate(Document x)
                    {
                        return (Oid)x[NomeCompBd.usuContaBancId] == idContaBancaria;
                    });

                    return lstContas.Find(prdProcurarConta);
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Função que monta um documento a partir de um objeto do tipo ContaBancaria.
        /// </summary>
        /// <param name="obj">Objeto usado para montar o documento.</param>
        /// <returns>Retorna um documento que foi montado a partir de um objeto do tipo ContaBancaria.</returns>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        public Document MontarDocumento(InformacoesBancarias obj)
        {
            Document doc = MontarDocumentoSemId(obj);
            doc[NomeCompBd.usuContaBancId] = obj.idContaBancaria;
            return doc;
        }

        /// <summary>
        /// Função que monta um documento sem id a partir de um objeto do tipo ContaBancaria.
        /// </summary>
        /// <param name="obj">Objeto usado para montar o documento.</param>
        /// <returns>Retorna um documento, sem id, que foi montado a partir de um objeto do tipo ContaBancaria.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumentoSemId(InformacoesBancarias obj)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuContaBancAgencia] = obj.Agencia;
            doc[NomeCompBd.usuContaBancBanco] = Convert.ToInt32(obj.Banco);
            doc[NomeCompBd.usuContaBancConta] = obj.Conta;
            doc[NomeCompBd.usuContaBancDigitoAgencia] = obj.DigitoAgencia;
            doc[NomeCompBd.usuContaBancDigitoConta] = obj.DigitoConta;
            doc[NomeCompBd.usuContaBancCodigoCedente] = obj.CodigoCedente;
            return doc;
        }

        /// <summary>
        /// Função que monta um objeto do tipo ContaBancaria a partir de um documento.
        /// </summary>
        /// <param name="doc">Documento usado para montar o objeto.</param>
        /// <returns>Retorna um objeto do tipo ContaBancaria.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public InformacoesBancarias MontarObjeto(Document doc)
        {
            InformacoesBancarias obj = new InformacoesBancarias();
            obj.idContaBancaria = doc[NomeCompBd.usuContaBancId] != null ? new Oid(doc[NomeCompBd.usuContaBancId].ToString()) : null;
            obj.Agencia = doc[NomeCompBd.usuContaBancAgencia] != null ? Convert.ToInt32(doc[NomeCompBd.usuContaBancAgencia]) : -1;
            obj.DigitoAgencia = doc[NomeCompBd.usuContaBancDigitoAgencia] != null ? Convert.ToInt32(doc[NomeCompBd.usuContaBancDigitoAgencia]) : -1;
            if (doc[NomeCompBd.usuContaBancBanco] != null)
            {
                switch (Convert.ToInt32(doc[NomeCompBd.usuContaBancBanco]))
                { 
                    case 1:
                        obj.Banco = bancos.BancoBrasil;
                        break;
                    case 33:
                        obj.Banco = bancos.BancoSantander;
                        break;
                    case 104:
                        obj.Banco = bancos.CaixaEconomicaFederal;
                        break;
                    case 237:
                        obj.Banco = bancos.BancoBradesco;
                        break;
                    case 341:
                        obj.Banco = bancos.BancoItau;
                        break;
                    case 409:
                        obj.Banco = bancos.BancoUnibanco;
                        break;
                    case 422:
                        obj.Banco = bancos.BancoSafra;
                        break;
                }
            }
            obj.Conta = doc[NomeCompBd.usuContaBancConta] != null ? Convert.ToInt32(doc[NomeCompBd.usuContaBancConta]) : -1;
            obj.DigitoConta = doc[NomeCompBd.usuContaBancDigitoAgencia] != null ? Convert.ToInt32(doc[NomeCompBd.usuContaBancDigitoAgencia]) : -1;
            obj.CodigoCedente = doc[NomeCompBd.usuContaBancCodigoCedente] != null ? Convert.ToInt32(doc[NomeCompBd.usuContaBancCodigoCedente]) : 0;

            return obj;
        }

        /// <summary>
        /// Função que monta uma lista de documentos a partir de uma lista de objetos.
        /// </summary>
        /// <param name="lstObj">Lista de objetos do tipo ContaBancaria.</param>
        /// <returns>Retorna uma lista de objetos do tipo Document.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> MontarListaDocumentos(List<InformacoesBancarias> lstObj)
        {
            if (lstObj == null) return null;
            List<Document> lst = new List<Document>();
            foreach(InformacoesBancarias obj in lstObj)
            {
                lst.Add(MontarDocumento(obj));
            }
            return lst;
        }

        /// <summary>
        /// Função que monta uma lista de objetos a partir de uma lista de documentos.
        /// </summary>
        /// <param name="lstDoc">Lista de documentos.</param>
        /// <returns>Retorna uma lista de objetos do tipo ContaBancaria.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<InformacoesBancarias> MontarListaObjetos(List<Document> lstDoc)
        {
            List<InformacoesBancarias> lst = new List<InformacoesBancarias>();
            foreach (Document doc in lstDoc)
            {
                lst.Add(MontarObjeto(doc));
            }
            return lst;
        }
    }
}