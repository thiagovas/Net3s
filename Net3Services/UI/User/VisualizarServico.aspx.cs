using System;
using System.Web.Services;
using System.Web.UI;
using ClsLibBLL;
using Models;
using MongoDB;
using System.Web;

namespace UI.User
{
    public partial class VisualizarServico : System.Web.UI.Page
    {
        ClsServicoBLL servicoBLL;

        private static Oid idServ { get; set; }
        private static Oid idUsuario { get; set; }

        protected string pageServ { get; set; }
        protected string pageUsu { get; set; }


        protected System.Web.UI.HtmlControls.HtmlAnchor editar;
        protected System.Web.UI.HtmlControls.HtmlButton excluir;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarBotoes();
                idServ = new Oid(Request["idServ"]);
                idUsuario = ((Usuario)Session["USUARIO"])._id;

                BuscarInforServico();            
            }

            pageServ = Request["idServ"];
            pageUsu = Request["id"];
        }

        /// <summary>
        /// Busca as informações do serviço que está sendo visualizado e preenche os campos com suas informações 
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void BuscarInforServico()
        {
            Oid idServ = new Oid(Request["idServ"]);
            servicoBLL = new ClsServicoBLL();
            var serv = servicoBLL.buscarServicoPorId(idServ);

            lblNomeServ.Text = serv.nome;
            lblDescricao.Text = serv.descricao;
            lblPreco.Text = serv.preco.ToString("C");
            lblAvaliacao.Text = serv.getEstrelasNota(); 
            lblRegional.Text = serv.regional == true ? "Sim" : "Não";
            lblNivelRegio.Text = string.IsNullOrEmpty(serv.nivelRegionalidade) == true ? "Não se aplica" : serv.nivelRegionalidade;

            Session.Add("IDServicoEdicao", idServ);
        }

        /// <summary>
        /// Mostra o botão de edição quando o usuário logado é o dono do perfil e o de solicitar orçamento quando o usuário é um visitante
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void MostrarBotoes()
        {
            // ID do usuário cuja tela esta sendo visitada neste momento.
            Oid idUrl = new Oid(Request["id"]);
            // ID do usuário logado no momento.
            Oid idLogado = ((Usuario)Session["USUARIO"])._id;

            if (idUrl == idLogado)
            {
                editar.Visible = true;
                excluir.Visible = true;
                linkBtnOrcamento.Visible = false;
            }
            else
            {
                editar.Visible = false;
                excluir.Visible = false;
                linkBtnOrcamento.Visible = true;
            }
        }

        protected void linkBtnOrcamento_Click(object sender, EventArgs e)
        {
            
        }
        
        /// <summary>
        /// Edita as informações do serviço
        /// </summary>
        /// <by>Brneo Pires - breno_spires@hotmail.com</by>
        [System.Web.Services.WebMethod]
        public static string Editar(string descricao, string nivelRegionalidade, string nomeServ, string preco, string regional, string uniMedida, string categoria)
        {
            string retorno = string.Empty;

            try
            {
                Servico myServ = new Servico();
                myServ._id = idServ;
                myServ.nome = nomeServ.Trim();
                myServ.descricao = descricao.Trim();
                myServ.unidadeMedida = uniMedida.Trim();
                myServ.nomeCategoriaServico = categoria.Trim();
                myServ.regional = Convert.ToBoolean(regional);
                myServ.nivelRegionalidade = Convert.ToBoolean(regional) ? nivelRegionalidade : string.Empty;

                myServ.preco = Convert.ToDouble(preco.Replace('.', ','));

                ClsServicoBLL servicoBLL = new ClsServicoBLL();
                var resposta = servicoBLL.EditarServico(myServ, idUsuario);

                string erros = string.Empty;
                foreach (var item in resposta)
                {
                    erros += item.ToLower() == "ok" ? "" : "- " + item + "\n"; 
                }

                if (string.IsNullOrEmpty(erros))
                    retorno = "Serviço editado com sucesso.";
                else
                    retorno = erros;
            }
            catch(Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }


        [System.Web.Services.WebMethod]
        public static void Excluir()
        {
            ClsServicoBLL servicoBLL = new ClsServicoBLL();
            string msg = string.Empty;

            try
            {
                if (idServ != null)
                {
                    servicoBLL.DesativarServico(idServ);
                    msg = "Serviço excluido com sucesso.";
                }
            }
            catch (Exception ex)
            {
                msg = "Erro ao excluir: " + ex.Message;
            }

            HttpContext.Current.Session["msg"] = msg;
        }

        [System.Web.Services.WebMethod]
        public static string[] AtualizarTela() 
        {
            ClsServicoBLL servicoBLL = new ClsServicoBLL();
            var myServ = servicoBLL.buscarServicoPorId(idServ);

            string[] arServico = new string[9];
            arServico[0] = myServ.descricao;
            arServico[1] = myServ.nivelRegionalidade;
            arServico[2] = myServ.nome;
            arServico[3] = myServ.preco.ToString("C");
            arServico[4] = myServ.regional == true ? "Sim" : "Não";
            arServico[6] = myServ.unidadeMedida;
            arServico[7] = myServ.nomeCategoriaServico;
            arServico[8] = ClsServicoBLL.BuscarImagemCategoria(myServ.nomeCategoriaServico);
            return arServico;
        }
    }
};