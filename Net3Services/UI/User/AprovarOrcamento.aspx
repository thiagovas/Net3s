<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="AprovarOrcamento.aspx.cs" Inherits="UI.User.AprovarOrçamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Visualizar.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= btnSolicitar.ClientID %>').colorbox({
                width: "50%",
                height: "50%",
                transition: "fade",
                iframe: true,
                escKey: true,
                xhrError: "Falha ao carregar conteúdo"
            });
        });
    </script>
    <div id="visualizacao">
        <div id="principal">
            <h1>Solicitação de Orçamento - <asp:Label ID="lblNome" runat="server" Text=""></asp:Label></h1>
        </div>
        <br /><br />
        <div id="conteudoVisu">
            <label><i class="icon-cogs"></i>Serviço:</label>
            <asp:Label ID="lblServico" runat="server" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-tasks"></i>Prioridade:</label>
            <asp:Label ID="lblPrioridade" runat="server" CssClass="valor"></asp:Label>
            <br />
            <label><i class='icon-file'></i>Descrição:</label>
            <asp:Label ID="lblDesc" runat="server" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-calendar"></i>Data da Solicitação:</label>
            <asp:Label ID="lblDataSol" runat="server" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-shopping-cart"></i>Quantidade Solicitada:</label>
            <asp:Label ID="lblQuantidade" runat="server" CssClass="valor"></asp:Label>
            <label><i class="icon-info-sign"></i>Status do Pedido de Orçamento:</label>
            <asp:Label ID="lblStatus" runat="server" CssClass="valor"></asp:Label>
            <br />
            <a href="CriarOrcamento.aspx" class="button money" id="btnSolicitar" runat="server">Criar Orçamento</a>
            <br />
        </div>
    </div>
</asp:Content>
