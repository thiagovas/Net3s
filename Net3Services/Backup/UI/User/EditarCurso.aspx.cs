using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using MongoDB;
using ClsLibBLL;

namespace UI.User
{
    public partial class EditarCurso : System.Web.UI.Page
    {
        protected string id { get; set; }
        protected string nomeCurso { get; set; }
        protected string nomeInstituicao { get; set; }
        protected string dataInicio { get; set; }
        protected string dataFim { get; set; }
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
            Oid idUsu = new Oid(id);
            ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
            var curriculo = curriculumBLL.BuscarCurriculum(idUsu);

            nomeCurso = curriculo.ObjCursos[index].Nome;
            nomeInstituicao = curriculo.ObjCursos[index].NomeInstituicao;
            dataFim = curriculo.ObjCursos[index].DataFim.ToString("dd/MM/yyyy");
            dataInicio = curriculo.ObjCursos[index].DataInicio.ToString("dd/MM/yyyy");
        }

        [System.Web.Services.WebMethod]
        public static string Editar(string id, int index, string nome, string nomeInstituicao, string dataInicio, string dataFim)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a edição.");

                if (index < 0)
                    throw new Exception("Selecione um curso para realizar a edição.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);
                
                curriculo.ObjCursos[index].Nome = nome;
                curriculo.ObjCursos[index].NomeInstituicao = nomeInstituicao;
                curriculo.ObjCursos[index].DataFim = Convert.ToDateTime(dataFim);
                curriculo.ObjCursos[index].DataInicio = Convert.ToDateTime(dataInicio);
                
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Curso editado com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }
    }
}