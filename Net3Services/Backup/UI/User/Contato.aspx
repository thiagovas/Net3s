<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="UI.User.Contato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Visualizar.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="visualizacao">
        <div id="principal">
            <h1>Informações de Contatos</h1>
        </div>
        <br /><br />
        <div id="conteudoVisu"> 
            <asp:Label ID="lblTexto" runat="server" Text=""></asp:Label>
            <br /><br />
            <label><font class="iconesDois">@</font>E-mail:</label>
            <a href="mailto:<%= this.pgEmail %>?»&subject=Net3 Services - Contato" target="new" class="link">
                <asp:Label ID="lblEmail" runat="server" Text="" CssClass="valor"></asp:Label>
            </a>
            <br />
            <label><font class="iconesDois">c</font>Telefone(s):</label>
            <asp:Label ID="lblTelefones" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
            <label><font class="iconesDois">N</font>Celular(s):</label>
            <asp:Label ID="lblCelulares" runat="server" Text="" CssClass="valor"></asp:Label>
       </div>
    </div>
</asp:Content>
