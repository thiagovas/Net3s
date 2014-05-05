using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using ClsLibBLL;

namespace UIAdmin
{
    public partial class CadastroAdm : System.Web.UI.Page
    {
        ClsAdministradorBLL admBll = new ClsAdministradorBLL();
        Administrador adm = new Administrador();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnConfirma_Click(object sender, EventArgs e)
        {
            string[] campos = new string[4];

            try
            {
                //limpa as messagens
                LimpaCampos();

                if (VerificaDisponibilidade())
                {
                    //setar os valores dos campos
                    campos = null;

                    //Envia para o modelo todos os dados, ondem iram ser validados
                    adm.nome = this.TxtNome.Text;
                    adm.pais = this.TxtPais.Text;
                    adm.UF = this.TxtUF.Text;
                    adm.cidade = this.TxtCIdade.Text;
                    adm.login = this.TxtLogin.Text;
                    adm.senha = this.TxtSenha.Text;
                    adm.cSenha = this.TxtConfSenha.Text;
                    adm.dataCadastro = DateTime.Now;
                    adm.situacao = 0;

                    campos = admBll.InserirAdministrador(adm);
                }
                else this.ELogin.Text = "Este email já esta sendo utilizado, por favor escolha outro!";
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
            finally 
            {
                if (campos == null) RedirecionaPagina();
                else MudarCoresErrados(campos);
            }
        }

        /// <summary>
        /// Limpa todos os campos do formulario
        /// </summary>
        private void LimpaCampos()
        {
            this.ENome.Text = string.Empty;
            this.ELogin.Text = string.Empty;
            this.ESenha.Text = string.Empty;
            this.ECSenha.Text = string.Empty;
        }

        /// <summary>
        /// Verifica se aquele email pode ser utilizado
        /// </summary>
        /// <returns>true(pode), false(não pode)</returns>
        private bool VerificaDisponibilidade()
        {
            return admBll.VerificaDisponibilidade(this.TxtLogin.Text).Count > 0 ? false : true;
        }

        private void RedirecionaPagina()
        {
            Response.Redirect("Perfil.aspx");
        }

        /// <summary>
        /// Muda as cores dos valores que estão errados
        /// </summary>
        public void MudarCoresErrados(string[] campos)
        {
            #region MudaCoresErrados

            if (campos[0] != null)
            {
                this.TxtNome.BorderColor = System.Drawing.Color.Red;
                this.ENome.Text = campos[0];
            }

            if (campos[1] != null)
            {
                this.TxtLogin.BorderColor = System.Drawing.Color.Red;
                this.ELogin.Text = campos[1];
            }

            if (campos[2] != null)
            {
                this.TxtSenha.BorderColor = System.Drawing.Color.Red;
                this.ESenha.Text = campos[2];
            }

            if (campos[3] != null)
            {
                this.TxtConfSenha.BorderColor = System.Drawing.Color.Red;
                this.ECSenha.Text = campos[3];
            }

            #endregion
        }
    }
}