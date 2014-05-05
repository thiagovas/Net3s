<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="Network.aspx.cs" Inherits="UI.User.Network" %>
<%@ Register TagPrefix="n3s" TagName="visuNetwork" Src="~/Componentes/VisualizarNetwork.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/VisualizarNetwork.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <n3s:visuNetwork runat="server" ID="networkComp" />
</asp:Content>


