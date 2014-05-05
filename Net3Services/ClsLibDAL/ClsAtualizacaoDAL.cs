using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsAtualizacaoDAL
    {
        /// <summary>
        /// Este método insere uma nova atualização no arquivo de feeds de um usuário especifico.
        /// </summary>
        /// <param name="atualizacao">Objeto do tipo Atualizacao que contém os dados a serem inseridos no arquivo de feeds do usuário.</param>
        public void InserirAtualizacao(Atualizacao atualizacao, MongoDB.Oid oidUsuario, bool proprio)
        {
            Document docAtualizacao = new Document();
            docAtualizacao[NomeCompBd.atualizacaoIdUsuario] = oidUsuario;

            List<Document> lstRetornoBusca = new List<Document>();
            Repository rep = new Repository();
                lstRetornoBusca = rep.Procurar(docAtualizacao, NomeCompBd.collecAtualizacoes); //Busco as atualizações do usuário com o Oid informado.
            

            if (lstRetornoBusca != null && lstRetornoBusca.Count > 0)
            {
                Predicate<Document> prdExisteDoc = new Predicate<Document>(delegate(Document doc)
                    {
                        return Convert.ToInt32(doc[NomeCompBd.atualizacaoTipo]) == Convert.ToInt32(proprio);
                    });

                //Filtro a lista lstRetornoBusca e seleciono somente o documento que contém as atualizações do usuário que tem o Oid informado
                docAtualizacao = lstRetornoBusca.Find(prdExisteDoc);

                List<Document> lstAtualizacao = new List<Document>();

                //Se o documento que contém as atualizações proprias do usuário que tem o Oid informado
                if (docAtualizacao != null && docAtualizacao.Count > 0)
                {
                    //Gravo na lstAtualizacao os dados que vem do banco de dados.
                    lstAtualizacao = (List<Document>)docAtualizacao[NomeCompBd.atualizacaoArrayLista];
                }
                else
                {
                    //Se o documento que contém as atualizações proprias do usuário que tem o Oid informado for nulo ou se for vazio
                    //Adiciono dois campos à docAtualização: O Oid do usuário e o tipo do documento.
                    //Adiciono esses dois campos pq será criado um novo documento, ou seja, o documento que criarei nao existe no banco de dados.
                    docAtualizacao = new Document();
                    docAtualizacao[NomeCompBd.atualizacaoIdUsuario] = oidUsuario;
                    docAtualizacao[NomeCompBd.atualizacaoTipo] = Convert.ToInt32(proprio);
                }
                lstAtualizacao.Add(MontarDocumento(atualizacao));
                docAtualizacao[NomeCompBd.atualizacaoArrayLista] = lstAtualizacao;

                rep.Save(docAtualizacao, NomeCompBd.collecAtualizacoes);
            }
            else // Se não existir um documento de atualizações do usuário irei cria-lo e gravar no banco de dados.
            {
                docAtualizacao = new Document();
                docAtualizacao[NomeCompBd.atualizacaoIdUsuario] = oidUsuario;
                docAtualizacao[NomeCompBd.atualizacaoTipo] = Convert.ToInt32(proprio);
                List<Atualizacao> lstAt = new List<Atualizacao>();
                lstAt.Add(atualizacao);
                docAtualizacao[NomeCompBd.atualizacaoArrayLista] = MontarListaDocumento(lstAt);

                rep.Save(docAtualizacao, NomeCompBd.collecAtualizacoes);                
            }
        }

        /// <summary>
        /// Busca atualizações do usuário ou de seus contatos, dependendo do segundo parâmetro
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário, usado como filtro da busca.</param>
        /// <param name="atualizacaoTipo">True para buscar atualizações do usuário, e false para buscar atualizações de seus contatos.</param>
        /// <returns>Retorna uma lista de objetos do tipo Atualizacao.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Atualizacao> BuscarAtualizacoes(Oid oidUsuario, bool atualizacaoTipo)
        {
            Document doc = new Document();
            doc[NomeCompBd.atualizacaoIdUsuario] = oidUsuario;
            doc[NomeCompBd.atualizacaoTipo] = Convert.ToInt32(atualizacaoTipo);
            Repository rep = new Repository();
                List<Document> lstRetorno = rep.Procurar(doc, NomeCompBd.collecAtualizacoes);
                return lstRetorno.Count > 0 ? MontarListaObjeto(lstRetorno[0]) : null;
            
        }

        /// <summary>
        /// Exlcuir todas as atualizações de um usuário.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirAtualizacoes(Oid idUsuario)
        {
            Document doc = new Document();
            doc[NomeCompBd.atualizacaoIdUsuario] = idUsuario;
            Repository rep = new Repository();
                rep.delete(doc, NomeCompBd.collecAtualizacoes);
            
        }

        /// <summary>
        /// Monta o documento do objeto do tipo Atualizacao informado.
        /// </summary>
        /// <param name="atualizacao">Objeto do tipo Atualizacao que será convertido para Documento.</param>
        /// <returns>Retorna um objeto do tipo Document com os dados que estao presentes no objeto informado.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumento(Atualizacao atualizacao)
        {
            Document doc = new Document();
            doc[NomeCompBd.atualizacaoArrayListaCreatedTime] = atualizacao.CreatedTime;
            doc[NomeCompBd.atualizacaoArrayListaMensagem] = atualizacao.Mensagem;
            doc[NomeCompBd.atualizacaoArrayListaNomeUsu] = atualizacao.NomeUsuario;
            doc[NomeCompBd.atualizacaoArrayListaOidUsu] = atualizacao.OidUsuario;
            doc[NomeCompBd.atualizacaoArrayTipoAtualizacao] = Convert.ToInt32(atualizacao.tipoAtualizacao);

            return doc;
        }

        /// <summary>
        /// Monta uma lista de documentos a partir de uma lista de objetos do tipo Atualizacao.
        /// </summary>
        /// <param name="lstAtualizacao">Lista de objetos do tipo Atualizacao que será convertida em uma lista de objetos do tipo Document.</param>
        /// <returns>Retorna uma lista de objetos do tipo Document.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> MontarListaDocumento(List<Atualizacao> lstAtualizacao)
        {
            List<Document> lstDoc = new List<Document>();
            foreach (Atualizacao item in lstAtualizacao)
            {
                lstDoc.Add(MontarDocumento(item));
            }
            return lstDoc;
        }

        /// <summary>
        /// Monta uma lista de objetos do tipo Atualizacao a partir de um documento de atualizacao.
        /// </summary>
        /// <param name="docAtualizacao">Documento da collection Atualizações.</param>
        /// <returns>Retorna uma lista de objetos do tipo Atualizacao.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Atualizacao> MontarListaObjeto(Document docAtualizacao)
        {
            List<Document> lstDocument = new List<Document>();
            List<Atualizacao> lstAtualizacao = new List<Atualizacao>();
            lstDocument = (List<Document>)docAtualizacao[NomeCompBd.atualizacaoArrayLista];
            Action<Document> actPreencherLstAtualizacao = new Action<Document>(delegate(Document docAtualiz)
                {
                    lstAtualizacao.Add(MontarObjeto(docAtualiz));
                });
            lstDocument.ForEach(actPreencherLstAtualizacao);
            return lstAtualizacao;
        }

        /// <summary>
        /// Monta um objeto do tipo Atualizacao a partir de um documento.
        /// </summary>
        /// <param name="doc">Documento que será convertido em um objeto do tipo Atualizacao.</param>
        /// <returns>Retorna um objeto do tipo Atualizacao.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private Atualizacao MontarObjeto(Document doc)
        {
            Atualizacao atualiz = new Atualizacao();
            atualiz.CreatedTime = doc[NomeCompBd.atualizacaoArrayListaCreatedTime] != null ? Convert.ToDateTime(doc[NomeCompBd.atualizacaoArrayListaCreatedTime]) : DateTime.MinValue;
            atualiz.Mensagem = doc[NomeCompBd.atualizacaoArrayListaMensagem] != null ? doc[NomeCompBd.atualizacaoArrayListaMensagem].ToString() : null;
            atualiz.NomeUsuario = doc[NomeCompBd.atualizacaoArrayListaNomeUsu] != null ? doc[NomeCompBd.atualizacaoArrayListaNomeUsu].ToString() : null;
            atualiz.OidUsuario = doc[NomeCompBd.atualizacaoArrayListaOidUsu] != null ? new Oid(doc[NomeCompBd.atualizacaoArrayListaOidUsu].ToString()) : null;
            if (doc[NomeCompBd.atualizacaoTipo] != null)
                switch (Convert.ToInt32(doc[NomeCompBd.atualizacaoTipo]))
                {
                    case 0:
                        atualiz.tipoAtualizacao = TipoAtualizacao.contato;
                        break;
                    case 1:
                        atualiz.tipoAtualizacao = TipoAtualizacao.serviço;
                        break;
                }
            else
                atualiz.tipoAtualizacao = null;

            return atualiz;
        }
    }
}
