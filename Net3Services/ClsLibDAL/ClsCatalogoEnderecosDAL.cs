using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsCatalogoEnderecosDAL
    {
        /// <summary>
        /// Insere os dados dos objetos da lista de objetos do tipo CatalogoEndereco no banco de dados.
        /// </summary>
        /// <param name="lstCatEnd">Lista de objetos do tipo CatalogoEndereco que tem os dados a serem inseridos no banco de dados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Inserir(List<CatalogoEndereco> lstCatEnd)
        {
            Repository rep = new Repository();
                rep.Insert(MontarIEnumerableDocumento(lstCatEnd), NomeCompBd.collecCatalogoEnderecos);
            
        }

        /// <summary>
        /// Insere os dados do objeto do tipo CatalogoEndereco no banco de dados.
        /// </summary>
        /// <param name="catEnd">Objeto com os dados a serem inseridos no banco de dados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Inserir(CatalogoEndereco catEnd)
        {
            Repository rep = new Repository();
                rep.Insert(MontarDocumento(catEnd), NomeCompBd.collecCatalogoEnderecos);
            
        }

        /// <summary>
        /// Este método inseri um pais na collection CatalogoEnderecos. Método usado somente por administrador.
        /// </summary>
        /// <param name="pais">Nome do pais que será inserido na collection CatalogoEnderecos.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirPais(string pais)
        {
            /*
             * {
             *  Pais: "",
             *  Ufs: [
             *      {
             *          Uf: "",
             *          Cidades: [
             *              {
             *                  Cidade: "",
             *                  Cidade: "",
             *              }
             *          ]
             *      },
             *      {
             *          Uf: "",
             *          Cidades: [
             *              {
             *                  Cidade: "",
             *                  Cidade: "",
             *              }
             *          ]
             *      }
             *  ]
             * }
             */
            Document docPais = new Document();
            Document docUf = new Document();
            List<Document> lstDocUf = new List<Document>();
            List<string> lstDocCidade = new List<string>();

            docPais[NomeCompBd.catEnderecosPais] = pais;
            docUf.Add(NomeCompBd.catEnderecosUf, string.Empty);
            docUf.Add(NomeCompBd.catEnderecosArrayCidades, lstDocCidade);
            lstDocUf.Add(docUf);
            docPais.Add(NomeCompBd.catEnderecosArrayUf, lstDocUf);

            Repository rep = new Repository();
                rep.Insert(docPais, NomeCompBd.collecCatalogoEnderecos);
            
        }

        public List<string> BuscarEstadosPorPais(string pais)
        {
            Document doc = new Document();
            doc[NomeCompBd.catEnderecosPais] = pais;
            List<Document> lstResultado = new List<Document>();

            Repository rep = new Repository();
                lstResultado = rep.Procurar(doc, NomeCompBd.collecCatalogoEnderecos);
            

            if (lstResultado.Count > 0)
            {
                List<string> lstRetorno = new List<string>();
                foreach (Document item in (List<Document>)(lstResultado[0][NomeCompBd.catEnderecosArrayUf]))
                {
                    lstRetorno.Add(item[NomeCompBd.catEnderecosUf].ToString());
                }
                return lstRetorno;
            }
            else
            {
                return null;
            }

        }

        public List<string> BuscarCidadesPorUf(string uf)
        {
            /*
             Exemplo do site do Mongo(mongodb.org): 
             
             > t.find( { x : { $elemMatch : { a : 1, b : { $gt : 1 } } } } )
            
            { "_id" : ObjectId("4b5783300334000000000aa9"),
              "x" : [ { "a" : 1, "b" : 3 }, 7, { "b" : 99 }, { "a" : 11 } ]
            }
             */
            Document docPais = new Document();
            Document docArrayUfs = new Document();
            Document docUf = new Document();
            docUf.Add(NomeCompBd.catEnderecosUf, uf);
            docArrayUfs.Add("$elemMatch", docUf);
            docPais.Add(NomeCompBd.catEnderecosArrayUf, docArrayUfs);

            //{ NomeCompBd.catEnderecosArrayUf : { $elemMatch : { NomeCompBd.catEnderecosUf : uf } } }

            List<Document> lstResultado = new List<Document>();

            Repository rep = new Repository();
                lstResultado = rep.Procurar(docPais, NomeCompBd.collecCatalogoEnderecos);
            

            if (lstResultado.Count > 0)
            {
                List<string> lstRetorno = new List<string>();
                foreach (Document item in (List<Document>)(lstResultado[0][NomeCompBd.catEnderecosArrayUf]))
                {
                    if (item[NomeCompBd.catEnderecosUf].ToString().Equals(uf))
                    {
                        foreach (Document cidade in (List<Document>)(item[NomeCompBd.catEnderecosArrayCidades]))
                        {
                            lstRetorno.Add(cidade[NomeCompBd.catEnderecosCidade].ToString());
                        }
                    }
                }
                return lstRetorno;
            }
            else
            {
                return null;
            }
        }

        public List<string> BuscarPaises()
        {
            Repository rep = new Repository();
                List<Document> lstResultado = rep.ProcurarTodos(NomeCompBd.collecCatalogoEnderecos);
                List<string> lstRetorno = new List<string>();
                Action<Document> MontarListaRetorno = new Action<Document>(delegate(Document doc)
                    {
                        lstRetorno.Add(doc[NomeCompBd.catEnderecosPais].ToString());
                    });
                lstResultado.ForEach(MontarListaRetorno);
                return lstRetorno;
            
        }

        /// <summary>
        /// Busca todos os endereços do catalogo.
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tipo CatalogoEndereco.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<CatalogoEndereco> BuscarTodosEnderecos()
        {
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
                lstResposta = rep.ProcurarTodos(NomeCompBd.collecCatalogoEnderecos);
            
            return MontarListaObjeto(lstResposta);
        }

        /// <summary>
        /// Monta uma lista de objetos do tipo CatalogoEndereco a partir de uma lista de documentos.
        /// </summary>
        /// <param name="lstDocument">Lista de documentos usada como base para montar a lista de objetos do tipo CatalogoEnderecos.</param>
        /// <returns>Retorna uma lista de objetos do tipo CatalogoEnderecos montada a partir de uma lista de documentos.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private List<CatalogoEndereco> MontarListaObjeto(List<Document> lstDocument)
        {
            if (lstDocument == null)
            { return null; }
            else
            { 
                List<CatalogoEndereco> lstRetorno = new List<CatalogoEndereco>();
                Action<Document> actMontarListaObjetos = new Action<Document>(delegate(Document x)
                    {
                        lstRetorno.Add(MontarObjeto(x));
                    });
                lstDocument.ForEach(actMontarListaObjetos);
                return lstRetorno;
            }
        }

        /// <summary>
        /// Monta um objeto do tipo CatalogoEndereco a partir de um documento.
        /// </summary>
        /// <param name="doc">Documento usado como base para montar o objeto do tipo CatalogoEndereco.</param>
        /// <returns>Retorna um objeto do tipo CatalogoEndereco montado a partir de um documento.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public CatalogoEndereco MontarObjeto(Document doc)
        {
            if (doc == null)
                return new CatalogoEndereco();

            CatalogoEndereco catEnd = new CatalogoEndereco();
            #region === Preencher pais ===
            catEnd.pais = new Pais();
            catEnd.pais.id = doc[NomeCompBd.catEnderecosIdPais] != null ? new Oid(doc[NomeCompBd.catEnderecosIdPais].ToString()) : null;
            catEnd.pais.nomePais = doc[NomeCompBd.catEnderecosPais] != null ? doc[NomeCompBd.catEnderecosPais].ToString() : null;
            #endregion

            #region === Preencher estados ===
            catEnd.pais.estados = new List<Estado>();
            if (doc[NomeCompBd.catEnderecosArrayUf] != null)
            {
                if (doc[NomeCompBd.catEnderecosArrayUf].GetType() == typeof(List<Document>))
                {
                    #region === Preenchar cidades ===
                    List<Cidade> lstCidades = new List<Cidade>();
                    Action<Document> actMontarObjCidade = new Action<Document>(delegate(Document docCidade)
                        {
                            Cidade cid = new Cidade();
                            cid.id = docCidade[NomeCompBd.catEnderecosIdCidade] != null ? new Oid(docCidade[NomeCompBd.catEnderecosIdCidade].ToString()) : null;
                            cid.nomeCidade = docCidade[NomeCompBd.catEnderecosCidade] != null ? docCidade[NomeCompBd.catEnderecosCidade].ToString() : null;
                            lstCidades.Add(cid);
                        });
                    #endregion

                    Action<Document> actMontarObjEstado = new Action<Document>(delegate(Document docEst)
                        {
                            Estado est = new Estado();
                            est.id = docEst[NomeCompBd.catEnderecosIdUf] != null ? new Oid(docEst[NomeCompBd.catEnderecosIdUf].ToString()) : null;
                            est.nomeEstado = docEst[NomeCompBd.catEnderecosUf] != null ? docEst[NomeCompBd.catEnderecosUf].ToString() : null;
                            est.cidades = new List<Cidade>();
                            if (docEst[NomeCompBd.catEnderecosArrayCidades] != null)
                            {
                                if (docEst[NomeCompBd.catEnderecosArrayCidades].GetType() == typeof(List<Document>))
                                {
                                    lstCidades = new List<Cidade>();
                                    ((List<Document>)docEst[NomeCompBd.catEnderecosArrayCidades]).ForEach(actMontarObjCidade);
                                    est.cidades = lstCidades;
                                }
                            }
                            catEnd.pais.estados.Add(est);
                        });
                    ((List<Document>)doc[NomeCompBd.catEnderecosArrayUf]).ForEach(actMontarObjEstado);
                }
            }
            #endregion

            return catEnd;
        }

        /// <summary>
        /// Monta um documento a partir de um objeto do tipo CatalogoEndereco.
        /// </summary>
        /// <param name="objCatEnd">Objeto do tipo CatalogoEndereco usado como base para montar o documento.</param>
        /// <returns>Retorna um objeto do tipo Document com os dados que estavam presentes no objeto mandado como parâmetro.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private Document MontarDocumento(CatalogoEndereco objCatEnd)
        {
            //Documento que representa um pais e irá guardar o array Ufs que contém os seus estados mais as cidades de cada estado.
            Document docPais = new Document();
            List<Document> lstDocUfs = new List<Document>();
            docPais[NomeCompBd.catEnderecosIdPais] = objCatEnd.pais.id;
            docPais[NomeCompBd.catEnderecosPais] = objCatEnd.pais.nomePais;

            //Percorre a lista de estados de um pais para criar o array de Ufs.
            foreach (Estado item in objCatEnd.pais.estados)
            {
                Document docUf = new Document();
                List<Document> lstDocCidades = new List<Document>();
                docUf[NomeCompBd.catEnderecosUf] = item.nomeEstado;
                docUf[NomeCompBd.catEnderecosIdUf] = item.id;

                //Percorre a lista de cidades de cada estado para criar a lista de cidades de cada estado..
                foreach (Cidade cid in item.cidades)
                {
                    Document docCidade = new Document();
                    docCidade[NomeCompBd.catEnderecosIdCidade] = cid.id;
                    docCidade[NomeCompBd.catEnderecosCidade] = cid.nomeCidade;
                    lstDocCidades.Add(docCidade);
                }
                docUf[NomeCompBd.catEnderecosArrayCidades] = lstDocCidades;
                lstDocUfs.Add(docUf);
            }
            docPais[NomeCompBd.catEnderecosArrayUf] = lstDocUfs;
            return docPais;
        }

        /// <summary>
        /// Monta uma lista de documentos a partir de uma lista de objetos do tipo CatalogoEnderecos.
        /// </summary>
        /// <param name="lstCatEnd">Lista de objetos do tipo CatalogoEnderecos usado como base para montar a lista de documentos.</param>
        /// <returns>Retorna uma lista de documentos com os dados que estavam presentes na lista mandada como parâmetro.</returns>
        private IEnumerable<Document> MontarIEnumerableDocumento(List<CatalogoEndereco> lstCatEnd)
        {
            List<Document> lstRetorno = new List<Document>();
            Action<CatalogoEndereco> actConvertToDocument = new Action<CatalogoEndereco>(delegate(CatalogoEndereco objCatEnd)
                {
                    lstRetorno.Add(MontarDocumento(objCatEnd));
                }
            );
            lstCatEnd.ForEach(actConvertToDocument);
            return lstRetorno;
        }
    }
}
