<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="ServicosOferecidos.aspx.cs" Inherits="UI.User.Servicos" %>
<%@ Register TagPrefix="n3s" TagName="servicosOferecidos" Src="~/Componentes/ListServOferecidos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Atualizacoes.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upTela" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <n3s:servicosOferecidos runat="server" ID="listaServicos" /> 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
