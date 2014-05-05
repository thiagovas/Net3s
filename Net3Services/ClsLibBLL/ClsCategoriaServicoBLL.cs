using System;
using System.Collections.Generic;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsCategoriaServicoBLL
    {
        /// <summary>
        /// Método que insere uma nova categoria de serviço no banco de dados.
        /// </summary>
        /// <param name="nomeCategoria">Nome da categoria a ser inserida.</param>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        public void Inserir(string nomeCategoria)
        {
            ClsCategoriaServicoDAL categServicoDAL = new ClsCategoriaServicoDAL();
            nomeCategoria = nomeCategoria.Trim();
            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                if (categServicoDAL.BuscarCategoriaPorNome(nomeCategoria) == null)
                {
                    categServicoDAL.Inserir(nomeCategoria);
                }
                else
                {
                    throw new Exception("Já existe uma categoria com este nome.");
                }
            }
            else
            {
                throw new Exception("Informe um nome de categoria.");
            }
        }

        /// <summary>
        /// Método que edita uma categoria de serviço no banco de dados.
        /// </summary>
        /// <param name="idCategoria">Oid da categoria de serviço.</param>
        /// <param name="nomeCategoria">Nome da categoria de serviço.</param>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        public void Editar(Oid idCategoria, string nomeCategoria)
        {
            if (clsUtilidades.ValidarOid(idCategoria))
            {
                nomeCategoria = nomeCategoria.Trim();
                if (!string.IsNullOrEmpty(nomeCategoria))
                {
                    ClsCategoriaServicoDAL categServicoDAL = new ClsCategoriaServicoDAL();
                    categServicoDAL.Editar(idCategoria, nomeCategoria);
                }
                else
                {
                    throw new Exception("Informe o nome da categoria.");
                }
            }
            else
            {
                throw new OidException();
            }
        }

        /// <summary>
        /// Método que exclui uma categoria de serviço do banco de dados.
        /// </summary>
        /// <param name="idCategoria">Oid da categoria.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Excluir(Oid idCategoria)
        {
            if (clsUtilidades.ValidarOid(idCategoria))
            {
                ClsCategoriaServicoDAL categServicoDAL = new ClsCategoriaServicoDAL();
                categServicoDAL.Excluir(idCategoria);
            }
            else
            {
                throw new OidException();
            }
        }

        /// <summary>
        /// Método que exclui uma categoria de serviço do banco de dados.
        /// </summary>
        /// <param name="nomeCategoria">Nome da categoria a ser excluída.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Excluir(string nomeCategoria)
        {
            if (!string.IsNullOrEmpty(nomeCategoria.Trim()))
            {
                ClsCategoriaServicoDAL categServicoDAL = new ClsCategoriaServicoDAL();
                categServicoDAL.Excluir(nomeCategoria);
            }
            else
            {
                throw new Exception("Informe um nome de categoria.");
            }
        }

        /// <summary>
        /// Função que busca uma categoria de serviço pelo nome.
        /// </summary>
        /// <param name="nome">Nome da categoria de serviço.</param>
        /// <returns>Retorna um objeto do tipo CategoriaServico ou null se a busca retornar vazio.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public CategoriaServico BuscarCategoriaPorNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome.Trim()))
            {
                ClsCategoriaServicoDAL categServicoDAL = new ClsCategoriaServicoDAL();
                return categServicoDAL.BuscarCategoriaPorNome(nome.Trim());
            }
            else
            {
                throw new Exception("Informe um nome de categoria.");
            }
        }

        /// <summary>
        /// Função que busca uma categoria de serviço pelo Oid.
        /// </summary>
        /// <param name="id">Oid da categoria de serviço.</param>
        /// <returns>Retorna um objeto do tipo CategoriaServico ou null se a busca retornar vazio.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public CategoriaServico BuscarCategoriaPorOid(Oid id)
        {
            if (clsUtilidades.ValidarOid(id))
            {
                ClsCategoriaServicoDAL categServicoDAL = new ClsCategoriaServicoDAL();
                return categServicoDAL.BuscarCategoriaPorOid(id);
            }
            else
            {
                throw new OidException();
            }
        }

        /// <summary>
        /// Função que busca todas as categorias de serviço do banco de dados.
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tipo CategoriaServico com todas as categorias do banco de dados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<CategoriaServico> BuscarTodasCategorias()
        {
            ClsCategoriaServicoDAL categServicoDAL = new ClsCategoriaServicoDAL();
            return categServicoDAL.BuscarTodasCategorias();
        }
    }
}