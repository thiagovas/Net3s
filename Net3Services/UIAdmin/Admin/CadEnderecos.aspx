<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Perfil.Master" AutoEventWireup="true" CodeBehind="CadEnderecos.aspx.cs" Inherits="UIAdmin.Admin.CadEnderecos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conteudo">
    <br />
    Cadastrar Endereço
    <hr /><br />
    <label class="label">Seleicone o XML de endereços:</label>
    <input type="file" id="fileUpXml" name="fileUpXml" runat="server" />
    <br />
    <asp:LinkButton ID="lbUpload" runat="server" CssClass="botoesN3s" onclick="lbUpload_Click"><span>Upload</span></asp:LinkButton>
    </div>
</asp:Content>
