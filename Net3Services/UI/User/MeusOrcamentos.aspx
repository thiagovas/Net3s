<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="MeusOrcamentos.aspx.cs" Inherits="UI.User.MeusOrcamentos" %>
<%@ Register TagPrefix="n3s" TagName="vOrcam" src="../Componentes/VisualizarOrcamento.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Atualizacoes.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                $('a.orcamento').colorbox({
                    width: "60%",
                    height: "60%",
                    transition: "fade",
                    iframe: true,
                    escKey: true,
                    xhrError: "Falha ao carregar conteúdo"
                });

            });
    </script>
    <n3s:vOrcam runat="server" ID="VOrcamento" />
</asp:Content>
