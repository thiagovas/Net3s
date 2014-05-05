using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using ClsLibBLL;
using MongoDB;

namespace UI.User
{
    public partial class Denunciar : System.Web.UI.Page
    {
        private static Oid idAcusado;
        private static Oid idDenunciante;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                idDenunciante = ((Usuario)Session["USUARIO"])._id;
                idAcusado = new Oid(Request["id"]);
            }
        }

        [System.Web.Services.WebMethod]
        public static string DenunciarUsuario(Int16 tipoDenuncia, string descricao)
        {
            string retorno = string.Empty;

            try
            {
                Denuncia den = new Denuncia();
                den.status = false;
                den.acusado = idAcusado;
                den.descricao = descricao;
                den.denunciante = idDenunciante;
                den.dataDenuncia = DateTime.Now;
                den.tipoDenuncia = (TipoDenuncia)tipoDenuncia;

                ClsAdministradorBLL adminBLL = new ClsAdministradorBLL();
                var idAtendente = adminBLL.verificaMenorQuantDenuncia();

                // Se retornar null significa que não existem administradores cadastrados, ou seja, fudeu!
                // Envia uma mensagem de erro ao usuário para 'disfarçar' o erro da equipe kkk.
                // Caso esteja testando e occora este erro cadastre um administrador e seja feliz.
                if (idAtendente != null)
                    den.atendente = idAtendente;
                else
                    throw new Exception("Ocorreu um erro ao enviar a denúncia.");

                ClsDenunciaBLL denBLL = new ClsDenunciaBLL();
                denBLL.InserirDenuncia(den);

                #region Atualiza Denuncias em adm
                
                Administrador adm = new Administrador();
                ClsAdministradorBLL admBLL = new ClsAdministradorBLL();
                adm = admBLL.BuscarAdministradorPorID(idAtendente);
                //diminui uma denuncia pois ele já atendeu uma
                adm.quantDenum = adm.quantDenum != null ? adm.quantDenum + 1 : 1;
                //atualiza o administrador
                admBLL.EditarAdministrador(adm);
                
                #endregion

                idAcusado = null;
                idDenunciante = null;
                retorno = "Denúncia realizada com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }
    }
}