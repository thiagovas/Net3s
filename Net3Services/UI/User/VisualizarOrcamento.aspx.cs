using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class VisualizarOrcamento : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlButton btnFinalizar;
        private string idOrc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ClsOrcamentoBLL orcamBll = new ClsOrcamentoBLL();
                    ClsUsuarioBLL usuarioBll = new ClsUsuarioBLL();
                    ClsServicoBLL servicoBll = new ClsServicoBLL();

                    idOrc = Request["id"];
                    var idOrcamento = new Oid(Request["id"]);
                    var orcamento = orcamBll.BuscarOrcamentoPorID(idOrcamento);

                    lblDescricao.Text = orcamento.descricao;
                    lblStatus.Text = orcamento.status.ToString();
                    lblPreco.Text = orcamento.preco.ToString("0.00");
                    lblFim.Text = orcamento.dataFim.ToString("dd/MM/yyyy");
                    lblInicio.Text = orcamento.dataInicio.ToString("dd/MM/yyyy");
                    lblServico.Text = servicoBll.buscarServicoPorId(orcamento.idServico).nome;
                    lblPrestador.Text = usuarioBll.BuscarUsuarioPorID(orcamento.prestador).nome;
                    lblContatante.Text = usuarioBll.BuscarUsuarioPorID(orcamento.contratante).nome;

                    if (orcamento.status == StatusOrcam.finalizado)
                        btnFinalizar.Visible = false;
                }
                catch
                {
                    Response.Redirect("../Erros/404.html", true);
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string finalizarServico(string id)
        {
            string retorno = string.Empty;
            ClsOrcamentoBLL orcamBll = new ClsOrcamentoBLL();
            var orc = orcamBll.BuscarOrcamentoPorID(new Oid(id));

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