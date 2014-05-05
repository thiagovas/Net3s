<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Perfil.Master" AutoEventWireup="true" CodeBehind="CategoriasServico.aspx.cs" Inherits="UIAdmin.Admin.CategoriasServico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListBox ID="ListCateg" runat="server"></asp:ListBox> 
    <asp:Button ID="ButExcluir" runat="server" Text="Excluir" 
        onclick="ButExcluir_Click" /> 
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Cadastrar categoria"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Nome da categoria: "></asp:Label>
    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
    <asp:Button ID="ButCadastrar" runat="server" Text="Cadastrar" 
        onclick="ButCadastrar_Click" /> 
</asp:Content>