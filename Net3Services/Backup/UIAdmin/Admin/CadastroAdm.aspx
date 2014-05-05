<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Perfil.Master" AutoEventWireup="true" CodeBehind="CadastroAdm.aspx.cs" Inherits="UIAdmin.CadastroAdm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="~/Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="~/Scripts/jk1.js"></script>
    <link rel="Stylesheet" type="text/css" href="~/Styles/CadasAdm.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conteudo">
        <br />
        Cadastro de Administradores
        <hr />
        <br />
        <asp:Label runat="server" ID="LblLogin" Width="150px" CssClass="label">Digite o nome: </asp:Label>
        <asp:TextBox runat="server" ID="TxtNome" width="400px" Height="25px"></asp:TextBox>
        <asp:Label runat="server" ID="ENome" CssClass="Error"></asp:Label>
        <br /><br />
        <asp:Label runat="server" ID="Label1" Width="150px" CssClass="label">Digite o país: </asp:Label>
        <asp:TextBox runat="server" ID="TxtPais" width="400px" Height="25px"></asp:TextBox>
        <asp:Label runat="server" ID="EPais" CssClass="Error"></asp:Label>
        <br /><br />
        <asp:Label runat="server" ID="Label2" Width="150px" CssClass="label">Digite o estado: </asp:Label>
        <asp:TextBox runat="server" ID="TxtUF" width="400px" Height="25px"></asp:TextBox>
        <asp:Label runat="server" ID="EEstado" CssClass="Error"></asp:Label>
        <br /><br />
        <asp:Label runat="server" ID="Label3" Width="150px" CssClass="label">Digite a cidade: </asp:Label>
        <asp:TextBox runat="server" ID="TxtCIdade" width="400px" Height="25px"></asp:TextBox>
        <asp:Label runat="server" ID="ECidade" CssClass="Error"></asp:Label>
        <br /><br />
        <asp:Label runat="server" ID="Label4" Width="150px" CssClass="label">Digite o Email(Login): </asp:Label>
        <asp:TextBox runat="server" ID="TxtLogin" width="400px" Height="25px"></asp:TextBox>
        <asp:Label runat="server" ID="ELogin" CssClass="Error"></asp:Label>
        <br /><br />
        <asp:Label runat="server" ID="Label5" Width="150px" CssClass="label">Digite a senha: </asp:Label>
        <asp:TextBox runat="server" TextMode="Password" ID="TxtSenha" width="400px" Height="25px"></asp:TextBox>
        <asp:Label runat="server" ID="ESenha" CssClass="Error"></asp:Label>
        <br /><br />
        <asp:Label runat="server" ID="Label6" Width="150px" CssClass="label">Confirme a senha: </asp:Label>
        <asp:TextBox runat="server" TextMode="Password" ID="TxtConfSenha" width="400px" Height="25px"></asp:TextBox>
        <asp:Label runat="server" ID="ECSenha" CssClass="Error"></asp:Label>
        <br /><br />
        <div class="botao">
            <asp:Button runat="server" ID="BtnConfirma" Text="Confirmar" Width="80px" Height="30px" onclick="BtnConfirma_Click" />
        </div>
    </div>
</asp:Content>
