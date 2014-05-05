using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsServicosDAL
    {
        #region === CRUD(VEIA) ===
        /// <summary>
        /// Inseri um serviço na collection de serviços no banco de dados.
        /// </summary>
        /// <param name="serv">Objeto do tipo Servico contendo todos os dados a serem inseridos no banco de dados.</param>
        public void InserirServico(Servico serv)
        {
            Document docServico = new Document();
            docServico = MontarDocumentoSemId(serv);

            Repository rep = new Repository();
            rep.Insert(docServico, NomeCompBd.collecServicos);
        }

        /// <summary>
        /// Edita um serviço na collection de serviços que tenha o Oid gravado no objeto informado.
        /// </summary>
        /// <param name="serv">Objeto do tipo serviço contendo todos os dados do serviço inclusive com o Oid dele.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void EditarServico(Servico serv)
        {
            Document docServico = new Document();
            docServico = MontarDocumentoServico(serv);

            Repository rep = new Repository();
            rep.Save(docServico, NomeCompBd.collecServicos);
        }

        /// <summary>
        /// Edita vários serviços de um usuário.
        /// </summary>
        /// <param name="ieServicos">IEnumerable com os serviços a serem editados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void EditarServicos(IEnumerable<Servico> ieServicos)
        {
            List<Document> lstDocument = MontarListaDocumentoServico(ieServicos.ToList());
            Repository rep = new Repository();

            //Nesta linha a conexão é aberta com o banco de dados.
            IMongoCollection collection = rep.DB.GetCollection(NomeCompBd.collecServicos);
            Action<Document> actEditarServico = new Action<Document>(delegate(Document doc)
                {
                    collection.Save(doc);
                });
            lstDocument.ForEach(actEditarServico);
            rep.Desconectar();
        }

        /// <summary>
        /// Desativa um serviço.
        /// </summary>
        /// <param name="idServico">Oid do serviço a ser desativado.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void DesativarServico(MongoDB.Oid idServico)
        {
            Servico serv = buscarServicoPorId(idServico);
            serv.statusServico = StatusServico.Desativo;
            EditarServico(serv);
        }

        /// <summary>
        /// Desativa todos os serviços de um usuário.
        /// </summary>
        /// <param name="idUsuario">Oid de um usuário.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void DesativarTodosServicos(MongoDB.Oid idUsuario)
        {
            List<Servico> lstServicos = buscarTodosServicos(idUsuario);
            Action<Servico> actDesativarServicos = new Action<Servico>(delegate(Servico serv)
            {
                serv.statusServico = StatusServico.Desativo;
            });
            lstServicos.ForEach(actDesativarServicos);
            EditarServicos(lstServicos);
        }
        
        /// <summary>
        /// Este método busca um serviço com o nome informado.
        /// </summary>
        /// <param name="nome">Nome do serviço usado para fazer a busca.</param>
        /// <returns>Retorna uma lista do tipo Servico com o resultado da busca.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarServicoPorNome(string nome)
        {
            Repository rep = new Repository();
            List<Document> lstDoc = rep.ProcurarRegex(NomeCompBd.servicoNome, nome, NomeCompBd.collecServicos);
            return MontarListaServicos(lstDoc);
        }

        /// <summary>
        /// Este método busca um serviço com a descricao informada.
        /// </summary>
        /// <param name="descricao">Descrição do serviço usada como filtro para fazer a busca.</param>
        /// <returns>Retorna uja lista do tipo Servico com o resultado da busca.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarServicoPorDescricao(string descricao)
        {
            Repository rep = new Repository();
                List<Document> lstDoc = rep.ProcurarRegex(NomeCompBd.servicoDesc, descricao, NomeCompBd.collecServicos);
                return MontarListaServicos(lstDoc);
            
        }

        /// <summary>
        /// Este método busca todos os serviços de um determinado usuário.
        /// </summary>
        /// <param name="_idUsu">Oid do usuário em que será buscado os serviços.</param>
        /// <returns>Retorna uma lista do tipo Serviço com todos os dados dos serviços.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> buscarTodosServicos(MongoDB.Oid _idUsu)
        {
            Document doc = new Document();
            doc[NomeCompBd.servicoIdUsuario] = _idUsu;
            doc[NomeCompBd.servicoStatusServico] = 0;

            Repository rep = new Repository();
                return MontarListaServicos(rep.Procurar(doc, NomeCompBd.collecServicos));
            
        }

        /// <summary>
        /// Busca um serviço a partir de seu ID
        /// </summary>
        /// <param name="_id">ID do serviço que deve ser encontrado</param>
        /// <returns>Retorna o serviço que possui o ID informado</returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public Servico buscarServicoPorId(MongoDB.Oid _id)
        {
            Document docServico = new Document();
            docServico[NomeCompBd.servico_id] = _id;
            docServico[NomeCompBd.servicoStatusServico] = 0;
            List<Document> lstResposta = new List<Document>();

            Repository rep = new Repository();
                lstResposta = rep.Procurar(docServico, NomeCompBd.collecServicos); //Procura o serviço e guarda o resultado na variavel lstResposta

                //Se tiver algum documento na lista retorna o objeto serviço que será montado de acordo com o primeiro documento, senão retorna null
                return lstResposta.Count > 0 ? MontarObjetoServico(lstResposta.First()) : null;
            
        }

        /// <summary>
        /// Busca serviços por categoria.
        /// </summary>
        /// <param name="categoria">Categoria usada como filtro de busca.</param>
        /// <returns>Retorna uma lista de objetos do tipo Servico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarServicosPorCategoria(string categoria)
        {
            Document docServ = new Document();
            docServ[NomeCompBd.servicoIdCategServ] = categoria;
            docServ[NomeCompBd.servicoStatusServico] = 0;
            List<Document> lstResposta = new List<Document>();
            Repository rep = new Repository();
                lstResposta = rep.Procurar(docServ, NomeCompBd.collecServicos);
            
            if (lstResposta.Count > 0)
            {
                return MontarListaServicos(lstResposta);
            }
            else
                return new List<Servico>();
        }

        /// <summary>
        /// Busca os ultimos serviços inseridos no banco de dados.
        /// </summary>
        /// <param name="numServicos">Número de serviços que deseja que serão retornados.</param>
        /// <returns>Retorna uma lista com os ultimos serviços adicionados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> BuscarUltimosServicosInseridos(int numServicos)
        {
            List<Document> lstResultado;
            Repository rep = new Repository();
            lstResultado = rep.ProcurarTodos(NomeCompBd.collecServicos, numServicos, IndexOrder.Descending, NomeCompBd.servicoDataInsercao);
            
            return MontarListaServicos(lstResultado);
        }

        /// <summary>
        /// Conta quantos serviços um usuário presta. Obs.: Este método conta todos os serviços, ativos e desativos.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <returns>Retorna a quantidade de serviços que um usuário presta.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long ContarQuantServicos(Oid idUsuario)
        {
            Document doc = new Document();
            doc[NomeCompBd.servicoIdUsuario] = idUsuario;
            long retorno = 0;
            Repository rep = new Repository();
                retorno = rep.Count(doc, NomeCompBd.collecServicos);
            
            return retorno;
        }

        /// <summary>
        /// Conta quantos serviços um usuário presta. Obs.: Este método conta so os serviços ativos.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <returns>Retorna a quantidade de serviços ativos de um usuário.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long ContarQuantServicosAtivos(Oid idUsuario)
        {
            Document doc = new Document();
            doc[NomeCompBd.servicoIdUsuario] = idUsuario;
            doc[NomeCompBd.servicoStatusServico] = 0;
            long retorno = 0;
            Repository rep = new Repository();
                retorno = rep.Count(doc, NomeCompBd.collecServicos);
            
            return retorno;
        }
        #endregion

        #region === Monta objetos e documentos ===

        /// <summary>
        /// Este método tem a função montar um objeto do tipo Servico a partir de um documento.
        /// </summary>
        /// <param name="doc">Documento de serviço que será utilizado para montar o objeto.</param>
        /// <returns>Retorna um objeto do tipo serviço.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Servico MontarObjetoServico(Document doc)
        {
            Servico ser = new Servico();

            if (doc[NomeCompBd.servico_id] != null)
            {
                Oid _id = new Oid(doc[NomeCompBd.servico_id].ToString());
                ser._id = _id;
            }
            if (doc[NomeCompBd.servicoIdUsuario] != null)
            {
                Oid idUsuario = new Oid(doc[NomeCompBd.servicoIdUsuario].ToString());
                ser.idUsuario = idUsuario;
            }
            ser.nome = doc[NomeCompBd.servicoNome] != null ? doc[NomeCompBd.servicoNome].ToString() : null;
            ser.preco = doc[NomeCompBd.servicoPreco] != null ? Convert.ToDouble(doc[NomeCompBd.servicoPreco].ToString()) : 0;
            if (doc[NomeCompBd.servicoIdCategServ] != null)
            {
                try
                {
                    ser.categoriaServico = new Oid(doc[NomeCompBd.servicoIdCategServ].ToString());
                    ser.nomeCategoriaServico = new ClsCategoriaServicoDAL().BuscarCategoriaPorOid(ser.categoriaServico).nomeCategoria;
                }
                catch
                {
                    ser.categoriaServico = null;
                    ser.nomeCategoriaServico = string.Empty;
                }
            }
            else
            {
                ser.categoriaServico = null;
                ser.nomeCategoriaServico = string.Empty;
            }
            
            ser.regional = doc[NomeCompBd.servicoRegional] != null ? Convert.ToBoolean(doc[NomeCompBd.servicoRegional]) : false;
            ser.regiao = doc[NomeCompBd.servicoRegiao] != null ? doc[NomeCompBd.servicoRegiao].ToString() : null;
            ser.notaMedia = doc[NomeCompBd.servicoNotaMedia] != null ? Convert.ToInt32(doc[NomeCompBd.servicoNotaMedia].ToString()) :0 ;
            ser.descricao = doc[NomeCompBd.servicoDesc] != null ? doc[NomeCompBd.servicoDesc].ToString() : null;
            ser.nivelRegionalidade = doc[NomeCompBd.servicoNivelRegionalidade] != null ? doc[NomeCompBd.servicoNivelRegionalidade].ToString() : null;
            ser.unidadeMedida = doc[NomeCompBd.servicoUnidadeMedida] != null ? doc[NomeCompBd.servicoUnidadeMedida].ToString() : null;
            ser.dataInsercao = doc[NomeCompBd.servicoDataInsercao] != null ? Convert.ToDateTime(doc[NomeCompBd.servicoDataInsercao]) : DateTime.MinValue;
            if (doc[NomeCompBd.servicoStatusServico] != null)
            {
                switch ((int)doc[NomeCompBd.servicoStatusServico])
                { 
                    case 0:
                        ser.statusServico = StatusServico.Ativo;
                        break;
                    case 1:
                        ser.statusServico = StatusServico.Desativo;
                        break;
                }
            }
            return ser;
        }

        /// <summary>
        /// Este método tem a função de montar uma lista do tipo serviços a partir de uma lista de documentos.
        /// </summary>
        /// <param name="lstDoc">Lista de documentos que será usada para montar a lista do tipo Servico.</param>
        /// <returns>Retorna uma lista do tipo Servico</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> MontarListaServicos(List<Document> lstDoc)
        {
            List<Servico> lstServico = new List<Servico>();
            foreach (var item in lstDoc)
            {
                lstServico.Add(MontarObjetoServico(item));
            }
            return lstServico;
        }

        /// <summary>
        /// Este método tem a função de montar uma lista do tipo Servicos a partir de um IEnumerable de documentos.
        /// </summary>
        /// <param name="lstDoc">IEnumerable de documentos usado para montar a lista do tipo Servicos.</param>
        /// <returns>Retorna uma lista do tipo Servico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Servico> MontarListaServicos(IEnumerable<Document> lstDoc)
        {
            List<Servico> lstServico = new List<Servico>();
            foreach (var item in lstDoc)
            {
                lstServico.Add(MontarObjetoServico(item));
            }
            return lstServico;
        }

        /// <summary>
        /// Este método tem a função de montar um documento de serviço a partir de um objeto do tipo serviço.
        /// </summary>
        /// <param name="servico">Objeto do tipo Servico que será usado para montar o documento.</param>
        /// <returns>Retorna um documento de serviço.</returns>
        public Document MontarDocumentoServico(Servico servico)
        {
            Document doc = new Document();
            doc = MontarDocumentoSemId(servico);
            doc[NomeCompBd.servico_id] = servico._id;
            return doc;
        }

        /// <summary>
        /// Monta um documento de serviço sem o id.
        /// </summary>
        /// <param name="servico">Objeto de serviço a ser usado para montar o documento.</param>
        /// <returns>Retorna o documento de serviço.</returns>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        public Document MontarDocumentoSemId(Servico servico)
        {
            Document doc = new Document();
            doc[NomeCompBd.servicoNome] = servico.nome;
            doc[NomeCompBd.servicoIdUsuario] = servico.idUsuario;
            doc[NomeCompBd.servicoPreco] = servico.preco;
            doc[NomeCompBd.servicoIdCategServ] = servico.categoriaServico;
            doc[NomeCompBd.servicoRegional] = servico.regional;
            doc[NomeCompBd.servicoRegiao] = servico.regiao;
            doc[NomeCompBd.servicoNotaMedia] = servico.notaMedia;
            doc[NomeCompBd.servicoDesc] = servico.descricao;
            doc[NomeCompBd.servicoNivelRegionalidade] = servico.nivelRegionalidade;
            doc[NomeCompBd.servicoUnidadeMedida] = servico.unidadeMedida;
            doc[NomeCompBd.servicoDataInsercao] = servico.dataInsercao;
            doc[NomeCompBd.servicoStatusServico] = (int)servico.statusServico;
            return doc;
        }

        /// <summary>
        /// Este método tem a função de montar uma lista de documentos de Servico.
        /// </summary>
        /// <param name="lstServico">Lista do tipo Servico que será usada para montar a lista de documentos de Servico.</param>
        /// <returns>Retorna uma lista de documentos de servico.</returns>
        public List<Document> MontarListaDocumentoServico(List<Servico> lstServico)
        {
            List<Document> lstDocument = new List<Document>();
            foreach (var item in lstServico)
            {
                lstDocument.Add(MontarDocumentoServico(item));
            }
            return lstDocument;
        }
        #endregion
    }
}