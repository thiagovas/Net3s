using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsOrcamentoDAL
    {
        public void InserirOrcamento(Orcamento orc)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            Usuario prestador = usuarioDAL.BuscarUsuarioPorId(orc.prestador);
            Usuario contratante = usuarioDAL.BuscarUsuarioPorId(orc.contratante);

            prestador.orcamentoUsuario.Add(orc);
            contratante.orcamentoUsuario.Add(orc);

            Repository rep = new Repository();
                rep.Save(usuarioDAL.MontarDocumento(prestador), NomeCompBd.collecUsuarios);
                rep.Save(usuarioDAL.MontarDocumento(contratante), NomeCompBd.collecUsuarios);
            
        }

        public void EditarOrcamento(Orcamento orc)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            Usuario prestador = usuarioDAL.BuscarUsuarioPorId(orc.prestador);
            Usuario contratante = usuarioDAL.BuscarUsuarioPorId(orc.contratante);

            Predicate<Orcamento> prdRemoverOrcamento = new Predicate<Orcamento>(delegate(Orcamento objOrc)
                {
                    return objOrc.id.Equals(orc.id);
                });
            prestador.orcamentoUsuario.RemoveAll(prdRemoverOrcamento);
            contratante.orcamentoUsuario.RemoveAll(prdRemoverOrcamento);

            prestador.orcamentoUsuario.Add(orc);
            contratante.orcamentoUsuario.Add(orc);

            Repository rep = new Repository();
            rep.Save(usuarioDAL.MontarDocumento(prestador), NomeCompBd.collecUsuarios);
            rep.Save(usuarioDAL.MontarDocumento(contratante), NomeCompBd.collecUsuarios);
            
        }

        #region === Buscas ===

        /// <summary>
        /// Busca todos os orçamentos de um usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário.</param>
        /// <returns>Retorna uma lista de objetos do tipo Orcamento com os orçamentos do usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Orcamento> BuscarTodosOrcamentos(Oid idUsu)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsu;
            Document resposta = new Document();
            Repository rep = new Repository();
                resposta = rep.ProcurarUm(doc, NomeCompBd.collecUsuarios);
            

            if (resposta[NomeCompBd.usuArrayOrcamento] != null)
            {
                if (resposta[NomeCompBd.usuArrayOrcamento].GetType() == typeof(List<Document>))
                {
                    return MontarListaObjetos((List<Document>)resposta[NomeCompBd.usuArrayOrcamento]);
                }
                else
                { return new List<Orcamento>(); }
            }
            else
            { return new List<Orcamento>(); }
        }

        /// <summary>
        /// Busca a quantidade de orcamentos de um usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que deseja-se contar a sua quantidade de orçamentos.</param>
        /// <returns>Retorna uma variável do tipo long.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long BuscarQuantOrcamentos(Oid idUsu)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsu;
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
                lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            
            if (lstResposta.Count > 0)
            {
                List<Document> lstOrcamento = (List<Document>)lstResposta[0][NomeCompBd.usuArrayOrcamento];
                return lstOrcamento.Count;
            }
            else
                throw new Exception("Não foi encontrado um usuário com este Oid.");
        }

        /// <summary>
        /// Busca a quantidade de orçamentos ativos de um usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que deseja-se contar a sua quantidade de orçamentos.</param>
        /// <returns>Retorna uma variável do tipo long.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long BuscarQuantOrcamentosAprovados(Oid idUsu)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsu;
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
                lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            

            //Se foi retornado um documento de usuário, é contado o numero de orcamnetos dele.
            if (lstResposta.Count > 0)
            {
                List<Document> lstOrcamento = (List<Document>)lstResposta[0][NomeCompBd.usuArrayOrcamento];
                long quantOrcamentosAtivos = 0;
                Action<Document> ActContarOrcAtivos = new Action<Document>(delegate(Document docOrcament)
                    {
                        if ((int)doc[NomeCompBd.usuOrcamStatus] == 1)
                            quantOrcamentosAtivos++;
                    }
                );
                lstOrcamento.ForEach(ActContarOrcAtivos);
                return quantOrcamentosAtivos;
            }
            else //Se não foi retornado um documento de usuário, é pq não existe um documento com o Oid informado.
                throw new Exception("Não foi encontrado um usuário com este Oid.");
        }

        /// <summary>
        /// Busca a quantidade de orçamentos ativos de um usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que deseja-se contar a sua quantidade de orçamentos.</param>
        /// <returns>Retorna uma variável do tipo long.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Orcamento> BuscarQuantOrcamentosNaoAprovadosPrest(Oid idUsu)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsu;
            List<Document> lstResposta = new List<Document>();
            List<Orcamento> LstOrc = new List<Orcamento>();
            Repository rep = new Repository();
                lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            

            //Se foi retornado um documento de usuário, é contado o numero de orcamnetos dele.
            if (lstResposta.Count > 0)
            {
                if (lstResposta[0][NomeCompBd.usuArrayOrcamento].GetType() != typeof(List<Document>))
                {
                    List<Document> lstOrcamento = (List<Document>)lstResposta[0][NomeCompBd.usuArrayOrcamento];

                    Action<Document> ActContarOrcAtivos = new Action<Document>(delegate(Document docOrcament)
                    {
                        if (((StatusOrcam)docOrcament[NomeCompBd.usuOrcamStatus] != StatusOrcam.aprovado) && (Oid)docOrcament[NomeCompBd.usuOrcamPrestador] == idUsu)
                            lstResposta.Add(docOrcament);
                    }
                    );
                    lstOrcamento.ForEach(ActContarOrcAtivos);

                    return MontarListaObjetos(lstResposta);
                }
                else return null;
            }
            else //Se não foi retornado um documento de usuário, é pq não existe um documento com o Oid informado.
                throw new Exception("Não foi encontrado um usuário com este Oid.");
        }

        /// <summary>
        /// Busca a quantidade de orçamentos ativos de um usuário.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que deseja-se contar a sua quantidade de orçamentos.</param>
        /// <returns>Retorna uma variável do tipo long.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Orcamento> BuscarQuantOrcamentosNaoAprovadosContrat(Oid idUsu)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsu;
            List<Document> lstResposta = new List<Document>();
            List<Orcamento> LstOrc = new List<Orcamento>();
            Repository rep = new Repository();
                lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            

            //Se foi retornado um documento de usuário, é contado o numero de orcamnetos dele.
            if (lstResposta.Count > 0)
            {
                if (lstResposta[0][NomeCompBd.usuArrayOrcamento].GetType() == typeof(List<Document>))
                {
                    List<Document> lstOrcamento = (List<Document>)lstResposta[0][NomeCompBd.usuArrayOrcamento];

                    if (lstOrcamento != null)
                    {
                        Action<Document> ActContarOrcAtivos = new Action<Document>(delegate(Document docOrcament)
                        {
                            if (((StatusOrcam)docOrcament[NomeCompBd.usuOrcamStatus] != StatusOrcam.aprovado) && (Oid)docOrcament[NomeCompBd.usuOrcamContratante] == idUsu)
                        if ((Oid)docOrcament[NomeCompBd.usuOrcamContratante] == idUsu)
                                lstResposta.Add(docOrcament);
                        }
                        );
                        lstOrcamento.ForEach(ActContarOrcAtivos);

                        return MontarListaObjetos(lstResposta);
                    }
                    else return null;
                }
                else return null;
            }
            else //Se não foi retornado um documento de usuário, é pq não existe um documento com o Oid informado.
                throw new Exception("Não foi encontrado um usuário com este Oid.");
        }

        /// <summary>
        /// Busca os orcamentos aprovados, e finalizados ou não(se o retorno da busca vai conter somente orcamentos finalizados ou nao, isso é definido pelo segundo parâmetro).
        /// </summary>
        /// <param name="idUsu">Oid do usuário.</param>
        /// <param name="finalizado">True para retornar orcamentos finalizados e false para retornar orcamentos nao finalizados.</param>
        /// <returns>Retorna uma lista de objetos do tipo Orcamento.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Orcamento> BuscarOrcamentoAprovados(Oid idUsu, bool finalizado)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsu;
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
                lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            

            //Se foi retornado um documento de usuário, é contado o numero de orcamnetos dele.
            if (lstResposta.Count > 0)
            {
                List<Document> lstOrcamento = (List<Document>)lstResposta[0][NomeCompBd.usuArrayOrcamento];
                List<Orcamento> lstRetorno = new List<Orcamento>();

                Action<Document> ActContarOrcAtivosFinalizados = new Action<Document>(delegate(Document docOrcament)
                {
                    if (((StatusOrcam)doc[NomeCompBd.usuOrcamStatus] == StatusOrcam.aprovado) && ((StatusOrcam)doc[NomeCompBd.usuOrcamStatus] == StatusOrcam.finalizado))
                        lstRetorno.Add(MontarObjeto(docOrcament));
                });

                Action<Document> ActContarOrcAtivosNaoFinalizados = new Action<Document>(delegate(Document docOrcament)
                {
                    if (((StatusOrcam)doc[NomeCompBd.usuOrcamStatus] == StatusOrcam.aprovado) && ((StatusOrcam)doc[NomeCompBd.usuOrcamStatus] != StatusOrcam.finalizado))
                        lstRetorno.Add(MontarObjeto(docOrcament));

                });

                if (finalizado)
                    lstOrcamento.ForEach(ActContarOrcAtivosFinalizados);
                else
                    lstOrcamento.ForEach(ActContarOrcAtivosNaoFinalizados);

                return lstRetorno;
            }
            else //Se não foi retornado um documento de usuário, é pq não existe um documento com o Oid informado.
                throw new Exception("Não foi encontrado um usuário com este Oid.");
        }

        /// <summary>
        /// Busca um orçamento pelo Oid do orçamento.
        /// </summary>
        /// <param name="idOrcam">Oid do orçamento.</param>
        /// <returns>Retorna o objeto do tipo Orcamento.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Orcamento BuscarOrcamentoPorId(Oid idOrcam)
        {
            Document doc = new Document();
            List<Document> lstOrcam = new List<Document>();
            Document docOrcam = new Document();
            Document docElemMatch = new Document();
            docElemMatch.Add(NomeCompBd.usuOrcamId, idOrcam);
            docOrcam.Add("$elemMatch", docElemMatch);
            lstOrcam.Add(docOrcam);
            doc.Add(NomeCompBd.usuArrayOrcamento, lstOrcam);

            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
            lstResposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            

            if (lstResposta != null && lstResposta.Count > 0)
            {
                if (lstResposta[0][NomeCompBd.usuArrayOrcamento] != null)
                {
                    List<Document> lstOrcamentos = (List<Document>)lstResposta[0][NomeCompBd.usuArrayOrcamento];
                    Predicate<Document> prdProcurarOrcamento = new Predicate<Document>(delegate(Document x)
                        {
                            return (MongoDB.Oid)x[NomeCompBd.usuOrcamId] == idOrcam;
                        });
                    Document retorno = lstOrcamentos.Find(prdProcurarOrcamento);
                    if (retorno != null)
                    {
                        return MontarObjeto(retorno);
                    }
                    else
                        return null;
                }
                else
                { return null; }
            }
            else
            { return null; }
        }

        /// <summary>
        /// Metodo mais comum para buscar os orçamentos de determinado usuario
        /// </summary>
        /// <param name="idUsu">id do usuario referente</param>
        /// <param name="orc">valores para filtragem de dados</param>
        /// <returns>Lista de Orçamentos</returns>
        public List<Orcamento> BuscarPorIdUsuario(Oid idUsu, Orcamento orc)
        {
            List<Document> resp = new List<Document>();
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsu;
            doc[NomeCompBd.usuArrayOrcamento] = MontarDocumento(orc);

            Repository rep = new Repository();
                resp = rep.Procurar(doc, NomeCompBd.collecUsuarios);
            

            return resp != null ? MontarListaObjetos(resp) : null;
        }
        #endregion

        #region === Montar Documentos e Objetos ===

        /// <summary>
        /// Monta uma lista de objetos do tipo Orcamento a partir de uma lista de documentos.
        /// </summary>
        /// <param name="lstDoc">Lista de documentos usada como base para montar a lista de objetos.</param>
        /// <returns>Retorna uma lista de objetos do tipo Orcamento.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Orcamento> MontarListaObjetos(List<Document> lstDoc)
        {
            if (lstDoc == null)
                return null;

            List<Orcamento> lstRetorno = new List<Orcamento>();

            lstDoc.ForEach(delegate(Document doc)
            {
                if(doc[NomeCompBd.usuOrcamPrestador] != null)
                    lstRetorno.Add(MontarObjeto(doc));
            });

            return lstRetorno;
        }

        /// <summary>
        /// Monta um objeto do tipo Orcamento a partir de um documento de orcamento.
        /// </summary>
        /// <param name="doc">Documento usado como base para montar o objeto do tipo Orcamento.</param>
        /// <returns>Retorna um objeto do tipo Orcamento.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Orcamento MontarObjeto(Document doc)
        {
            Orcamento orcam = new Orcamento();
            orcam.id = doc[NomeCompBd.usuOrcamId] != null ? new Oid(doc[NomeCompBd.usuOrcamId].ToString()) : null;
            orcam.prestador = doc[NomeCompBd.usuOrcamPrestador] != null ? new Oid(doc[NomeCompBd.usuOrcamPrestador].ToString()) : null;
            orcam.contratante = doc[NomeCompBd.usuOrcamContratante] != null ? new Oid(doc[NomeCompBd.usuOrcamContratante].ToString()) : null;
            orcam.idServico = doc[NomeCompBd.usuOrcamIdServico] != null ? new Oid(doc[NomeCompBd.usuOrcamIdServico].ToString()) : null;
            orcam.dataInicio = doc[NomeCompBd.usuOrcamDataInicio] != null ? Convert.ToDateTime(doc[NomeCompBd.usuOrcamDataInicio]) : DateTime.MinValue;
            orcam.dataFim = doc[NomeCompBd.usuOrcamDataFim] != null ? Convert.ToDateTime(doc[NomeCompBd.usuOrcamDataFim]) : DateTime.MinValue;
            orcam.preco = doc[NomeCompBd.usuOrcamPreco] != null ? (double)doc[NomeCompBd.usuOrcamPreco] : -1;
            orcam.descricao = doc[NomeCompBd.usuOrcamDescricao] != null ? doc[NomeCompBd.usuOrcamDescricao].ToString() : null;
            //Alteração, ao invez de aprovado e finalizado, usaremos um campo so, Status que carrega qual é a atual situação do orçamento
            orcam.status = (StatusOrcam)doc[NomeCompBd.usuOrcamStatus];
            return orcam;
        }

        /// <summary>
        /// Monta um documento usando como base o objeto do tipo Orcamento.
        /// </summary>
        /// <param name="orcam">Objeto do tipo Orcamento.</param>
        /// <returns>Retorna um documento que é montado a partir de um objeto do tipo Orcamento.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumento(Orcamento orcam)
        {
            Document doc = new Document();

            doc[NomeCompBd.usuOrcamId] = orcam.id;
            doc[NomeCompBd.usuOrcamPrestador] = orcam.prestador;
            doc[NomeCompBd.usuOrcamContratante] = orcam.contratante;
            doc[NomeCompBd.usuOrcamIdServico] = orcam.idServico;
            doc[NomeCompBd.usuOrcamDataInicio] = orcam.dataInicio;
            doc[NomeCompBd.usuOrcamDataFim] = orcam.dataInicio;
            doc[NomeCompBd.usuOrcamDescricao] = orcam.descricao;
            doc[NomeCompBd.usuOrcamPreco] = orcam.preco;
            //mudança em orçamento, substituimos dois campos, aprovado e finalizado por um campo so, status
            doc[NomeCompBd.usuOrcamStatus] = (int)orcam.status;
            return doc;
        }

        /// <summary>
        /// Monta uma lista de documentos a partir de uma lista de objetos do tipo Orcamento.
        /// </summary>
        /// <param name="lstOrcam">Lista de objetos do tipo Orcamento.</param>
        /// <returns>Retorna uma lista de documentos.</returns>
        public List<Document> MontarListaDocumento(List<Orcamento> lstOrcam)
        {
            if (lstOrcam == null)
                return null;

            List<Document> lstRetorno = new List<Document>();
            Action<Orcamento> actMontarListaDoc = new Action<Orcamento>(delegate(Orcamento x)
                {
                    lstRetorno.Add(MontarDocumento(x));
                });
            lstOrcam.ForEach(actMontarListaDoc);
            return lstRetorno;
        }
        #endregion
    }
}