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
    public partial class EditarIdioma : System.Web.UI.Page
    {
        protected string id { get; set; }
        protected int index { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                id = ((Usuario)Session["USUARIO"])._id.ToString();
                index = Convert.ToInt32(Request["index"]);
                BuscarInfo();
            }
        }

        private void BuscarInfo()
        {
            ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
            var curriculo = curriculumBLL.BuscarCurriculum(new Oid(id));

            txtNomeIdioma.Text = curriculo.ObjIdiomas[index].Nome;
            ddlFluencia.SelectedValue = curriculo.ObjIdiomas[index].Fluencia.ToString();
        }

        [System.Web.Services.WebMethod]
        public static string Editar(string id, int index, string nomeIdioma, string fluencia)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a edição.");

                if (index < 0)
                    throw new Exception("Selecione um idioma para realizar a edição.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);

                curriculo.ObjIdiomas[index].Nome = nomeIdioma.Trim();
                
                switch (fluencia)
                {
                    case "Iniciante":
                        curriculo.ObjIdiomas[index].Fluencia = FluenciaIdioma.Iniciante;
                        break;

                    case "Intermerdiario":
                        curriculo.ObjIdiomas[index].Fluencia = FluenciaIdioma.Intermerdiario;
                        break;

                    case "Avancado":
                        curriculo.ObjIdiomas[index].Fluencia = FluenciaIdioma.Avancado;
                        break;

                    case "Fluente":
                        curriculo.ObjIdiomas[index].Fluencia = FluenciaIdioma.Fluente;
                        break;

                    case "Nativo":
                        curriculo.ObjIdiomas[index].Fluencia = FluenciaIdioma.Nativo;
                        break;
                }
                
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Idioma editado com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }

    }
}