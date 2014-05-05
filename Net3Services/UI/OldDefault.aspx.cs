using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica;
using ClsLibBLL;
using Models;

namespace UI
{
    public partial class Default : System.Web.UI.Page
    {
        ClsUsuarioBLL objUsu = new ClsUsuarioBLL();
        Usuario mUsu = new Usuario();
        ClsServicoBLL servBLL;

        #region === Métodos ===
        /// <summary>
        /// Monta o HTML da lsita de serviços informada
        /// </summary>
        /// <param name="ltServ">Lista de serviços da qual deve ser montada o HTML</param>
        /// <param name="msgErro">Mensagem de erro que deve ser exibida caso a lista esteja vazia</param>
        protected void Buscar(List<Servico> ltServ, string msgErro)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "pesquisa");

            if (ltServ.Count > 0)
            {
                int numPags = 1;
                string caminhoImagem = string.Empty;

                for (int i = 0; i < ltServ.Count; i++)
                {
                    if (i % 5 == 0 || i == 0)
                    {
                        if (i > 0)
                        {
                            div.InnerHtml += "</div>";
                            numPags++;
                        }

                        string style = numPags == 1 ? "" : "display:none;";
                        string cssClass = numPags == 1 ? "class='_current'" : "";
                        div.InnerHtml += string.Format("<div id='p{0}' {1} style='{2}'>", numPags, cssClass, style);
                    }

                    caminhoImagem = ClsServicoBLL.BuscarImagemCategoria(ltServ[i].nomeCategoriaServico);

                    div.InnerHtml += "<div class='servico'>";
                    div.InnerHtml += string.Format("<img src='{0}' alt='{1}' class='imgServ' />", caminhoImagem, ltServ[i].nomeCategoriaServico);
                    div.InnerHtml += string.Format("<label class='nomeServ'>{0}</label>", ltServ[i].nome);
                    div.InnerHtml += string.Format("<p class='descricao'>{0}</p>", ltServ[i].descricao);
                    div.InnerHtml += string.Format("<div class='divBotao'><label><span>R$</span>{0}</label><a href='#' class='btnContratar'>Contratar</a></div>", ltServ[i].preco.ToString("0.00"));
                    div.InnerHtml += "</div>";
                }
                
                div.InnerHtml += "</div>";

                if (numPags > 1)
                {
                    div.InnerHtml += "<br /><div id='numPag'></div>";
                    hidNumPags.Value = numPags.ToString();
                }
            }
            else
            {
                hidNumPags.Value = "0";
                div.InnerHtml = "<h4>" + msgErro + "</h4>";
            }

            phPesquisa.Controls.Clear();
            phPesquisa.Controls.Add(div);
        }

        /// <summary>
        /// Executa a busca dos serviços a partir da categoria informada
        /// </summary>
        /// <param name="categoria">Nome da categoria pela qual os serviços devem ser localizados</param>
        /// <by>Breno Pires - breno_spires@hotmaial.com</by>
        protected void BuscarServByCategoria(string categoria)
        {
            lblTitulo.Text = categoria;
            servBLL = new ClsServicoBLL();
            var dados = servBLL.BuscarServicosPorCategoria(categoria);
            string msgErro = "Não foram encontrados serviços cadastrados na categoria '" + categoria + "'.";
            Buscar(dados, msgErro);
        }
        #endregion
        #region === Eventos ===
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Cookies["Net3User"] != null && Request.Cookies["Net3UserPwd"] != null)
                {
                    chkLembrar.Checked = true;
                    txtLogin.Text = Request.Cookies["Net3User"].Value;

                    txtSenha.Attributes.Add("value", Request.Cookies["Net3UserPwd"].Value);
                }

                servBLL = new ClsServicoBLL();
                var dados = servBLL.BuscarUltimosServicosInseridos(30);
                Buscar(dados, "Não foi localizado nenhum serviço com o filtro de busca informado.");
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            MD5 hash = new MD5();

            //iguala os campos ás propriedades usando a rotina criada
            mUsu.login = txtLogin.Text.Trim();
            mUsu.email = txtLogin.Text.Trim();
            mUsu.senha = hash.criptografar(txtSenha.Text.Trim());

            bool remember = chkLembrar.Checked;

            try
            {
                if (objUsu.Logar(ref mUsu))
                {
                    //Instancia localmente um objeto enum de status, ja que será usado apenas aqui
                    Status status = new Status();

                    //Pega o valor do id do usuario e iguala a variável id
                    //Não entendi o sentido disso mas comentei aqui.
                    //Thiago Vieira
                    //string id = objUsu.GetObjectUsuario(mUsu)._id.ToString();
                    string id = mUsu._id.ToString();

                    switch (status)
                    {
                        case Status.Ativado:
                            #region === Preenche as propriedades de ClsUsuLogado ===
                            ClsUsuLogado.IdUsuario = mUsu._id;
                            ClsUsuLogado.Login = mUsu.login;
                            ClsUsuLogado.CpfCnpj = mUsu.cpf_cnpj;
                            ClsUsuLogado.Rg = mUsu.rg;
                            ClsUsuLogado.Pais = mUsu.enderecosUsuario.Count > 0 ? mUsu.enderecosUsuario[0].pais : null;
                            ClsUsuLogado.Uf = mUsu.enderecosUsuario.Count > 0 ? mUsu.enderecosUsuario[0].uf : null;
                            ClsUsuLogado.Cidade = mUsu.enderecosUsuario.Count > 0 ? mUsu.enderecosUsuario[0].cidade : null;
                            #endregion

                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, mUsu.login, DateTime.Now, DateTime.Now.AddMinutes(20), remember, Session.SessionID, FormsAuthentication.FormsCookiePath);
                            string encryptTicket = FormsAuthentication.Encrypt(authTicket);
                            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);

                            Response.Cookies.Add(authCookie);
                            Session.Add("USUARIO", mUsu);
                            FormsAuthentication.RedirectFromLoginPage(mUsu.login, remember);

                            if (Response.Cookies["Net3User"].Value != txtLogin.Text.Trim())
                            {
                                Response.Cookies["Net3User"].Expires = DateTime.Now.AddMonths(-1);
                                Response.Cookies["Net3UserPwd"].Expires = DateTime.Now.AddMonths(-1);
                            }

                            Response.Redirect(string.Format("/User/Perfil.aspx?id={0}", id));
                            break;
                        case Status.Banido:
                            throw new Exception("Sua conta foi excluída por infração dos termos de uso. Entre em contato com o Administrador.");
                        case Status.Desativado:
                            throw new Exception("Sua conta foi suspensa ou ainda não está ativada, entre em contato com o administrador.");
                    }
                }
                else
                {
                    throw new Exception("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string script = string.Format("alert('Erro ao logar - {0}');", ex.Message);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "exists", script, true);
            }
        }

        protected void chkLembrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLembrar.Checked)
            {
                Response.Cookies["Net3User"].Value = txtLogin.Text.Trim();
                Response.Cookies["Net3UserPwd"].Value = txtSenha.Text.Trim();
                Response.Cookies["Net3User"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["Net3UserPwd"].Expires = DateTime.Now.AddMonths(2);
            }
            else
            {
                Response.Cookies["Net3User"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["Net3UserPwd"].Expires = DateTime.Now.AddMonths(-1);
            }
        }

        protected void lbAdvocacia_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Advocacia");
        }

        protected void lbArtesanato_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Artesanatos e Hobbies");
        }

        protected void lbAutomoveis_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Autmóveis e Veículos");
        }

        protected void lbBeleza_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Beleza e Estetica");
        }

        protected void lbCasaDeco_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Casa e Decoração");
        }

        protected void lbConstrucao_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Construção Civil");
        }

        protected void lbConsultoria_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Consultria");
        }

        protected void lbCultura_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Cultura e Arte");
        }

        protected void lbEducacao_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Educação");
        }

        protected void lbEsporte_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Esporte");
        }

        protected void lbFestas_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Festas e Eventos");
        }

        protected void lbFotografia_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Fotografia");
        }

        protected void lbGastronomia_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Gastronomia");
        }

        protected void lbInformatica_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Informática e Tecnologia");
        }

        protected void lbJardinagem_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Jardinagem");
        }

        protected void lbJogos_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Jogos e Enrtetenimento");
        }

        protected void lbManutencao_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Manutenção Doméstica");
        }

        protected void lbMarketing_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Marketing e Comunicação");
        }

        protected void lbMedicina_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Medicina Alternativa");
        }

        protected void lbModa_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Moda, Roupas e Acessórios");
        }

        protected void lbMusica_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Música");
        }

        protected void lbSaude_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Saúde");
        }

        protected void lbSeguranca_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Segurança");
        }

        protected void lbServGerais_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Serviços Gerais");
        }

        protected void lbTransportes_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Transportes");
        }

        protected void lbTurismo_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Turismo e Lazer");
        }

        protected void lbVeterinaria_Click(object sender, EventArgs e)
        {
            BuscarServByCategoria("Veterinária");
        }
        
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            servBLL = new ClsServicoBLL();
            var dados = servBLL.BuscarServicoPorNome(txtPesquisa.Text.Trim(), false,null);
            Buscar(dados, "Não foi localizado nenhum serviço com o nome informado.");
        }
        #endregion
    }
}