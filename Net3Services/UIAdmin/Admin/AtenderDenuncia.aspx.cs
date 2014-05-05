using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using ClsLibBLL;
using MongoDB;
using System.Web.UI.HtmlControls;

namespace UIAdmin.Admin
{
    public partial class AtenderDenuncia : System.Web.UI.Page
    {
        public string DenunciaType { get; set; }
        public string idDenum { get; set; }
        public string idDenunc { get; set; }
        public string idAcu { get; set; }
        public string descDenum { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Denuncia den = new Denuncia();
                den = buscaValoresDenuncia(new Oid(Request.QueryString["id"]));
                //id da denuncia
                idDenunc = den._id.ToString();

                //Buscando o tipo da denuncia para uso geral
                DenunciaType = tipoDenuncia((short)den.tipoDenuncia);
                this.LblTipoDenuncia.Text = DenunciaType;

                descDenum = den.descricao;

                //para utilizar nas imagens
                idDenum = VerificaImagem(den.denunciante) ? den.denunciante.ToString() : "1";
                idAcu = VerificaImagem(den.acusado) ? den.acusado.ToString() : "1";
            }
        }

        protected void linkBtnSalvar_Click(object sender, EventArgs e)
        {
        }

        [System.Web.Services.WebMethod]
        public static string atualizaDenuncias(string punicao ,string resposta, string idDenum)
        {
            ClsDenunciaBLL denumBLL = new ClsDenunciaBLL();
            Denuncia den = new Denuncia();

            string retorno = string.Empty;
            try
            {
                //busca e atualiza denuncias
                #region Denuncias

                List<Denuncia> Lstden = denumBLL.BuscarDenunciaPorID(new Oid(idDenum));
                Lstden.ForEach(delegate(Denuncia d)
                {
                    den._id = d._id;
                    den.acusado = d.acusado;
                    den.atendente = d.atendente;
                    den.dataAtendimento = d.dataAtendimento;
                    den.dataDenuncia = d.dataDenuncia;
                    den.denunciante = d.denunciante;
                    den.descricao = d.descricao;
                    den.tipoDenuncia = d.tipoDenuncia;
                });

                //den = buscaValoresDenuncia(new Oid(Request.QueryString["id"]));
                den.punicao = punicao;
                den.resposta = resposta;
                //true ou seja ela ja foi atendida
                den.status = true;

                denumBLL.EditarDenuncia(den);

                #endregion

                //busca e atualiza administradores
                #region Administradores

                ClsAdministradorBLL admBLL = new ClsAdministradorBLL();
                Administrador adm = new Administrador();
                //depois disso atualiza no usuario
                Oid id = den.atendente;
                adm = admBLL.BuscarAdministradorPorID(id);
                //diminui uma denuncia pois ele já atendeu uma
                adm.quantDenum = adm.quantDenum != null ? adm.quantDenum - 1 : 0;
                //atualiza o administrador
                admBLL.EditarAdministrador(adm);

                #endregion

                //quando a resposta do usuário for igual  a afastamento
                #region Afastar(enviando notificações)

                //dapendendo dos resultados as ações
                //quando for so para avisar
                if (punicao.Equals("Afastar"))
                {
                    ClsNotificacaoBLL notifiBLL = new ClsNotificacaoBLL();
                    Notificacao notifi = new Notificacao();

                    notifi.assunto = "Denuncias";
                    notifi.dataNotificacao = DateTime.Now;
                    notifi.descricao = string.Format(@"Você foi denunciado por {0}, a denuncia foi encaminhada para um administrador do sistema, retire o que foi denunciado. Posteriomente entraremos em contato com você.", den.tipoDenuncia);
                    notifi.idDestinatario = den.acusado;
                    notifi.idRemetente = den.denunciante;
                    notifi.prioridade = (Prioridade)3;
                    notifi.tipo = (TipoNotificacao)2;

                    notifiBLL.InserirNotificacao(notifi);
                }

                #endregion

                //quando a resposta do administrador for igual a banir, ou seja, o ocorrido foi grave
                #region Banir(atualizando status e enviando email)

                //Inativar o usuario, quando a decisão do adm for banir
                if (punicao.Equals("Banir"))
                {
                    ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();
                    Usuario user = new Usuario();

                    user = usuBLL.BuscarUsuarioPorID(den.acusado);
                    user.status = 2;
                    //editando essa informação em usuario
                    usuBLL.EditarUsuario(user);
                    //logo depois enviar o email informando o ocorrido(fazer depois)
                }

                #endregion

                retorno = "ok";
            }
            catch { retorno = "Erro ao finalizar denuncia, tente novamente mais tarde."; }

            return retorno;
        }

        /// <summary>
        /// Busca o nome do denunciante e de acusado
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>retorna o nome dos caras</returns>
        protected string buscaLoginUsuario(Oid id)
        {
            ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();
            Usuario usu = new Usuario();
            string loginUsu = string.Empty;

            try
            {
                usu = usuBLL.BuscarUsuarioPorID(id);
                loginUsu = usu.login;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return loginUsu;
        }

        /// <summary>
        /// verifica os tipo de denuncia e para colocar na tela
        /// </summary>
        /// <param name="t">tipos de denuncia</param>
        /// <returns>string com o tipo da denuncia</returns>
        protected string tipoDenuncia(short t)
        {
            switch (t)
            {
                case 0: return "Foto Inadequada";
                case 1: return "Servicos Inaequados";
                case 2: return "Conteudo Indevido";
                case 3: return "Span";
                case 4: return "ConteudoIlegal";
                case 5: return "Conteudo Pornografico";
                default: return "Outros";
            }
        }

        /// <summary>
        /// Toda vez que precisar buscar algum dado ai está como
        /// </summary>
        /// <param name="id">id da denuncia(URL)</param>
        /// <returns>retorna a denuncia para ser usada em algum lugar</returns>
        protected Denuncia buscaValoresDenuncia(Oid id)
        {
            ClsDenunciaBLL denumBLL = new ClsDenunciaBLL();
            Denuncia resposta = new Denuncia();
            List<Denuncia> Lstden = new List<Denuncia>();
            try
            {
                Lstden = denumBLL.BuscarDenunciaPorID(id);
                Lstden.ForEach(delegate(Denuncia d)
                {
                    resposta._id = d._id;
                    resposta.acusado = d.acusado;
                    resposta.atendente = d.atendente;
                    resposta.dataAtendimento = d.dataAtendimento;
                    resposta.dataDenuncia = d.dataDenuncia;
                    resposta.denunciante = d.denunciante;
                    resposta.descricao = d.descricao;
                    resposta.tipoDenuncia = d.tipoDenuncia;
                });
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            return resposta;
        }

        /// <summary>
        /// Se o usuario tiver imagem cadastrada, a dele, se não a padrão
        /// </summary>
        /// <param name="id">Id do usuario que vc pegar a imagem</param>
        /// <returns>Se a imagem existir true, se não false</returns>
        public bool VerificaImagem(Oid id)
        {
            ClsUsuarioBLL usuBll = new ClsUsuarioBLL();
            return usuBll.VerificarImagem(id.ToString());
        }
    }
}