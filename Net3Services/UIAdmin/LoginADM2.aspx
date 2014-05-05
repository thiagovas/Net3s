<%@ Page Title="Login" Language="C#" MasterPageFile="~/LoginADM.Master" AutoEventWireup="true" CodeBehind="LoginADM2.aspx.cs" Inherits="UIAdmin.LoginADM2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Styles/AdmCss.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tudo">
        <div class="logo">
            <asp:Image ID="Image3" runat="server" Height="100px" ImageUrl="~/Styles/img/logon3s.png" Width="300px" />
        </div>
        <div class="Login">
            <asp:Label ID="lblLogin" runat="server" width="50px" height="22px" Text="Login: " CssClass="textoLbl"></asp:Label>
            <br />
            <asp:TextBox ID="TxtLogin" runat="server" CssClass="textoIn"></asp:TextBox>
            <br />
            <asp:Label ID="LblLogado" CssClass="TextError" runat="server" Text=""></asp:Label>
        </div>
        <div class="Senha">
            <asp:Label ID="LblSenha" runat="server" width="50px" height="22px" Text="Senha: " CssClass="textoLbl"></asp:Label>
            <br />
            <asp:TextBox ID="TxtSenha" runat="server" CssClass="textoIn" TextMode="Password"></asp:TextBox>
        </div>
        <div class="botao">
            <asp:ImageButton ID="BtnEntrar1" runat="server" Height="22px" Width="82px" 
                ImageUrl="~/Styles/img/entrar.png" onclick="BtnEntrar1_Click"></asp:ImageButton>
        </div>
        <div class="sobre">
            "Trabalhando para a sua comodidade..."
        </div>
        <div class="rodape">
            COPYRIGHT (C) 2011 - NET3 SERVICES. TODOS OS DIREITOS RESERVADOS.
        </div>
    </div>
</asp:Content>