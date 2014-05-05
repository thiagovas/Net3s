using System;
using System.Collections.Generic;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class Perfil : System.Web.UI.Page
    {
        private ClsUsuarioBLL usuarioBLL;
        private ClsServicoBLL servBll;

        //Propriedades que serão usadas ao mandar alguma solicitação para o usuario
        private Oid idNotificacao { get; set; }
        private static Oid idUsuRemetente { get; set; }
        private static Oid idDestinatario { get; set; }

        public static bool myself { get; set; }
        public static string nome { get; set; }
        public static string myAdress { get; set; }
        public static string profileAdress { get; set; }

        // String que guarda o ID do usuário da página para que ele possa ser acessado peloa light box
        protected string pageUsu { get; set; }

        protected System.Web.UI.HtmlControls.HtmlAnchor solicitarOrcamento;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Descomentar para funcionar o código de verdade. O código após isso é apenas em caracter de teste
                GetInformacoes();

                try { idUsuRemetente = ((Usuario)Session["USUARIO"])._id; }
                catch { Response.Redirect("../Erros/401.html", true); }

                try { idDestinatario = new Oid(Request["id"]); }
                catch { Response.Redirect("../Erros/404.html", true); }

                nome = ((Usuario)Session["USUARIO"]).nome;
                pageUsu = Request["id"].ToString();
            }
        }
        
        /// <summary>
        /// Recebe da url as informações da página e configura a página de acordo com as informações recebidas.
        /// </summary>
        private void GetInformacoes()
        {
            if (Session["USUARIO"] == null) //Se a sessão for nula.
                Response.Redirect("~/", true); //Redireciona para a tela de Login.

            if (string.IsNullOrEmpty(Request["id"])) // Se nao receber o valor do id da url irei carregar o perfil do usuário logado.
                Response.Redirect(string.Format("Perfil.aspx?id={0}", ((Usuario)Session["USUARIO"])._id), true);
            else
                hlEditar.NavigateUrl = "../User/ConfigGeral.aspx?id=" + (((Usuario)Session["USUARIO"])._id).ToString();

            if (!clsUtilidades.ValidarOid(Request["id"]))
                Response.Redirect("../Erros/404.html", true);

            Oid id = new Oid(Request["id"]);
            Oid idLogado = ((Usuario)Session["USUARIO"])._id;

            Session.Add("NOTIUSUARIO", id);

            usuarioBLL = new ClsUsuarioBLL();
            ClsServicoBLL servicoBLL = new ClsServicoBLL();
            var usu = usuarioBLL.BuscarUsuarioPorID(id);
            List<Servico> servicos = servicoBLL.BuscarTodos(id);
            lblNome.Text = usu.nome;

            // Calcula a média das notas dos serviços prestados e contratados.
            #region === Serviços Prestados ===
            int servPrestado = 0;

            foreach (var serv in servicos)
            {
                //servPrestado += serv.notaMedia;
                servPrestado += int.Parse(serv.notaMedia.ToString());
            }

            if (servPrestado > 0)
                servPrestado /= servicos.Count;

            ratServiPrestados.CurrentRating = servPrestado;
            #endregion
            #region === Serviços Contratados ===
            int servContatado = 0;

            //foreach (var serv in usu.historicoServicoUsuario)
            //{
              //  servContatado += serv.nota;
            //}

            if (servContatado > 0)
                servContatado = servContatado / usu.historicoServicoUsuario.Count;

            ratServiContratados.CurrentRating = servContatado;
            #endregion

            // Preenche as informações da aba 'Informações Pessoais'
            #region === Informações Pessoais ===
            lblInfoDaraNasc.Text = usu.dataNasc.ToString("dd/MM/yyyy") != "" ? usu.dataNasc.ToString("dd/MM/yyyy") : "Não Informado";
            lblInfoTelDois.Text = !string.IsNullOrEmpty(usu.telefone2) ? usu.telefone2 : "Não Informado";
            lblInfoCelDois.Text = !string.IsNullOrEmpty(usu.celular2)? usu.celular2 : "Não Informado";
            lblInfoTelUm.Text = !string.IsNullOrEmpty(usu.telefone1) ? usu.telefone1 : "Não Informado";
            lblInfoCelUm.Text = !string.IsNullOrEmpty(usu.celular1) ? usu.celular1 : "Não Informado";
            lblInfoEmail.Text = !string.IsNullOrEmpty(usu.email) ? usu.email : "Não Informado";
            lblInfoSite.Text = !string.IsNullOrEmpty(usu.site) ? usu.site : "Não Informado";
            lblInfoSexo.Text = usu.sexo == "0" ? "Masculino" : "Feminino";
            #endregion

            if (id != idLogado)
            {
                myself = false;
                servBll = new ClsServicoBLL();
                solicitarOrcamento.Visible = servBll.BuscarTodos(id).Count > 0 ? true : false;
                hlEditar.Visible = false;

                ClsContatoBLL contBll = new ClsContatoBLL();
                var countUsu = contBll.BuscarTodosContatos(idLogado);

                if (countUsu != null)
                {
                    foreach (var contato in countUsu)
                    {
                        if (contato.idContato == id)
                            btnAddToNetwork.Visible = false;
                    }
                }
                else
                {
                    btnAddToNetwork.Visible = true;
                }

                #region === Endereço ===
                if (usu.enderecosUsuario.Count > 0)
                {
                    var endereco = usu.enderecosUsuario[0];
                    myAdress = endereco.logradouro + ", ";
                    myAdress += endereco.numero.ToString() + ", ";

                    if (!string.IsNullOrEmpty(endereco.complemento))
                        myAdress += endereco.complemento + ", ";

                    myAdress += endereco.bairro + ", ";
                    myAdress += endereco.cidade + ", ";
                    myAdress += endereco.uf + ", ";
                }
                else
                    myAdress = "";

                profileAdress = "";
                #endregion
            }
            else
            {
                myself = false;
                btnAddToNetwork.Visible = false;
                solicitarOrcamento.Visible = false;

                #region === Endereço ===
                if (((Usuario)Session["USUARIO"]).enderecosUsuario.Count > 0)
                {
                    var endereco = ((Usuario)Session["USUARIO"]).enderecosUsuario[0];
                    myAdress = endereco.logradouro + ", ";
                    myAdress += endereco.numero.ToString() + ", ";

                    if (!string.IsNullOrEmpty(endereco.complemento))
                        myAdress += endereco.complemento + ", ";

                    myAdress += endereco.bairro + ", ";
                    myAdress += endereco.cidade + ", ";
                    myAdress += endereco.uf + ", ";
                }
                else
                    myAdress = "";

                if (usu.enderecosUsuario.Count > 0)
                {
                    var endereco = (usu.enderecosUsuario[0];
                    profileAdress = endereco.logradouro + ", ";
                    profileAdress += endereco.numero.ToString() + ", ";

                    if (!string.IsNullOrEmpty(endereco.complemento))
                        profileAdress += endereco.complemento + ", ";

                    profileAdress += endereco.bairro + ", ";
                    profileAdress += endereco.cidade + ", ";
                    profileAdress += endereco.uf + ", ";
                }
                else
                    profileAdress = "";
                #endregion
            }
        }

        /// <summary>
        /// Método que adiciona alguma solicitação a um usuário
        /// </summary>
        /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
        [System.Web.Services.WebMethod]
        public static bool AdicionaSolicitacao(string assunto, string descricao, string prioridade, string idServico, string qtdContratada)
        {
            Notificacao noti = new Notificacao();

            noti.assunto = assunto.Trim();
            noti.descricao = descricao.Trim();
            noti.status = StatusNotif.Pendente;
            noti.tipo = TipoNotificacao.Orcamento;
            noti.dataNotificacao = DateTime.Now;

            switch (prioridade)
            {
                case "0":
                    noti.prioridade = Prioridade.Baixa;
                    break;
                case "1":
                    noti.prioridade = Prioridade.Media;
                    break;
                case "2":
                    noti.prioridade = Prioridade.Alta;
                    break;
                default:
                    noti.prioridade = Prioridade.Urgente;
                    break;
            }

            noti.idServico = new Oid(idServico);
            noti.qtdContratada = Convert.ToDouble(qtdContratada);

            ClsNotificacaoBLL notiBLL = new ClsNotificacaoBLL();
            noti.idRemetente = idUsuRemetente;
            noti.idDestinatario = idDestinatario;
            notiBLL.InserirNotificacao(noti);

            return true;
        }

        [System.Web.Services.WebMethod]
        public static bool AdicionaNetwork()
        {
            ClsContatoBLL contBll = new ClsContatoBLL();
            contBll.InserirContatoNetwork(idDestinatario, idUsuRemetente, nome);
            return true;
        }

        [System.Web.Services.WebMethod]
        public static bool RemoverNetwork(string idCont, string idUsu)
        {
            ClsContatoBLL contBll = new ClsContatoBLL();
            contBll.ExcluirContatoNetwork(new Oid(idCont), new Oid(idUsu));
            return true;
        }

    }
}