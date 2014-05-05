<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="Atualizacoes.aspx.cs" Inherits="UI.User.Atualizacoes" %>
<%@ Register TagPrefix="n3s" TagName="atualizacoes" Src="~/Componentes/Atualizacoes.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Atualizacoes.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <n3s:atualizacoes runat="server" ID="contAtualizacoes" />
</asp:Content>
