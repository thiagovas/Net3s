using System;
using System.Collections.Generic;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class Contratar : System.Web.UI.Page
    {
        ClsOrcamentoBLL orcBll;
        ClsServicoBLL servBll;
        ClsUsuarioBLL usuBll;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Oid idUsu = new Oid(Request["id"]);
                this.GetInfo(idUsu);
            }
        }

        void GetInfo(Oid idUsu)
        {
            orcBll = new ClsOrcamentoBLL();
            usuBll = new ClsUsuarioBLL();
            servBll = new ClsServicoBLL();

            List<Orcamento> orcamento = orcBll.BuscarOrcamentoPorUsuario(idUsu, new Orcamento());
            Orcamento orc = orcamento[0];
            
            var nomesServico = servBll.buscarServicoPorId(orc.idServico).nome;
            var nomePrestador = usuBll.BuscarUsuarioPorID(idUsu).nome;
            var nomeContratante = usuBll.BuscarUsuarioPorID(orc.contratate).nome;
            
            lblServ.Text = nomesServico;
            lblPrest.Text = nomePrestador;
            lblContrat.Text = nomeContratante;
            lblDataIni.Text = orc.dataInicio.ToString();
            lblDataFim.Text = orc.dataFim.ToString();
            lblDesc.Text = orc.descricao;
            lblPreco.Text = orc.preco.ToString();
        }

        [System.Web.Services.WebMethod]
        public static bool ContratarServico()
        {
            try
            {
                Orcamento orc = new Orcamento();
                ClsOrcamentoBLL orcBll = new ClsOrcamentoBLL();

                orc.status = StatusOrcam.aprovado;

                orcBll.EditarOrcamento(orc);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}