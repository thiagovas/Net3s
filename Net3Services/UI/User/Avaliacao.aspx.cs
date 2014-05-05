using System;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class Avaliacao : System.Web.UI.Page
    {
        // Indica se o usuario é o contratante ou o prestador do serviço
        private bool contratante;

        private Oid idOrcamento;
        private Oid idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {

            try { idOrcamento = new Oid(Request["idOrc"]); }
            catch { Response.Redirect("../Erros/404.aspx"); }

            ClsOrcamentoBLL orcamentoBLL = new ClsOrcamentoBLL();
            var orcaemnto = orcamentoBLL.BuscarOrcamentoPorID(idOrcamento);

            if (orcaemnto.prestador == idUsuario)
            {
                panelContratante.Visible = false;
                panelPrestador.Visible = true;
                contratante = false;
            }
            else
            {
                panelContratante.Visible = true;
                panelPrestador.Visible = false;
                contratante = true;
            }
        }

        protected void btnAvaliar_Click(object sender, EventArgs e)
        {
            HistoricoServico hist = new HistoricoServico();
            hist.idOrcamento = idOrcamento;
            
            if (contratante)
            {
                hist.tipoServico = 0;
                hist.avaliacaoPrestador.Preco = ratPreco.CurrentRating;
                hist.avaliacaoPrestador.QualidadeServico = ratQualidade.CurrentRating;
                hist.avaliacaoPrestador.TempoExecucaoServico = ratTempo.CurrentRating;
            }
            else
            {
                hist.tipoServico = 1;
                hist.avaliacaoContratante.Pagamento = ratPagamento.CurrentRating;
            }

            ClsHistoricoServicoBLL historicoBLL = new ClsHistoricoServicoBLL();
            historicoBLL.Inserir(idUsuario, hist);
        }
    }
}