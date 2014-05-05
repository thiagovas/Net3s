using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UIAdmin
{
    public partial class Perfil1 : System.Web.UI.Page
    {
        ClsDenunciaBLL denun = new ClsDenunciaBLL();
        List<Denuncia> LstDen = new List<Denuncia>();
        string id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //buscar a quantidade de denuncia e colocar no accordeon
            Administrador adm = (Administrador)Session["Administrador"];
            id = adm._id.ToString();

            BuscaDenunciasAdm();
        }

        private void BuscaDenunciasAdm()
        {
            LstDen = denun.BuscarDenunciaAtendente(id);

            if (LstDen == null || LstDen.Count == 0) this.LblDenuncias.Text = "Nenhuma nova denuncia para ser atendida";
            else this.LblDenuncias.Text = LstDen.Count().ToString() + " novas denuncias para serem atendidas";
        }
    }
}