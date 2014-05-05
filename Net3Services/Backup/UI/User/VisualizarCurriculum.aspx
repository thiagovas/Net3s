<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="VisualizarCurriculum.aspx.cs" Inherits="UI.User.VisualizarCurriculum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Visualizar.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="visualizacao">
        <div id="principal">
            <h1>Currículo</h1>
            <p><a href="#" id="btnEditarCurriculum" class="button edit" runat="server">Editar Currículo</a></p>
        </div>
        <br /><br /><br />
        <asp:PlaceHolder ID="phDados" runat="server"></asp:PlaceHolder>    
    </div>
</asp:Content>
