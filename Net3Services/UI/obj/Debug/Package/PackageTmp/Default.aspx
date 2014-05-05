<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.NewDefault" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <title>Net3 Services</title>
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <link href="../Styles/Default.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Josefin+Slab:400,700' rel='stylesheet' type='text/css' /> 
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container">
            <div class="st-container">
                <input type="radio" name="radio-set" checked="checked" id="st-control-1" />
                <a href="#st-panel-1">Login</a>
                <input type="radio" name="radio-set" id="st-control-2" />
                <a href="#st-panel-2" >Cadastrar Usuário</a>
                <input type="radio" name="radio-set" id="st-control-3" />
                <a href="#st-panel-3">Localizar Serviços</a>
                <div class="st-scroll">
                    <section class="st-panel" id="st-panel-1">
				        <div class="st-deco" data-icon="L"></div>
  					    <div id="login">
  						    <asp:TextBox ID="txtLogin" runat="server" CssClass="camposTexto" placeholder="Login/Email" TabIndex="1" autofocus></asp:TextBox>
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="camposTexto" TextMode="Password" placeholder="Senha" TabIndex="2"></asp:TextBox>
                            <asp:Button ID="btnLogar" runat="server" Text="ENTRAR" CssClass="button" OnClick="btnLogar_Click" TabIndex="3" />
                            <br />
  						    <asp:CheckBox ID="chkLembrar" runat="server" CssClass="check" OnCheckedChanged="chkLembrar_CheckedChanged" TabIndex="4" />
                            &nbsp;Lembrar-me
  						    <label><a href="RecuperarSenha.aspx" TabIndex="5">Esqueci minha senha</a></label>
  					    </div>
                        <img src="Styles/img/logo.png" alt="" class="logo" />
  					    <br />
                        <img src="Styles/img/GLOBO.png" class="globo" alt="" />
                        <div class="textos">
                            <h2>REVELE SEU TALENTO AO MUNDO</h2>
                            <h4>Os melhores serviços estão aqui. Você está <span>pronto para fechar negócio</span>?</h4>
                        </div>
                        <div class="rodape">
                            Net3 Services © 2011&nbsp;&nbsp;|&nbsp;&nbsp;
                            <a href="#" TabIndex="6">Sobre</a> · <a href="#" TabIndex="7">Anúnciar</a> · <a href="#" TabIndex="8">Desenvolvedores</a> · 
                            <a href="http://net3services.wordpress.com/" target="new" TabIndex="9">Blog</a> · <a href="#" TabIndex="10">Termos de Uso</a> · 
                            <a href="https://twitter.com/net3s" target="new" TabIndex="11">Twitter</a> · <a href="http://www.facebook.com/net3s" target="new" TabIndex="12">Facebook</a>
                        </div>
                    </section>
                    <section class="st-panel st-color" id="st-panel-2">
				        <div class="st-deco" data-icon="K"></div>
					    <img src="Styles/img/logo.png" alt="" id="logo2" />
  					    <h3>Cadastrar Usuário</h3>
                        <asp:UpdatePanel ID="upCadUsuario" runat="server">
                            <ContentTemplate>
                                <div id="cadastro">
                                    <label>Tipo de Usuário:</label>
                                    <div id="tipoUsu">
                                        <label><asp:RadioButton ID="rbPessoaFisica" runat="server" GroupName="tipoUsuario"></asp:RadioButton> Pessoa Física</label>
                                        <label><asp:RadioButton ID="rbPessoaJuridica" runat="server" GroupName="tipoUsuario"></asp:RadioButton> Pessoa Jurídica</label>
                                    </div>
                                    <br /><br />
                                    <label>Nome:</label>
                                    <asp:TextBox ID="txtNomeUsu" runat="server" CssClass="camposCad" placeholder="Nome do usuário" TabIndex="13"></asp:TextBox>
                                    <label>Login:</label>
                                    <asp:TextBox ID="txtLoginUsu" runat="server" CssClass="camposCad" placeholder="Login do usuário" TabIndex="14"></asp:TextBox>
                                    <label>E-mail:</label>
                                    <asp:TextBox ID="txtEmailUsu" runat="server" CssClass="camposCad" placeholder="E-mail do usuário" TabIndex="15"></asp:TextBox>
                                    <div id="btnCad">
                                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="button" 
                                            TabIndex="16" onclick="btnCadastrar_Click"/>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
				    </section>
                    <section class="st-panel" id="st-panel-3">
				        <div class="st-deco" data-icon="u"></div>
					    <p>Adicionar listas de serviços</p>
				    </section>
                </div> <!-- // st-scroll -->
            </div> <!-- // st-container -->
        </div>
    </form>
</body>
</html>
