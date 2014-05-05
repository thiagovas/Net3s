using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibBLL;
using MongoDB;
using Models;

namespace UI.User
{
    public partial class EditarPremio : System.Web.UI.Page
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

            txtNomeInstPre.Text = curriculo.ObjPremios[index].Instituicao;
            txtNomePremio.Text = curriculo.ObjPremios[index].Nome;
            txtDescPre.Text = curriculo.ObjPremios[index].Descricao;
            txtDataPre.Text = curriculo.ObjPremios[index].Data.ToString("dd/MM/yyyy");
        }


        [System.Web.Services.WebMethod]
        public static string Editar(string id, int index, string nome, string instituicao, string descricao, string data)
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

                curriculo.ObjPremios[index].Nome = nome.Trim();
                curriculo.ObjPremios[index].Descricao = descricao.Trim();
                curriculo.ObjPremios[index].Data = Convert.ToDateTime(data);
                curriculo.ObjPremios[index].Instituicao = instituicao.Trim();

                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Prêmio editado com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }

    }
}