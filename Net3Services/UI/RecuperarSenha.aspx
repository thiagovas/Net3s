<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarSenha.aspx.cs" Inherits="UI.RecuperarSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Net3s - Recuperar senha</title>
    <link href="../Styles/Default.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Josefin+Slab:400,700' rel='stylesheet' type='text/css'> 
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="st-container">
            <input type="radio" name="radio-set" checked="checked" id="st-control-1" />
            <a href="#st-panel-1">Recuperar senha</a>
            <div class="st-scroll">
                <section class="st-panel" id="st-panel-1">
				    <div class="st-deco" data-icon="7"></div>
  					<a href="Default.aspx"><img src="Styles/img/logo.png" alt="Net3s" id="logo" /></a>
  					<div id="RecSenha">
                        <h2><asp:Label ID="lblTituloMsg" runat="server" Text="Label"></asp:Label></h2>
                        <label>Login ou E-mail: </label>
                        <asp:TextBox ID="txtEmailLogin" runat="server" placeHolder="Login ou E-mail" TabIndex="0"></asp:TextBox>
                        <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" CssClass="button" 
                                            TabIndex="1" onclick="btnRecuperar_Click"/>
                        <br />
                        <a href="Default.aspx" class="nbutton"><i class="icon-home"></i>Voltar ao Login</a>
                    </div>
                    <div id="rodape">
                        Net3 Services © 2011&nbsp;&nbsp;|&nbsp;&nbsp;
                        <a href="#" TabIndex="6">Sobre</a> · <a href="#" TabIndex="7">Anúnciar</a> · <a href="#" TabIndex="8">Desenvolvedores</a> · 
                        <a href="http://net3services.wordpress.com/" target="new" TabIndex="9">Blog</a> · <a href="#" TabIndex="10">Termos de Uso</a> · 
                        <a href="http://twitter.com/net3s" target="new" TabIndex="11">Twitter</a> · <a href="http://www.facebook.com/net3s" target="new" TabIndex="12">Facebook</a>
                    </div>
                </section>
            </div> <!-- // st-scroll -->
        </div>
    </div>
    </form>
</body>
</html>
