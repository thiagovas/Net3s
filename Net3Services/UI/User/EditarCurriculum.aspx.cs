using System;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClsLibBLL;
using Models;
using MongoDB;
using System.Collections.Generic;

namespace UI.User
{
    public partial class Curriculum : System.Web.UI.Page
    {
        protected string pageUsu { get; set; }

        ClsCurriculumBLL curriculumBLL;
        Models.Curriculum meuCurriculum;
        Oid idUsu;

        #region === Eventos ===
        protected void Page_Load(object sender, EventArgs e)
        {
            try { idUsu = ((Usuario)Session["USUARIO"])._id; }
            catch { Response.Redirect("../Erros/401.html"); }

            // ID utilizado na execução dos webmethods
            pageUsu = idUsu.ToString();

            curriculumBLL = new ClsCurriculumBLL();
            meuCurriculum = curriculumBLL.BuscarCurriculum(idUsu);

            if (meuCurriculum != null)
            {
                MontarCursos(meuCurriculum.ObjCursos);
                MontarIdiomas(meuCurriculum.ObjIdiomas);
                MontarPremios(meuCurriculum.ObjPremios);
                MontarExperiencias(meuCurriculum.ObjExperiencia);
                MontarCertificados(meuCurriculum.ObjCertificacao);
            }
            else
            {
                MontarTelaNull();
            }
        }

        protected void btnCadCert_Click(object sender, EventArgs e)
        {
            Certificacao cert = new Certificacao();
            DateTime? data;
            DateTime data2;

            if (DateTime.TryParse(txtDataCert.Text.Trim(), out data2))
            {
                data = data2;
                cert.Data = data.Value;
                txtDataCert.CssClass = "";
            }
            else
            {
                data = null;
                txtDataCert.Focus();
                txtDataCert.CssClass = "erro";
            }

            if (data != null)
            {
                bool validade = true;
                curriculumBLL = new ClsCurriculumBLL();

                cert.Nome = txtNomeCert.Text.Trim();
                cert.Descricao = txtDescCert.Text.Trim();
                cert.Instituicao = txtNomeInstCert.Text.Trim();

                var resp = curriculumBLL.ValidarInfoCertificados(cert);

                if (resp[0])
                {
                    txtNomeCert.CssClass = "";
                }
                else
                {
                    txtNomeCert.CssClass = "erro";
                    validade = false;
                }

                if (resp[1])
                {
                    txtNomeInstCert.CssClass = "";
                }
                else
                {
                    txtNomeInstCert.CssClass = "erro";
                    validade = false;
                }

                if (resp[2])
                {
                    txtDescCert.CssClass = "";
                }
                else
                {
                    txtDescCert.CssClass = "erro";
                    validade = false;
                }

                if (validade)
                {

                    if (meuCurriculum == null)
                    {
                        meuCurriculum = new Models.Curriculum();
                        meuCurriculum.ObjCertificacao = new List<Certificacao>();
                    }

                    meuCurriculum.ObjCertificacao.Add(cert);
                    curriculumBLL.EditarCurriculum(idUsu, meuCurriculum);
                    phCertificados.Controls.Clear();
                    MontarCertificados(meuCurriculum.ObjCertificacao);
                }
            }
        }

        protected void btnCadCurso_Click(object sender, EventArgs e)
        {
            #region === Criação Objetos ===
            bool validade = true;

            if (meuCurriculum == null)
            {
                meuCurriculum = new Models.Curriculum();
                meuCurriculum.ObjCursos = new List<Cursos>();
            }

            Cursos objCurso = new Cursos();
            #endregion
            #region === Validação ===
            try
            {
                objCurso.DataFim = Convert.ToDateTime(txtDataTermino.Text.Trim());
                txtDataTermino.CssClass = "";
            }
            catch
            {
                txtDataTermino.CssClass = "erro";
                validade = false;
            }

            try
            {
                objCurso.DataInicio = Convert.ToDateTime(txtDataInicio.Text.Trim());
                txtDataInicio.CssClass = "campos";
            }
            catch
            {
                txtDataInicio.CssClass = "";
                validade = false;
            }

            if (!string.IsNullOrEmpty(txtNomeCurso.Text.Trim()))
            {
                txtNomeCurso.CssClass = "";
            }
            else
            {
                txtNomeCurso.CssClass = "erro";
                validade = false;
            }

            if (!string.IsNullOrEmpty(txtNomeInstiruicao.Text.Trim()))
            {
                txtNomeInstiruicao.CssClass = "";
            }
            else
            {
                txtNomeInstiruicao.CssClass = "erro";
                validade = false;
            }
            #endregion
            #region === Salvar Curso ===
            if (validade)
            {
                objCurso.Nome = txtNomeCurso.Text.Trim();
                objCurso.NomeInstituicao = txtNomeInstiruicao.Text.Trim();
                meuCurriculum.ObjCursos.Add(objCurso);

                curriculumBLL = new ClsCurriculumBLL();
                curriculumBLL.EditarCurriculum(idUsu, meuCurriculum);

                txtNomeCurso.Text = string.Empty;
                txtDataInicio.Text = string.Empty;
                txtDataTermino.Text = string.Empty;
                txtNomeInstiruicao.Text = string.Empty;
                phCursos.Controls.Clear();
                MontarCursos(meuCurriculum.ObjCursos);
            }
            #endregion
        }

        protected void btnCadIdioma_Click(object sender, EventArgs e)
        {
            bool validade = false;

            if (!string.IsNullOrEmpty(txtNomeIdioma.Text))
            {
                validade = true;
                txtNomeIdioma.CssClass = "";
            }
            else
            {
                txtNomeIdioma.CssClass = "erro";
                txtNomeIdioma.Focus();
            }

            if (validade)
            {

                if (meuCurriculum == null)
                {
                    meuCurriculum = new Models.Curriculum();
                    meuCurriculum.ObjIdiomas = new List<Idiomas>();
                }

                Idiomas objIdioma = new Idiomas();
                objIdioma.Nome = txtNomeIdioma.Text.Trim();

                switch (ddlFluencia.SelectedValue)
                {
                    case "Iniciante":
                        objIdioma.Fluencia = FluenciaIdioma.Iniciante;
                        break;

                    case "Intermerdiario":
                        objIdioma.Fluencia = FluenciaIdioma.Intermerdiario;
                        break;

                    case "Avancado":
                        objIdioma.Fluencia = FluenciaIdioma.Avancado;
                        break;

                    case "Fluente":
                        objIdioma.Fluencia = FluenciaIdioma.Fluente;
                        break;

                    case "Nativo":
                        objIdioma.Fluencia = FluenciaIdioma.Nativo;
                        break;
                }

                meuCurriculum.ObjIdiomas.Add(objIdioma);

                curriculumBLL = new ClsCurriculumBLL();
                curriculumBLL.EditarCurriculum(idUsu, meuCurriculum);

                phIdiomas.Controls.Clear();
                MontarIdiomas(meuCurriculum.ObjIdiomas);

                txtNomeIdioma.CssClass = "";
                txtNomeIdioma.Focus();
            }
        }

        protected void btnCadPremio_Click(object sender, EventArgs e)
        {
            Premios pre = new Premios();
            DateTime? data;
            DateTime data2;

            if (DateTime.TryParse(txtDataPre.Text.Trim(), out data2))
            {
                data = data2;
                pre.Data = data.Value;
                txtDataPre.CssClass = "";
            }
            else
            {
                data = null;
                txtDataPre.Focus();
                txtDataPre.CssClass = "erro";
            }

            if (data != null)
            {
                bool validade = true;
                curriculumBLL = new ClsCurriculumBLL();

                pre.Nome = txtNomePremio.Text.Trim();
                pre.Descricao = txtDescPre.Text.Trim();
                pre.Instituicao = txtNomeInstPre.Text.Trim();
                var resp = curriculumBLL.ValidarInfoPremios(pre);
                
                if (resp[0])
                {
                    txtNomeInstPre.CssClass = "";
                }
                else
                {
                    txtNomeInstPre.CssClass = "erro";
                    validade = false;
                }

                if (resp[1])
                {
                    txtNomePremio.CssClass = "";
                }
                else
                {
                    txtNomePremio.CssClass = "erro";
                    validade = false;
                }

                if (resp[2])
                {
                    txtDescPre.CssClass = "";
                }
                else
                {
                    txtDescPre.CssClass = "erro";
                    validade = false;
                }

                if(validade)
                {
                    if (meuCurriculum == null)
                    {
                        meuCurriculum = new Models.Curriculum();
                        meuCurriculum.ObjPremios = new List<Premios>();
                    }

                    meuCurriculum.ObjPremios.Add(pre);
                    curriculumBLL.EditarCurriculum(idUsu, meuCurriculum);
                    phPremios.Controls.Clear();
                    MontarPremios(meuCurriculum.ObjPremios);
                }
            }
        }

        protected void rbSim_CheckedChanged(object sender, EventArgs e)
        {
            txtDataFimExp.Enabled = true;
        }

        protected void rbNao_CheckedChanged(object sender, EventArgs e)
        {
            txtDataFimExp.Enabled = false;
            txtDataFimExp.Text = string.Empty;
        }

        protected void btnCadExperiencia_Click(object sender, EventArgs e)
        {
            bool validade = false;
            Experiencia objExp = new Experiencia();

            #region === Validações ===
            if (!string.IsNullOrEmpty(txtNomeEmpresa.Text))
            {
                objExp.NomeLocal = txtNomeEmpresa.Text.Trim();
                txtNomeEmpresa.CssClass = "";
                validade = true;
            }
            else
            {
                txtNomeEmpresa.CssClass = "erro";
                validade = false;
            }

            if (!string.IsNullOrEmpty(txtAtividadesExp.Text))
            {
                objExp.DescricaoAtividades = txtAtividadesExp.Text.Trim();
                txtAtividadesExp.CssClass = "";
                validade = true;
            }
            else
            {
                txtAtividadesExp.CssClass = "erro";
                validade = false;
            }

            try
            {
                objExp.DataInicio = Convert.ToDateTime(txtDataInicioExp.Text);
                txtDataInicioExp.CssClass = "";
                validade = true;
            }
            catch
            {
                txtDataInicioExp.CssClass = "erro";
                validade = false;
            }

            objExp.Atual = rbSim.Checked;

            if (!objExp.Atual)
            {
                try
                {
                    objExp.DataFim = Convert.ToDateTime(txtDataFimExp.Text);
                    txtDataFimExp.CssClass = "";
                    validade = true;
                }
                catch
                {
                    txtDataFimExp.CssClass = "erro";
                    validade = true;
                }
            }
            #endregion
            #region === Cadastro de Experiência ===
            if (validade)
            {
                if (meuCurriculum == null)
                {
                    meuCurriculum = new Models.Curriculum();
                    meuCurriculum.ObjExperiencia = new List<Experiencia>();
                }

                curriculumBLL = new ClsCurriculumBLL();
                meuCurriculum.ObjExperiencia.Add(objExp);
                curriculumBLL.EditarCurriculum(idUsu, meuCurriculum);

                phExperiencias.Controls.Clear();
                MontarExperiencias(meuCurriculum.ObjExperiencia);
            }
            #endregion
        }
        #endregion
        #region === Web Methods ===
        [System.Web.Services.WebMethod]
        public static string ExcluirCurso(string id, int index)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a exclusão.");

                if (index < 0)
                    throw new Exception("Selecione um curso para realizar a exclusão.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);
                curriculo.ObjCursos.Remove(curriculo.ObjCursos[index]);
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Curso excluido com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }

        [System.Web.Services.WebMethod]
        public static string ExcluirIdioma(string id, int index)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a exclusão.");

                if (index < 0)
                    throw new Exception("Selecione um idioma para realizar a exclusão.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);
                curriculo.ObjIdiomas.Remove(curriculo.ObjIdiomas[index]);
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Idioma excluido com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }

        [System.Web.Services.WebMethod]
        public static string ExcluirPremio(string id, int index)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a exclusão.");

                if (index < 0)
                    throw new Exception("Selecione um prêmio para realizar a exclusão.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);
                curriculo.ObjPremios.Remove(curriculo.ObjPremios[index]);
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Prêmio excluido com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }
        
        [System.Web.Services.WebMethod]
        public static string ExcluirExperiencia(string id, int index)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a exclusão.");

                if (index < 0)
                    throw new Exception("Selecione uma experiência para realizar a exclusão.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);
                curriculo.ObjExperiencia.Remove(curriculo.ObjExperiencia[index]);
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Experi6encia excluida com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }

        [System.Web.Services.WebMethod]
        public static string ExcluirCertificado(string id, int index)
        {
            string retorno = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(id))
                    throw new Exception("Selecione um usuário para realizar a exclusão.");

                if (index < 0)
                    throw new Exception("Selecione um certificado para realizar a exclusão.");

                Oid idUsuario = new Oid(id);
                ClsCurriculumBLL curriculumBLL = new ClsCurriculumBLL();
                var curriculo = curriculumBLL.BuscarCurriculum(idUsuario);
                curriculo.ObjCertificacao.Remove(curriculo.ObjCertificacao[index]);
                curriculumBLL.EditarCurriculum(idUsuario, curriculo);
                retorno = "Certificado excluido com sucesso.";
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }
        #endregion
        #region === Montar Página ===
        private void MontarCertificados(List<Certificacao> ltCertificados)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");

            if (ltCertificados.Count > 0)
            {
                int index = 0;

                foreach (var cert in ltCertificados)
                {

                    div.InnerHtml += string.Format("<div class='listar'>");
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += "<font class='icone3'>I</font>";
                    div.InnerHtml += string.Format("<font class='nome'>{0} - {1}</font>", cert.Nome, cert.Instituicao);
                    div.InnerHtml += "<br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'><b>Data de Expedição:</b>{0}<br />", cert.Data.ToString("dd/MM/yyyy"));
                    div.InnerHtml += string.Format("<b>Descrição:</b>{0}</p>", cert.Descricao);
                    div.InnerHtml += string.Format("<p class='botoes'><a href='EditarCertificado.aspx?index={0}' class='button edit' index='{0}' name='editarCert'>Editar</a>", index);
                    div.InnerHtml += string.Format("<a href='#' class='button delete' index='{0}' name='excluirCert'>Excluir</a></p>", index);
                    div.InnerHtml += "</article></div>";
                    index++;
                }
            }
            else
            {
                div.InnerHtml += "<h3>Você não possui certificados cadastrados. Edite seu currículum para adicionar novos certificados.</h3>";
            }

            phCertificados.Controls.Add(div);
        }

        private void MontarExperiencias(List<Experiencia> ltExperiencias)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");

            if (ltExperiencias.Count > 0)
            {
                int index = 0;
                string duracao = string.Empty;

                foreach (var experiencia in ltExperiencias)
                {
                    if (experiencia.Atual)
                        duracao = experiencia.DataInicio.ToString("dd/MM/yyyy") + " até data atual";
                    else
                        duracao = experiencia.DataInicio.ToString("dd/MM/yyyy") + " até " + experiencia.DataFim.ToString("dd/MM/yyyy");

                    div.InnerHtml += string.Format("<div class='listar'>");
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += "<font class='icone2'>a</font>";
                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", experiencia.NomeLocal);
                    div.InnerHtml += "<br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'><b>Duração:</b>{0}<br />", duracao);
                    div.InnerHtml += string.Format("<b>Atividades Realizadas:</b>{0}</p>", experiencia.DescricaoAtividades);
                    div.InnerHtml += string.Format("<p class='botoes'><a href='EditarExperiencia.aspx?index={0}' class='button edit' index='{0}' name='editarExp'>Editar</a>", index);
                    div.InnerHtml += string.Format("<a href='#' class='button delete' index='{0}' name='excluirExp'>Excluir</a></p>", index);
                    div.InnerHtml += "</article></div>";
                    index++;
                }
            }
            else
            {
                div.InnerHtml += "<h3>Você não possui experiências cadastradas.</h3>";
            }

            phExperiencias.Controls.Add(div);
            upExperiencias.Update();
        }

        private void MontarIdiomas(List<Idiomas> ltIdiomas)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");

            if (ltIdiomas.Count > 0)
            {
                int index = 0;

                foreach (var idioma in ltIdiomas)
                {
                    div.InnerHtml += string.Format("<div class='listar'>");
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += "<font class='icone3'>7</font>";
                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", idioma.Nome);
                    div.InnerHtml += "<br /><br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'><b>Nível de Fluência:</b>{0}</p>", idioma.Fluencia.ToString());
                    div.InnerHtml += string.Format("<p class='botoes'><a href='EditarIdioma.aspx?index={0}' class='button edit' index='{0}' name='editarIdi'>Editar</a>", index);
                    div.InnerHtml += string.Format("<a href='#' class='button delete' index='{0}' name='excluirIdi'>Excluir</a></p>", index);
                    div.InnerHtml += "</article></div>";
                    index++;
                }
            }
            else
            {
                div.InnerHtml += "<h3>Você não possui idiomas cadastrados.</h3>";
            }

            phIdiomas.Controls.Add(div);
            upMostrarIdioma.Update();
        }

        private void MontarPremios(List<Premios> ltPremios)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");

            if (ltPremios.Count > 0)
            {
                int index = 0;

                foreach (var premio in ltPremios)
                {
                    div.InnerHtml += string.Format("<div class='listar'>");
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += "<font class='icone2'>)</font>";
                    div.InnerHtml += string.Format("<font class='nome'>{0} - {1}</font>", premio.Nome, premio.Instituicao);
                    div.InnerHtml += "<br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'><b>Data de Expedição:</b>{0}<br />", premio.Data.ToString("dd/MM/yyyy"));
                    div.InnerHtml += string.Format("<b>Descrição:</b>{0}</p>", premio.Descricao);
                    div.InnerHtml += string.Format("<p class='botoes'><a href='EditarPremio.aspx?index={0}' class='button edit' index='{0}' name='editarPre'>Editar</a>", index);
                    div.InnerHtml += string.Format("<a href='#' class='button delete' index='{0}' name='excluirPre'>Excluir</a></p>", index);
                    div.InnerHtml += "</article></div>";
                    index++;
                }
            }
            else
            {
                div.InnerHtml += "<h3>Você não possui prêmios cadastrados.</h3>";
            }

            phPremios.Controls.Add(div);
            upPremios.Update();
        }

        private void MontarCursos(List<Cursos> ltCursos)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");

            if (ltCursos.Count > 0)
            {
                int index = 0;

                foreach (var curso in ltCursos)
                {
                    div.InnerHtml += string.Format("<div class='listar'>");
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += "<font class='icone2'>S</font>";
                    div.InnerHtml += string.Format("<font class='nome'>{0} - {1}</font>", curso.Nome, curso.NomeInstituicao);
                    div.InnerHtml += "<br /><br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'>De {0} até {1}</p>", curso.DataInicio.ToString("dd/MM/yyyy"), curso.DataFim.ToString("dd/MM/yyyy"));
                    div.InnerHtml += string.Format("<p class='botoes'><a href='EditarCurso.aspx?index={0}' class='button edit' index='{0}' name='editarCur'>Editar</a>", index);
                    div.InnerHtml += string.Format("<a href='#' class='button delete' index='{0}' name='excluirCur'>Excluir</a></p>", index);
                    div.InnerHtml += "</article></div>";
                    index++;
                }
            }
            else
            {
                div.InnerHtml += "<h3>Você não possui cursos cadastrados.</h3>";
            }

            phCursos.Controls.Add(div);
            upMostrarCursos.Update();
        }

        private void MontarTelaNull()
        {
            HtmlGenericControl divCursos = new HtmlGenericControl("div");
            divCursos.Attributes.Add("id", "cursos");

            HtmlGenericControl divIdiomas = new HtmlGenericControl("div");
            divIdiomas.Attributes.Add("id", "cursos");

            HtmlGenericControl divExperincias = new HtmlGenericControl("div");
            divExperincias.Attributes.Add("id", "cursos");

            HtmlGenericControl divCertificados = new HtmlGenericControl("div");
            divCertificados.Attributes.Add("id", "cursos");

            HtmlGenericControl divPremios = new HtmlGenericControl("div");
            divPremios.Attributes.Add("id", "cursos");

            divCursos.InnerHtml += "<h3>Você não possui cursos cadastrados. Edite seu currículum para adicionar novos cursos.</h3>";
            divPremios.InnerHtml += "<h3>Você não possui prêmios cadastrados. Edite seu currículum para adicionar novos prêmios.</h3>";
            divIdiomas.InnerHtml += "<h3>Você não possui idiomas cadastrados. Edite seu currículum para adicionar novos idiomas.</h3>";
            divExperincias.InnerHtml += "<h3>Você não possui experiências cadastradas. Edite seu currículum para adicionar novas experiências.</h3>";
            divCertificados.InnerHtml += "<h3>Você não possui certificados cadastrados. Edite seu currículum para adicionar novos certificados.</h3>";

            phCertificados.Controls.Add(divCertificados);
            phExperiencias.Controls.Add(divExperincias);
            phIdiomas.Controls.Add(divIdiomas);
            phPremios.Controls.Add(divPremios);
            phCursos.Controls.Add(divCursos);
        }
        #endregion

    }
}