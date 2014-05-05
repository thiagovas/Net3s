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
    public partial class ConfigEndereco : System.Web.UI.Page
    {
        ClsCatalogoEnderecosBLL catalogoBLL;
        protected string idUsu { get; set; }
        protected string cep { get; set; }
        protected string bairro { get; set; }
        protected string rua { get; set; }
        protected string numero { get; set; }
        protected string comple { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                idUsu = ((Usuario)Session["USUARIO"])._id.ToString();

                if (((Usuario)Session["USUARIO"]).enderecosUsuario.Count > 0)
                {
                    var endereco = ((Usuario)Session["USUARIO"]).enderecosUsuario[0];
                    numero = endereco.numero.ToString();
                    comple = endereco.complemento;
                    rua = endereco.logradouro;
                    bairro = endereco.bairro;
                    cep = endereco.cep;
                    
                    LoadComEndereco(endereco);
                }
                else
                {
                    LoadSemEndereco();
                }
            }
        }

        private void LoadComEndereco(Endereco end)
        {
            catalogoBLL = new ClsCatalogoEnderecosBLL();
            var catalogo = catalogoBLL.BuscarTodosEnderecos();

            List<Pais> ltPaises = new List<Pais>();
            foreach (var item in catalogo)
            {
                ltPaises.Add(item.pais);
            }

            ddlPais.DataSource = ltPaises;
            ddlPais.DataTextField = "nomePais";
            ddlPais.DataBind();

            ddlEstado.DataSource = catalogo[0].pais.estados;
            ddlEstado.DataTextField = "nomeEstado";
            ddlEstado.DataBind();
            ddlEstado.Text = end.uf;

            var cidades = catalogoBLL.BuscarCidadesPorUf(end.uf);
            ddlCidade.DataSource = cidades;
            ddlCidade.DataTextField = "";
            ddlCidade.DataBind();
            ddlCidade.Text = end.cidade;
        }

        private void LoadSemEndereco()
        {
            catalogoBLL = new ClsCatalogoEnderecosBLL();
            var catalogo = catalogoBLL.BuscarTodosEnderecos();
            
            List<Pais> ltPaises = new List<Pais>();
            foreach (var item in catalogo)
            {
                ltPaises.Add(item.pais);   
            }

            ddlPais.DataSource = ltPaises;
            ddlPais.DataTextField = "nomePais";
            ddlPais.DataBind();

            ddlEstado.DataSource = catalogo[0].pais.estados;
            ddlEstado.DataTextField = "nomeEstado";
            ddlEstado.DataBind();

            ddlCidade.DataSource = catalogo[0].pais.estados[0].cidades;
            ddlCidade.DataTextField = "nomeCidade";
            ddlCidade.DataBind();
        }

        protected void dllEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            catalogoBLL = new ClsCatalogoEnderecosBLL();
            string estado = ddlEstado.Text;
            var cidades = catalogoBLL.BuscarCidadesPorUf(estado);
            ddlCidade.DataSource = cidades;
            ddlCidade.DataTextField = "";
            ddlCidade.DataBind();
        }

        protected void atualizaSessao_Click(object sender, EventArgs e)
        {
            Oid id = ((Usuario)Session["USUARIO"])._id;

            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            var usu = usuarioBLL.BuscarUsuarioPorID(id);
            Session["USUARIO"] = usu; 
        }

        [System.Web.Services.WebMethod]
        public static string EditarEndereco(string id, string cep, string bairro, string rua, string numero, string comple, string pais, string estado, string cidade)
        {
            string retorno = string.Empty;
            
            try
            {
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                var usu = usuarioBLL.BuscarUsuarioPorID(new Oid(id));

                if (usu.enderecosUsuario.Count > 0)
                {
                    usu.enderecosUsuario[0].complemento = comple;
                    usu.enderecosUsuario[0].logradouro = rua;
                    usu.enderecosUsuario[0].bairro = bairro;
                    usu.enderecosUsuario[0].cidade = cidade;
                    usu.enderecosUsuario[0].numero = Convert.ToInt32(numero);
                    usu.enderecosUsuario[0].pais = pais;
                    usu.enderecosUsuario[0].uf = estado;
                    usu.enderecosUsuario[0].cep = cep;
                }
                else
                {
                    Endereco end = new Endereco();
                    end.complemento = comple;
                    end.logradouro = rua;
                    end.bairro = bairro;
                    end.cidade = cidade;
                    end.numero = Convert.ToInt32(numero);
                    end.pais = pais;
                    end.uf = estado; 
                    end.cep = cep;

                    usu.enderecosUsuario.Add(end);
                }

                var resposta = usuarioBLL.ValidarConfigEnrereco(usu);
                string erro = string.Empty;

                foreach (var item in resposta)
                {
                    if (item != "ok")
                        erro += item + "\n";
                }

                if (string.IsNullOrEmpty(erro))
                {
                    usuarioBLL.EditarUsuario(usu);
                    retorno = "Seu perfil foi atualizado com sucesso.";

                    numero = usu.enderecosUsuario[0].numero.ToString();
                    comple = usu.enderecosUsuario[0].complemento;
                    rua = usu.enderecosUsuario[0].logradouro;
                    bairro = usu.enderecosUsuario[0].bairro;
                    cep = usu.enderecosUsuario[0].cep;
                }
                else
                {
                    retorno = erro;
                }
            }
            catch(Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }
    }
}