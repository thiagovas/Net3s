using Models;
using System;
using MongoDB;
using ClsLibBLL;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace UI.User
{
    public partial class VisualizarCurriculum : System.Web.UI.Page
    {
        ClsUsuarioBLL usuarioBLL;
        protected System.Web.UI.HtmlControls.HtmlAnchor btnEditarCurriculum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Request["id"] == ((Usuario)Session["USUARIO"])._id.ToString())
                        btnEditarCurriculum.HRef = "EditarCurriculum.aspx?id=" + Request["id"];
                    else
                        btnEditarCurriculum.Visible = false;

                    var idUsu = new Oid(Request["id"]);
                    MontarPagina(idUsu);
                }
                catch
                {
                    Response.Redirect("../Erros/404.html", true);
                }
            }
        }

        private void MontarPagina(Oid id)
        {
            usuarioBLL = new ClsUsuarioBLL();
            var usu = usuarioBLL.BuscarUsuarioPorID(id);

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "conteudoVisu");

            // Busca as informações do currículum
            ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
            var meuCurriculum = curriculumBLL.BuscarCurriculum(id);

            if (meuCurriculum != null)
            {
                #region === Informações Pessoais ===
                div.InnerHtml += "<h3><i class='icon-user'></i>Informações pessoais</h3><p>";

                // Nome do usuário
                div.InnerHtml += string.Format("<label>{0}</label>", usu.nome);

                // Adicionar endereço
                if (usu.enderecosUsuario.Count() > 0)
                {
                    var end = usu.enderecosUsuario[0];
                    if (!string.IsNullOrEmpty(end.complemento))
                        div.InnerHtml += string.Format("<label class='valor'>{0}, {1} - {2} - {3}</label>", end.logradouro, end.numero, end.complemento, end.bairro);
                    else
                        div.InnerHtml += string.Format("<label class='valor'>{0}, {1} - {2} - </label>", end.logradouro, end.numero, end.bairro);

                    div.InnerHtml += string.Format("<label class='valor'>{0} - {1}/{2}/{3}</label>", end.cep, end.cidade, end.uf, end.pais);
                }

                // Adicionar telefone
                if (!string.IsNullOrEmpty(usu.telefone1) && !string.IsNullOrEmpty(usu.telefone2))
                    div.InnerHtml += string.Format("<label class='valor'><b>Telefones:</b>{0} e {1}</label>", usu.telefone1, usu.telefone2);
                else if (!string.IsNullOrEmpty(usu.telefone1) && string.IsNullOrEmpty(usu.telefone2))
                    div.InnerHtml += string.Format("<label class='valor'><b>Telefone:</b>{0}</label>", usu.telefone1);
                else if (string.IsNullOrEmpty(usu.telefone1) && !string.IsNullOrEmpty(usu.telefone2))
                    div.InnerHtml += string.Format("<label class='valor'><b>Telefone:</b>{0}</label>", usu.telefone2);

                // Adicionar celular
                if (!string.IsNullOrEmpty(usu.celular1) && !string.IsNullOrEmpty(usu.celular2))
                    div.InnerHtml += string.Format("<label class='valor'><b>Celulares:</b>{0} e {1}</label>", usu.celular1, usu.celular2);
                else if (!string.IsNullOrEmpty(usu.celular1) && string.IsNullOrEmpty(usu.celular2))
                    div.InnerHtml += string.Format("<label class='valor'><b>Celular:</b>{0}</label>", usu.celular1);
                else if (string.IsNullOrEmpty(usu.celular1) && !string.IsNullOrEmpty(usu.celular2))
                    div.InnerHtml += string.Format("<label class='valor'><b>Celular:</b>{0}</label>", usu.celular2);

                //E-mail do usuário
                div.InnerHtml += string.Format("<lable class='valor'><b>E-mail:</b>{0}</label></p><br />", usu.email);
                #endregion

                // Variáveis com as informações do curriculum
                var cursos = meuCurriculum.ObjCursos;
                var premios = meuCurriculum.ObjPremios;
                var idimomas = meuCurriculum.ObjIdiomas;
                var experiencias = meuCurriculum.ObjExperiencia;
                var certificados = meuCurriculum.ObjCertificacao;

                #region === Cursos ===
                if (cursos.Count() > 0)
                {
                    div.InnerHtml += "<h3><i class='icon-book'></i>Formação Acadêmica</h3><p>";

                    foreach (var cur in cursos)
                    {
                        div.InnerHtml += string.Format("<label>{0}</label>", cur.Nome);
                        div.InnerHtml += string.Format("<label class='valor'><b>Instituição:</b>{0}</label>", cur.NomeInstituicao);
                        div.InnerHtml += string.Format("<label class='valor'><b>Duração:</b>De {0} até {1}</label><br />", cur.DataInicio.ToString("dd/MM/yyyy"), cur.DataFim.ToString("dd/MM/yyyy"));
                    }

                    div.InnerHtml += "</p>";
                }
                #endregion
                #region === Idiomas ===

                if (idimomas.Count() > 0)
                {
                    div.InnerHtml += "<h3><i class='icon-globe'></i>Idiomas</h3><p>";

                    foreach (var idi in idimomas)
                    {
                        div.InnerHtml += string.Format("<label>{0}</label>", idi.Nome);
                        div.InnerHtml += string.Format("<label class='valor'><b>Fluência:</b>{0}</label><br />", idi.Fluencia.ToString());
                    }

                    div.InnerHtml += "</p>";
                }
                #endregion
                #region === Certificados ===

                if (certificados.Count() > 0)
                {
                    div.InnerHtml += "<h3><i class='icon-certificate'></i>Certificados</h3><p>";

                    foreach (var cert in certificados)
                    {
                        div.InnerHtml += string.Format("<label>{0}</label>", cert.Nome);
                        div.InnerHtml += string.Format("<label class='valor'><b>Instituição:</b>{0}</label>", cert.Instituicao);
                        div.InnerHtml += string.Format("<label class='valor'><b>Data de Expedição:</b>{0}</label>", cert.Data.ToString("dd/MM/yyyy"));
                        div.InnerHtml += string.Format("<label class='valor'><b>Descrição:</b>{0}</label><br />", cert.Descricao);
                    }

                    div.InnerHtml += "</p>";
                }
                #endregion
                #region === Experiências ===
                if (experiencias.Count() > 0)
                {
                    div.InnerHtml += "<h3><i class='icon-cogs'></i>Experiências</h3><p>";

                    foreach (var exp in experiencias)
                    {
                        div.InnerHtml += string.Format("<label>{0}<label>", exp.NomeLocal);
                        div.InnerHtml += string.Format("<label class='valor'><b>Data de Inicio:</b>{0}<label>", exp.DataInicio.ToString("dd/MM/yyyy"));
                        div.InnerHtml += string.Format("<label class='valor'><b>Data de Fim:</b>{0}<label>", exp.Atual ? "Emprego Atual" : exp.DataInicio.ToString("dd/MM/yyyy"));
                        div.InnerHtml += string.Format("<label class='valor'><b>Atividades Realizadas:</b>{0}</label><br />", exp.DescricaoAtividades);
                    }

                    div.InnerHtml += "</p>";
                }
                #endregion
                #region === Prêmios ===

                if (premios.Count() > 0)
                {
                    div.InnerHtml += "<h3><i class='icon-trophy'></i>Prêmios</h3><p>";

                    foreach (var pre in premios)
                    {
                        div.InnerHtml += string.Format("<label>{0}<label>", pre.Nome);
                        div.InnerHtml += string.Format("<label class='valor'><b>Instiruição:</b>{0}<label>", pre.Instituicao);
                        div.InnerHtml += string.Format("<label class='valor'><b>Data:</b>{0}<label>", pre.Data.ToString("dd/MM/yyyy"));
                        div.InnerHtml += string.Format("<label class='valor'><b>Descrição:</b>{0}</label><br />", pre.Descricao);
                    }

                    div.InnerHtml += "</p>";
                }
                #endregion
            }
            else
            {
                if (Request["id"] == ((Usuario)Session["USUARIO"])._id.ToString())
                    div.InnerHtml += "<label>Você não possuim um currículo cadastrado. Edite seu currículum para que outros usuários possam acessar mais informções sobre sua capacidade profissional.</label>";
                else
                    div.InnerHtml += string.Format("<label>{0} não possuim um currículum cadastrado.</label>", usu.nome);

            }

            phDados.Controls.Add(div);
        }
    }
}