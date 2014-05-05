using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsCategoriaServicoDAL
    {
        /// <summary>
        /// Método que insere uma nova categoria de serviço no banco de dados.
        /// </summary>
        /// <param name="nomeCategoria">Nome da categoria a ser inserida.</param>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        public void Inserir(string nomeCategoria)
        {
            Repository rep = new Repository();
            rep.Insert(MontarDocumento(new CategoriaServico() { nomeCategoria = nomeCategoria }, true),
                        NomeCompBd.collecCategoriasServico);
        }
        
        /// <summary>
        /// Método que edita uma categoria de serviço no banco de dados.
        /// </summary>
        /// <param name="idCategoria">Oid da categoria de serviço.</param>
        /// <param name="nomeCategoria">Nome da categoria de serviço.</param>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        public void Editar(Oid idCategoria, string nomeCategoria)
        {
            Repository rep = new Repository();
            rep.Save(MontarDocumento(new CategoriaServico() { idCategoria = idCategoria, nomeCategoria = nomeCategoria }, false),
                        NomeCompBd.collecCategoriasServico);
        }

        /// <summary>
        /// Método que exclui uma categoria de serviço do banco de dados.
        /// </summary>
        /// <param name="idCategoria">Oid da categoria.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Excluir(Oid idCategoria)
        {
            Repository rep = new Repository();
            rep.delete(MontarDocumento(new CategoriaServico() { idCategoria = idCategoria }, false),
                        NomeCompBd.collecCategoriasServico);
        }

        /// <summary>
        /// Método que exclui uma categoria de serviço do banco de dados.
        /// </summary>
        /// <param name="nomeCategoria">Nome da categoria a ser excluída.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Excluir(string nomeCategoria)
        {
            Repository rep = new Repository();
            rep.delete(MontarDocumento(new CategoriaServico() { nomeCategoria = nomeCategoria }, false),
                        NomeCompBd.collecCategoriasServico);
        }

        /// <summary>
        /// Função que busca uma categoria de serviço pelo nome.
        /// </summary>
        /// <param name="nome">Nome da categoria de serviço.</param>
        /// <returns>Retorna um objeto do tipo CategoriaServico ou null se a busca retornar vazio.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public CategoriaServico BuscarCategoriaPorNome(string nome)
        {
            Repository rep = new Repository();
            Document doc = new Document();
            doc[NomeCompBd.categoriasServicoNome] = nome;
            doc = rep.ProcurarUm(doc, NomeCompBd.collecCategoriasServico);
            return MontarObjeto(doc);
        }

        /// <summary>
        /// Função que busca uma categoria de serviço pelo Oid.
        /// </summary>
        /// <param name="id">Oid da categoria de serviço.</param>
        /// <returns>Retorna um objeto do tipo CategoriaServico ou null se a busca retornar vazio.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public CategoriaServico BuscarCategoriaPorOid(Oid id)
        {
            Repository rep = new Repository();
            Document doc = new Document();
            doc[NomeCompBd.categoriasServicoId] = id;
            doc = rep.ProcurarUm(doc, NomeCompBd.collecCategoriasServico);
            return MontarObjeto(doc);
        }

        /// <summary>
        /// Função que busca todas as categorias de serviço do banco de dados.
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tipo CategoriaServico com todas as categorias do banco de dados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<CategoriaServico> BuscarTodasCategorias()
        {
            Repository rep = new Repository();
            return MontarListaObjeto(rep.ProcurarTodos(NomeCompBd.collecCategoriasServico));
        }

        #region === Funções montar documento e objeto ===
        /// <summary>
        /// Função para montar documento de categoria de serviço.
        /// </summary>
        /// <param name="obj">Objeto com os dados para montar o documento.</param>
        /// <param name="gerarOid">True se quiser que o campo Oid do documento seja gerado.</param>
        /// <returns>Retorna o documento de categoria de serviço.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private Document MontarDocumento(CategoriaServico obj, bool gerarOid)
        {
            Document doc = new Document();
            doc[NomeCompBd.categoriasServicoId] = gerarOid ? new OidGen().Generate() : obj.idCategoria;
            doc[NomeCompBd.categoriasServicoNome] = obj.nomeCategoria;
            return doc;
        }

        /// <summary>
        /// Função que monta uma lista de documentos a partir de uma lista de objetos.
        /// </summary>
        /// <param name="lstObj">Lista de objetos usada para montar a lista de documentos.</param>
        /// <returns>Retorna uma lista de documentos.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private List<Document> MontarListaDocumento(List<CategoriaServico> lstObj)
        {
            List<Document> lstDoc = new List<Document>();
            foreach (var obj in lstObj)
            { 
                lstDoc.Add(MontarDocumento(obj, false));
            }
            return lstDoc;                
        }

        /// <summary>
        /// Função que monta um objeto a partir de um documento de categoria de serviço.
        /// </summary>
        /// <param name="doc">Documento a ser usado para montar o objeto.</param>
        /// <returns>Retorna um objeto do tipo CategoriaServico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private CategoriaServico MontarObjeto(Document doc)
        {
            if (doc == null)
                return null;

            CategoriaServico obj = new CategoriaServico();
            obj.idCategoria = new Oid(doc[NomeCompBd.categoriasServicoId].ToString());
            obj.nomeCategoria = doc[NomeCompBd.categoriasServicoNome].ToString();
            return obj;
        }

        /// <summary>
        /// Função que monta uma lista de objetos a partir de uma lista de documentos.
        /// </summary>
        /// <param name="lstDoc">Lista de documentos a ser usada para montar a lista de objetos.</param>
        /// <returns>Retorna uma lista de objetos do tipo CategoriaServico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        private List<CategoriaServico> MontarListaObjeto(List<Document> lstDoc)
        {
            List<CategoriaServico> lstObj = new List<CategoriaServico>();
            foreach (var doc in lstDoc)
            {
                lstObj.Add(MontarObjeto(doc));
            }
            return lstObj;
        }
        #endregion
    }
}