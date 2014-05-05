using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using ClsLibDAL;
using Models;

namespace UIAdmin.Componentes
{
    public partial class Denuncia : System.Web.UI.UserControl
    {
        ClsDenunciaBLL denun = new ClsDenunciaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            gerarComponetes();
        }

        private void gerarComponetes()
        {
            Administrador adm = (Administrador)Session["Administrador"];
            var lstDen = denun.BuscarDenunciaAtendente(adm._id.ToString());

            if (lstDen != null)
            {
                HtmlGenericControl hg = new HtmlGenericControl("div");
                hg.InnerHtml += "<ul>";

                foreach (Models.Denuncia den in lstDen)
                {
                    hg.InnerHtml += "<li>";
                    hg.InnerHtml += string.Format("<a id='Denuncia' name='{0}' href='#'>{1}</a>",
                        den._id.ToString().Replace("\"",""), den._id.ToString());
                    hg.InnerHtml += "</li>";
                }
                hg.InnerHtml += "</ul>";
                phDenuncia.Controls.Add(hg);
            }
        }
    }
}