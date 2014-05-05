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
    public partial class EditarExperiencia : System.Web.UI.Page
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

            txtNomeEmpresa.Text = curriculo.ObjExperiencia[index].NomeLocal;
            txtAtividadesExp.Text = curriculo.ObjExperiencia[index].DescricaoAtividades;
            txtDataInicioExp.Text = curriculo.ObjExperiencia[index].DataInicio.ToString("dd/MM/yyyy");

            if (curriculo.ObjExperiencia[index].Atual)
            {
                txtDataFimExp.Enabled = false;
                rbSim.Checked = true;
            }
            else
            {
                txtDataFimExp.Text = curriculo.ObjExperiencia[index].DataFim.ToString("dd/MM/yyyy");
                txtDataFimExp.Enabled = true;
                rbNao.Checked = true;
            }
        }


        [System.Web.Services.WebMethod]
        public static string Editar(string id, int index, string nomeEmp, string dataInicio, string dataFim, string atividades, bool atual)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a edição.");

                if (index < 0)
                    throw new Exception("Selecione uma experiência para realizar a edição.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);

                curriculo.ObjExperiencia[index].Atual = atual;
                curriculo.ObjExperiencia[index].NomeLocal = nomeEmp;
                curriculo.ObjExperiencia[index].DescricaoAtividades = atividades;
                curriculo.ObjExperiencia[index].DataInicio = Convert.ToDateTime(dataInicio);
               
                if(!atual)
                    curriculo.ObjExperiencia[index].DataFim = Convert.ToDateTime(dataFim);
               
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Experiência editada com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }
    }
}