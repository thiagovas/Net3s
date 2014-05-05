using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;

namespace UI.Componentes
{
    public partial class InformacoesPesquisa : System.Web.UI.UserControl
    {
        // Listas em que os filtros serão aplicadas. Estas listas servem para fazer buscas acumulativas
        private static List<Usuario> ltUsuario = new List<Usuario>();
        private static List<Servico> ltServico = new List<Servico>();

        private static List<Usuario> ltUsuarioCompleta = new List<Usuario>();
        private static List<Servico> ltServicoCompleta = new List<Servico>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Executa a busca dos valores informados e preenche a tela com a busca
        /// </summary>
        /// <param name="tipo">Define se o componente deve executar uma pesquisa por usuários ou por serviços</param>
        /// <param name="filtroUm">Define qual o parametro de busca. Ex: Nome do serviço, valor, login do usuário, etc...</param>
        /// <param name="filtroDois">A informação que deve ser utilizada na busca</param>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        public void ExecutarPesquisa(TipoPesquisa tipo, string filtroUm, string filtroDois)
        {
            switch (tipo)
            {
                case TipoPesquisa.Usuario:
                    BuscarUsuarios(filtroUm, filtroDois);
                    break;

                case TipoPesquisa.Servico:
                    BuscarServicos(filtroUm, filtroDois);
                    break;
            }
        }

        #region === Usuário ===
        public void LimparListaUsuarios()
        {
            ltUsuario.Clear();
            ltUsuarioCompleta.Clear();
        }

        public void RemoverFiltroUsuario()
        {
            ltUsuario = ltUsuarioCompleta;
            MontarInfoUsuario(ltUsuarioCompleta);
        }

        /// <summary>
        /// Realiza a busca pelo usuário e caso a busca seja bem sucedida mostra a informação para o usuário, do contrário
        /// mostra a mensagem de erro ao usuário
        /// </summary>
        /// <param name="tipoBusca">Tipo da busca que deve ser executada. Ex: nome do usuário, e-mail, login, etc</param>
        /// <param name="filtro">Filtro que deve ser utilizado como parâmetro da busca</param>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        private void BuscarUsuarios(string tipoBusca, string filtro)
        {
            try
            {
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();

                switch (tipoBusca)
                {
                    case "Nome do usuário":
                        ltUsuarioCompleta = usuarioBLL.BuscarUsuarioPorNome(filtro);
                        break;

                    case "E-mail":
                        ltUsuarioCompleta = usuarioBLL.BuscarUsuarioPorEmail(filtro);
                        break;

                    case "Login":
                        ltUsuarioCompleta = usuarioBLL.BuscarUsuarioPorLogin(filtro);
                        break;
                }

                ltUsuario = ltUsuarioCompleta;
                MontarInfoUsuario(ltUsuario);
            }
            catch (Exception x)
            {
                if (phInformacoes.Controls.Count > 0)
                    phInformacoes.Controls.Clear();

                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "servicoLista");
                div.InnerHtml += "<h4>Ocorreu um erro durante a execução da busca por usuários. Tente novamente mais tarde.</h4>";
                div.InnerHtml += string.Format("<br /><p><b>Erro:</b> {0}</p>", x.Message);

                phInformacoes.Controls.Add(div);
            }
        }

        /// <summary>
        /// Preenche a tela com as informações dos usuários encontrados
        /// </summary>
        /// <param name="lista">Lista de usuários que contém as informações</param>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void MontarInfoUsuario(List<Usuario> lista)
        {
            if (phInformacoes.Controls.Count > 0)
                phInformacoes.Controls.Clear();

            if (lista.Count() > 0)
            {
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                string caminhoImagem = string.Empty;
                string descServico = string.Empty;
                string nomeFoto = string.Empty;
               
                foreach (var usu in lista)
                {
                     //Aqui ele gera a imagem de acordo com a informação de nome
                if (usuarioBLL.VerificarImagem(usu._id.ToString()))
                    nomeFoto = usu._id.ToString();
                else
                    nomeFoto = "1";

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "usuario");

                    div.InnerHtml += string.Format("<a href='Perfil.aspx?id={0}'><img src='../Componentes/BuscaImagens.ashx?id={1}' alt='' class='foto'/></a>", usu._id, nomeFoto);
                    div.InnerHtml += string.Format("<font class='nome'><a href='Perfil.aspx?id={0}'>{1}</a></font>", usu._id, usu.nome);
                    div.InnerHtml += string.Format("<br /><br /><br /><font class='email'>E-mail: {0}</font>", usu.email);
                    phInformacoes.Controls.Add(div);
                }
            }
            else
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "servicoLista");
                div.InnerHtml += "<h4>Não foi encontrado um usuário com o filtro de busca informado</h4>";
                div.InnerHtml += "<br /><p>Informe outro parâmrtro de busca e tente novamente<p>";

                phInformacoes.Controls.Add(div);
            }
        }

        #region === Filtrar ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        public void FiltrarUsuarioPorEstado(string estado)
        {
            var dadosFiltro = from u in ltUsuario
                              where u.enderecosUsuario.Any(e => e.uf == estado)
                              select u;

            ltUsuario = dadosFiltro.ToList();
            MontarInfoUsuario(ltUsuario);
        }

        public void FiltrarUsuarioPorGenero(string sexo)
        {
            string sex = string.Empty;

            if (sexo.Contains("Masculino"))
                sex = "Masculino";
            else if (sexo.Contains("Feminino"))
                sex = "Feminino";

            var dadosFiltro = from u in ltUsuario
                              where u.sexo == sex
                              select u;

            ltUsuario = dadosFiltro.ToList();
            MontarInfoUsuario(ltUsuario);
        }

        #endregion
        #region === Get Filtros ===
        /// <summary>
        /// Busca quantidade de usuários encontrados de cada gênero (masculino e feminino)
        /// </summary>
        /// <returns>Retorna um array contento a quantidade de usuários encontrados de cada gênero (masculino e feminino)</returns>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        public string[] GetFiltrosGeneroUsuario()
        {
            if (ltUsuario != null)
            {
                string[] qtdPorTipo = new string[2];
                qtdPorTipo[0] = "Masculino (" + ltUsuario.Where(u => u.sexo == "0").Count() + ")";
                qtdPorTipo[1] = "Feminino (" + ltUsuario.Where(u => u.sexo == "1").Count() + ")";

                return qtdPorTipo;
            }
            else { return null; }
        }
        #endregion
        #endregion
        #region === Serviço ===
        public void LimparListaServico()
        {
            ltServico.Clear();
            ltServicoCompleta.Clear();
        }

        public void RemoverFiltrosServico()
        {
            ltServico = ltServicoCompleta;
            MontarInfoServico(ltServicoCompleta);
        }

        /// <summary>
        /// Preenche a tela com as informações dos serviços encontrados
        /// </summary>
        /// <param name="lista">Lista de serviços que contém as informações</param>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void MontarInfoServico(List<Servico> lista)
        {
            if (phInformacoes.Controls.Count > 0)
                phInformacoes.Controls.Clear();

            if (lista.Count() > 0)
            {
                string caminhoImagem = string.Empty;
                string descServico = string.Empty;

                foreach (var serv in lista)
                {
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "servicoLista");

                    caminhoImagem = ClsServicoBLL.BuscarImagemCategoria(serv.nomeCategoriaServico);
                    descServico = serv.descricao.Length <= 140 ? serv.descricao : serv.descricao.Substring(0, 140) + "...";

                    div.InnerHtml += "<p class='botoes'>";
                    div.InnerHtml += string.Format("<img src='{0}' alt='{1}' class='img' />", caminhoImagem, serv.nomeCategoriaServico);
                    div.InnerHtml += string.Format("<h4>{0}</h4>", serv.nome);
                    div.InnerHtml += "<br /><br />";
                    div.InnerHtml += "<label>Categoria:</label>" + serv.nomeCategoriaServico;
                    div.InnerHtml += "<br  />";
                    div.InnerHtml += "<label>Descrição:</label>" + descServico;
                    div.InnerHtml += "<br /><br />";
                    div.InnerHtml += string.Format("<a  class='btn' href='SocilicarOrcamento.aspx?t=0&id={0}&idServ={1}'>Contratar</a>&nbsp;", serv.idUsuario, serv._id);
                    div.InnerHtml += string.Format("<a  class='btn' href='VisualizarServico.aspx?t=0&id={0}&idServ={1}'>Ver Detalhes</a><br />", serv.idUsuario, serv._id);
                    div.InnerHtml += "</p>";
                   
                    phInformacoes.Controls.Add(div);
                }
            }
            else
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "servicoLista");
                div.InnerHtml += "<h4>Não foi encontrado um serviço com o filtro de pesquisa informado</h4>";
                div.InnerHtml += "<br /><p>Informe outro parâmrtro de busca e tente novamente<p>";

                phInformacoes.Controls.Add(div);
            }
        }

        /// <summary>
        /// Realiza a busca pelo serviço e caso a busca seja bem sucedida mostra a informação para o usuário, do contrário
        /// mostra a mensagem de erro ao usuário
        /// </summary>
        /// <param name="tipoBusca">Tipo da busca que deve ser executadda. Ex: buscar por nome, descrição, etc</param>
        /// <param name="filtro">Filtro que deve ser utilizado como parâmetro da busca</param>
        private void BuscarServicos(string tipoBusca, string filtro)
        {
            try
            {
                ClsServicoBLL servicoBLL = new ClsServicoBLL();

                switch (tipoBusca)
                {
                    case "Nome do Serviço":
                        ltServicoCompleta = servicoBLL.BuscarServicoPorNome(filtro, true, ((Usuario)Session["USUARIO"])._id);
                        break;

                    case "Descrição":
                        ltServicoCompleta = servicoBLL.BuscarServicoPorDescricao(filtro, true, ((Usuario)Session["USUARIO"])._id);
                        break;
                }

                ltServico = ltServicoCompleta;
                MontarInfoServico(ltServico);
            }
            catch (Exception x)
            {
                if (phInformacoes.Controls.Count > 0)
                    phInformacoes.Controls.Clear();

                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "servicoLista");
                div.InnerHtml += "<h4>Ocorreu um erro durante a execução da busca por serviços. Tente novamente mais tarde.</h4>";
                div.InnerHtml += string.Format("<br /><p><b>Erro:</b> {0}</p>", x.Message);

                phInformacoes.Controls.Add(div);
            }
        }

        #region === Filtrar ===
        /// <summary>
        /// Filtra os serviços selecionados pela categoria informada
        /// </summary>
        /// <param name="categoria">String contendo o nome da categoria que o usuário deseja aplicar o filtro</param>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        public void FiltrarServicoPorCategoria(string categoria)
        {
            categoria = Regex.Replace(categoria, @"\(([^)]*)\)", "");

            var dadosFiltro = from s in ltServico
                              where s.nomeCategoriaServico == categoria.Trim()
                              select s;

            ltServico = dadosFiltro.ToList();
            MontarInfoServico(ltServico);
        }

        /// <summary>
        /// Filtra os serviços selecionados pela classificação informada
        /// </summary>
        /// <param name="classificacao">String contendo a classsificação deseja para aplicar o filtro</param>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        public void FiltrarServicoPorClassificacao(string classificacao)
        {
            int nota = 0;

            if (classificacao.Contains("Zero"))
                nota = 0;
            else if (classificacao.Contains("Uma"))
                nota = 1;
            else if (classificacao.Contains("Duas"))
                nota = 2;
            else if (classificacao.Contains("Três"))
                nota = 3;
            else if (classificacao.Contains("Quatro"))
                nota = 3;
            else if (classificacao.Contains("Cinco"))
                nota = 5;

            var dadosFiltro = from s in ltServico
                              where s.notaMedia == nota
                              select s;

            ltServico = dadosFiltro.ToList();
            MontarInfoServico(ltServico);
        }

        /// <summary>
        /// Filtra os serviços de acordo com a faixa de proço informada
        /// </summary>
        /// <param name="minPreco">Preço minimo que  deve ser procurado</param>
        /// <param name="maxPreco">Preço máximo que  deve ser procurado</param>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        public void FiltrarServicoPorPreco(double minPreco, double maxPreco)
        {
            var dadosFiltro = from s in ltServico
                              where s.preco >= minPreco && s.preco <= maxPreco
                              select s;

            MontarInfoServico(dadosFiltro.ToList());
        }
        #endregion
        #region === Get Filtros  ===
        /// <summary>
        /// Busca as categorias dos serviços na lista de categorias de serviço. Este método só deve ser utilizado
        /// após a busca pelo serviço ser realizada. Do contrário ele irá retornar null.
        /// </summary>
        /// <returns>Um arraylist contendo todas as categorias dos serviços encontrados</returns>
        ///<by>Breno Pires - breno_spires@hotmail.com</by>
        public ArrayList GetFiltrosCategoriaServico()
        {
            if (ltServico.Count > 0 && ltServico != null)
            {
                ArrayList arFiltros = new ArrayList();

                var dados = from s in ltServico
                            select s.nomeCategoriaServico;

                string ultCategoria = string.Empty;
                int qtdCategoria = 1;

                foreach (var item in dados)
                {
                    if (ultCategoria == item)
                    {
                        qtdCategoria++;
                        arFiltros[arFiltros.Count - 1] = item + string.Format(" ({0})", qtdCategoria);
                    }
                    else
                    {
                        qtdCategoria = 1;
                        arFiltros.Add(item + " (1)");
                    }

                    ultCategoria = item;
                }

                if (arFiltros.Count > 0)
                    return arFiltros;
                else
                    return null;
            }
            else { return null; }
        }

        /// <summary>
        /// Busca a quantidade de serviços encontrado com cada classificação. Sendo elas sequenciais de 0 a 5.
        /// </summary>
        /// <returns>Array contendo em cada posição a quantidade de registros encontrado com a quantidade de estrelas informadas.</returns>
        public string[] GetFiltrosClassificacaoServico()
        {
            if (ltServico.Count > 0 && ltServico != null)
            {

                string[] qtdPorClassificacao = new string[6];

                qtdPorClassificacao[5] = "Zero Estrelas (" + ltServico.Where(s => s.notaMedia == 0).Count().ToString() + ")";
                qtdPorClassificacao[4] = "Uma Estrela (" + ltServico.Where(s => s.notaMedia == 1).Count().ToString() + ")";
                qtdPorClassificacao[3] = "Duas Estrelas (" + ltServico.Where(s => s.notaMedia == 2).Count().ToString() + ")";
                qtdPorClassificacao[2] = "Três Estrelas (" + ltServico.Where(s => s.notaMedia == 3).Count().ToString() + ")";
                qtdPorClassificacao[1] = "Quatro Estrelas (" + ltServico.Where(s => s.notaMedia == 4).Count().ToString() + ")";
                qtdPorClassificacao[0] = "Cinco Estrelas (" + ltServico.Where(s => s.notaMedia == 5).Count().ToString() + ")";

                return qtdPorClassificacao;
            }
            else { return null; }
        }
        #endregion
        #endregion
    }
}