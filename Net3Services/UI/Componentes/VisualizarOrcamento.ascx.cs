using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.Componentes
{
    public partial class VisualizarOrcamento : System.Web.UI.UserControl
    {
        List<Orcamento> LstOrcam = new List<Orcamento>();

        /// <summary>
        /// Verifica de onde está vindo o orcamento.
        /// 1- Pedido de Orçamento 
        /// 2- Orçamentos Receidos
        /// 3- Orcamentos Feitos
        /// </summary>
        public string tipo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tipo = Request.QueryString["i"];
                if (tipo.Equals("1")) 
                    BuscarPedidosDeOrcamento();
                else
                    BuscarOrcamentos(tipo);
            }
        }

        /// <summary>
        /// Busca todos os orçamentos realizados por aquele usuário 
        /// </summary>
        private void BuscarOrcamentos(string tipo)
        {
            //pega os valores do usuario logado
            Usuario usu = (Usuario)Session["Usuario"];
            ClsOrcamentoBLL orcamBLL = new ClsOrcamentoBLL();
            ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");
            
            if (tipo == "2")
            {
                LstOrcam = orcamBLL.BuscarQuantOrcamentosNaoAprovadosContrat(usu._id);
                div.InnerHtml += "<h1>Orçamentos Recebidos</h1><br /><br />";
            }
            else
            {
                LstOrcam = orcamBLL.BuscaOrcamentoNaoAprovadosPrest(usu._id);
                div.InnerHtml += "<h1>Orçamentos Feitos</h1><br /><br />";
            }

            string nomeFoto = string.Empty;
            if (LstOrcam != null)
            {
                string status = string.Empty;

                LstOrcam.ForEach(delegate(Orcamento o)
                {
                    //valores do contratante
                    Usuario Contratante = new Usuario();
                    Contratante = usuBLL.BuscarUsuarioPorID(o.contratante);

                    //Aqui ele gera a imagem de acordo com a informação de nome
                    if (usuBLL.VerificarImagem(o.contratante.ToString()))
                        nomeFoto = o.contratante.ToString();
                    else
                        nomeFoto = "1";

                    status = o.status == StatusOrcam.aprovado ?  "Atendido" : "Não atendido";

                    //Gerando todo HTML
                    div.InnerHtml += string.Format("<a href='ResponderOrcamento.aspx?id={0}' class='orcamento'><div class='atualizacao'>", o.contratante);
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += string.Format("<img src='../Componentes/BuscaImagens.ashx?id={0}' alt='' class='img'/>", nomeFoto);
                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", Contratante.nome);
                    div.InnerHtml += string.Format("<time pubdate class='data'>{0}</time>", o.dataInicio.ToString("dd/MM/yyyy"));
                    div.InnerHtml += "<br /><br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'><b>Status: </b>{0}<br /><b>Descrição: </b>{1}</p>", status, o.descricao);
                    div.InnerHtml += "</article></div></a>";
                });
            }
            else
            {
                div.InnerHtml += "<h4>Nenhum orçamento pendente!</h4>";
            }

            VOrcamento.Controls.Add(div);
        }

        /// <summary>
        /// Busca as notificações contendo os pedidos de orçamento do pedido
        /// </summary>
        private void BuscarPedidosDeOrcamento()
        {
            Usuario user = (Usuario)Session["Usuario"];
            Oid idUsu = user._id;

            ClsNotificacaoBLL notifiBLL = new ClsNotificacaoBLL();
            List<Notificacao> notifi = new List<Notificacao>();
            ClsServicoBLL servBll = new ClsServicoBLL();
            ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();

            notifi = notifiBLL.BuscaTodasOrcamentarias(idUsu);
            string nomeFoto = string.Empty;
            string servico = string.Empty;

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");
            div.InnerHtml += "<h1>Pedidos de Orçamento</h1><br /><br />";

            if (notifi != null)
            {
                div.InnerHtml += "<p>Clique sobre um pedido de orçamnto para visualizar mais informações sobre ele.</p><br />";

                notifi.ForEach(delegate(Notificacao no)
                {
                    //busca os valores do prestador
                    Usuario Prestador = new Usuario();
                    Prestador = usuBLL.BuscarUsuarioPorID(no.idRemetente);

                    //Aqui ele gera a imagem de acordo com a informação de nome
                    if (usuBLL.VerificarImagem(no.idRemetente.ToString()))
                        nomeFoto = no.idRemetente.ToString();
                    else
                        nomeFoto = "1";

                    //Pega o nome do serviço
                    servico = servBll.buscarServicoPorId(no.idServico).nome;

                    //Gerando todo HTML
                    div.InnerHtml += string.Format("<a href='AprovarOrcamento.aspx?id={0}&idNoti={1}&idServ={2}'><div class='atualizacao'>", no.idRemetente, no._id, no.idServico);
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += string.Format("<img src='../Componentes/BuscaImagens.ashx?id={0}' alt='' class='img'/>", nomeFoto);
                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", servico);
                    div.InnerHtml += string.Format("<time pubdate class='data'>{0}</time>", no.dataNotificacao.ToString("dd/MM/yyyy"));
                    div.InnerHtml += "<br /><br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'>{0}</p>", no.descricao);
                    div.InnerHtml += "</article></div></a>";
                });
            }
            else
            {
                div.InnerHtml += "<h3>Nenhum orçamento pendente!</h3>";
            }

            VOrcamento.Controls.Add(div);
        }
    }
}