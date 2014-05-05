<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="VisualizarOrcamento.aspx.cs" Inherits="UI.User.VisualizarOrcamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Visualizar.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                var idOrcamento = $("#idOrcamento").val();

                $('#<%= btnFinalizar.ClientID %>').click(function () {
                    var elem = $(this).closest('.item');
                    $.confirm({
                        'title': 'Finalizar Orçamento',
                        'message': 'Deseja realmente alterar o status deste orçamento para finalizado? Caso o status do orçamento seja alterado ele é finalizado permanentemente e não poderá mais ser editado.',
                        'buttons': {
                            'Sim': {
                                'action': function () {
                                    $.ajax({
                                        type: "POST",
                                        url: "VisualizarOrcamento.aspx/finalizarServico",
                                        data: "{'id':"+idOrcamento+"}",
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: window.location = "ServicosOferecidos.aspx?id=" + usu
                                    });
                                }
                            }, 'Não': { /* Não faz nada e fecha a mensagem */ }
                        }
                    });
                });

            });
    </script>
    <input type="hidden" id="idOrcamento" value="<%= this.idOrc %>" />       
    <div id="visualizacao">
        <div id="principal">
            <h1>Orçamento - <asp:Label ID="lblServico" runat="server" Text="" CssClass="valor"></asp:Label></h1>
        </div>
        <br /><br />
        <div id="conteudoVisu"> 
            <label><i class="icon-user"></i>Prestador:</label>
            <asp:Label ID="lblPrestador" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-user"></i>Contratante:</label>
            <asp:Label ID="lblContatante" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-tasks"></i>Status:</label>
            <asp:Label ID="lblStatus" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-money"></i>Preço:</label>
            <asp:Label ID="lblPreco" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-calendar"></i>Previsão de Inicio:</label>
            <asp:Label ID="lblInicio" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-calendar"></i>Previsão de Fim:</label>
            <asp:Label ID="lblFim" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
            <label><i class="icon-file"></i>Descrição:</label>
            <asp:Label ID="lblDescricao" runat="server" Text="" CssClass="valor"></asp:Label>
            <br />
       </div>
       <br />
       <div>
            <button class="button spark" id="btnFinalizar" runat="server">Finalizar Orçamento</button>
       </div>
    </div>
</asp:Content>
