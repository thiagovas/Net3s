<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="ServicosAbertos.aspx.cs" Inherits="UI.User.ServicosAbertos" %>
<%@ Register TagPrefix="n3s" TagName="ServAbertos" Src="../Componentes/ServicosAberto.ascx"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Atualizacoes.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <n3s:ServAbertos runat="server" ID="VServicosAberto" />
</asp:Content>
