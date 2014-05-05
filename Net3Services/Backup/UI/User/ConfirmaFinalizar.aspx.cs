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
    public partial class ConfirmaFinalizar : System.Web.UI.Page
    {
        ClsOrcamentoBLL orcamBLL = new ClsOrcamentoBLL();

        public static Oid id { get; set; }
        public static Orcamento orc { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Usuario usu = (Usuario)Session["Usuario"];
                id = usu._id;

                orc = orcamBLL.BuscarOrcamentoPorID(new Oid(Request.QueryString["id"]));
            }
        }

        
        [System.Web.Services.WebMethod]
        public static string finalizarServico()
        {
            string retorno = string.Empty;
            ClsOrcamentoBLL orcamBll = new ClsOrcamentoBLL();
            try
            {
                orc.status = StatusOrcam.finalizado;
                orcamBll.EditarOrcamento(orc);
                retorno = orc.id.ToString();
            }
            catch { throw new Exception("Impossivel finalizar o serviço"); }

            return retorno;
        }
    }
}