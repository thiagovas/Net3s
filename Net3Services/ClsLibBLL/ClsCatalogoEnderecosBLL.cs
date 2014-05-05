using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ClsLibDAL;
using Models;

namespace ClsLibBLL
{
    public class ClsCatalogoEnderecosBLL
    {
        /// <summary>
        /// Insere os dados dos objetos da lista de objetos do tipo CatalogoEndereco no banco de dados.
        /// </summary>
        /// <param name="lstCatEnd">Lista de objetos do tipo CatalogoEndereco que tem os dados a serem inseridos no banco de dados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Inserir(List<CatalogoEndereco> lstCatEnd)
        {
            ClsCatalogoEnderecosDAL catalogoEnderecosDAL = new ClsCatalogoEnderecosDAL();
            catalogoEnderecosDAL.Inserir(lstCatEnd);
        }

        /// <summary>
        /// Insere os dados do objeto do tipo CatalogoEndereco no banco de dados.
        /// </summary>
        /// <param name="catEnd">Objeto com os dados a serem inseridos no banco de dados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Inserir(CatalogoEndereco catEnd)
        {
            ClsCatalogoEnderecosDAL catalogoEnderecosDAL = new ClsCatalogoEnderecosDAL();
            catalogoEnderecosDAL.Inserir(catEnd);
        }

        /// <summary>
        /// Este método insere um pais na collection CatalogoEnderecos.
        /// </summary>
        /// <param name="pais">Nome do pais que será inserido na collection CatalogoEnderecos.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirPais(string pais)
        {
            ClsCatalogoEnderecosDAL catalogoEnderecosDAL = new ClsCatalogoEnderecosDAL();
            catalogoEnderecosDAL.InserirPais(pais);
        }

        /// <summary>
        /// Este método inseri uma unidade federativa no pais que ela pertence.
        /// </summary>
        /// <param name="pais">Pais que a unidade federativa pertence.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirPais(string pais)
        { }

        public void InserirUf(string pais, string uf)
        {}

        public void ExcluirUf(string pais, string uf)
        {}

        public void InserirCidade(string pais, string uf, string cidade)
        { }

        public void ExcluirCidade(string pais, string uf, string cidade)
        { }

        /// <summary>
        /// Busca os estados do pais informado no parâmetro do método.
        /// </summary>
        /// <param name="pais">País usado como filtro de busca.</param>
        /// <returns>Retorna uma lista de variaveis do tipo string com os nomes dos estados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<string> BuscarEstadosPorPais(string pais)
        {
            ClsCatalogoEnderecosDAL catalogoEnderecosDAL = new ClsCatalogoEnderecosDAL();
            return catalogoEnderecosDAL.BuscarEstadosPorPais(pais);
        }

        /// <summary>
        /// Busca as cidades do uf informado no parâmetro do método.
        /// </summary>
        /// <param name="uf">Uf usado como filtro de busca.</param>
        /// <returns>Retorna uma lista de variáveis do tipo stirng com os nomes das cidades.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<string> BuscarCidadesPorUf(string uf)
        {
            ClsCatalogoEnderecosDAL catalogoEnderecosDAL = new ClsCatalogoEnderecosDAL();
            return catalogoEnderecosDAL.BuscarCidadesPorUf(uf);
        }

        /// <summary>
        /// Busca todos os países do catalogo de endereços do banco de dados.
        /// </summary>
        /// <returns>Retorna uma lista de variáveis do tipo string com o nome dos países.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<string> BuscarPaises()
        {
            ClsCatalogoEnderecosDAL catalogoEnderecosDAL = new ClsCatalogoEnderecosDAL();
            return catalogoEnderecosDAL.BuscarPaises();
        }

        public List<CatalogoEndereco> BuscarTodosEnderecos()
        {
            ClsCatalogoEnderecosDAL catalogoEnderecosDAL = new ClsCatalogoEnderecosDAL();
            return catalogoEnderecosDAL.BuscarTodosEnderecos();
        }

        /// <summary>
        /// Lê um arquivo Xml e extrai as informações do pais com seus respectivos estados e cidades
        /// </summary>
        /// <param name="xml">Stream contendo o arquivo XML que deve ser lido</param>
        /// <returns>Lista contendo todos os paises contidos no arqivo com seus respectivos estados e cidades</returns>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        public List<CatalogoEndereco> lerXmlCatalogoEndereco(System.IO.Stream xml)
        {
            XDocument xmlDoc;

            try { xmlDoc = XDocument.Load(xml); }
            catch { throw new Exception("O documento infomado não pode ser carregado. Verifique se ele é um documento XML válido."); }

            var pais = from p in xmlDoc.Elements("Documento").Elements("Paises").Elements("Pais")
                       select p;

            List<CatalogoEndereco> ltCatalogo = new List<CatalogoEndereco>();

            foreach (var item in pais)
            {
                CatalogoEndereco catalogo = new CatalogoEndereco();
                catalogo.pais = new Pais();
                catalogo.pais.nomePais = item.Element("Nome").Value.Trim();
                catalogo.pais.estados = new List<Estado>();

                var estados = from e in item.Elements("Estados").Elements("Estado")
                              select e;

                foreach (var itemEst in estados)
                {
                    Estado est = new Estado();
                    est.nomeEstado = itemEst.Element("Nome").Value.Trim();
                    est.cidades = new List<Cidade>();

                    var cidades = from c in itemEst.Elements("Cidades").Elements("Cidade")
                                  select c;

                    foreach (var itemCid in cidades)
                    {
                        Cidade cid = new Cidade();
                        cid.nomeCidade = itemCid.Element("Nome").Value.Trim();
                        est.cidades.Add(cid);
                    }

                    var teste = est.cidades;
                    teste = teste.OrderBy(t => t.nomeCidade).ToList();
                    est.cidades = teste;

                    catalogo.pais.estados.Add(est);
                }

                ltCatalogo.Add(catalogo);
            }

            return ltCatalogo;
        }
    }
}
