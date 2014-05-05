<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true"
    CodeBehind="VisualizarServico.aspx.cs" Inherits="UI.User.VisualizarServico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Visualizar.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            /* Variaveis que armazenam os id's do usuário e do serviço */
            var usu = $("#pageUsu").val();
            var serv = $("#pageServ").val();

            $("#btn_share").click(function () {
                $("#share").slideToggle();
                
                if ($(this).children("i").attr('class') == "icon-chevron-down") {
                    $(this).children("i").removeClass("icon-chevron-down");
                    $(this).children("i").addClass("icon-chevron-up");
                } else {
                    $(this).children("i").addClass("icon-chevron-down");
                    $(this).children("i").removeClass("icon-chevron-up");
                }
            });

            $("#btn_location").click(function () {
                $("#location").slideToggle();

                if ($(this).children("i").attr('class') == "icon-chevron-down") {
                    $(this).children("i").removeClass("icon-chevron-down");
                    $(this).children("i").addClass("icon-chevron-up");
                } else {
                    $(this).children("i").addClass("icon-chevron-down");
                    $(this).children("i").removeClass("icon-chevron-up");
                }
            });

            /* Tela de confirmação do excluir serviço */
            $('#<%= excluir.ClientID %>').click(function () {
                var elem = $(this).closest('.item');
                $.confirm({
                    'title': 'Excluir Serviço',
                    'message': 'Deseja realmente excluir este serviço?',
                    'buttons': {
                        'Sim': {
                            'action': function () {
                                $.ajax({
                                    type: "POST",
                                    url: "VisualizarServico.aspx/Excluir",
                                    data: "{}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: window.location = "ServicosOferecidos.aspx?id=" + usu
                                });
                            }
                        }, 'Não': { /* Não faz nada e fecha a mensagem */
                        }
                    }
                });
            });

            /* Abre o light box de editar serviço */
            $('#<%= editar.ClientID %>').colorbox({
                width: "60%", 
                height: "60%",
                transition:"fade",
                iframe: true,
                escKey: true,
                xhrError: "Falha ao carregar conteúdo",
                onClosed: function () {
                    $.ajax({
                        type: "POST",
                        url: "VisualizarServico.aspx/AtualizarTela",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (dados) {
                            var alteracoes = dados.d;

                            $('#<%= lblDescricao.ClientID  %>').text(alteracoes[0]);
                            $('#<%= lblNivelRegio.ClientID  %>').text(alteracoes[1]);
                            $('#<%= lblNomeServ.ClientID  %>').text(alteracoes[2]);
                            $('#<%= lblPreco.ClientID  %>').text(alteracoes[3]);
                            $('#<%= lblRegional.ClientID  %>').text(alteracoes[4]);
                        }
                    });
                }
            });

        });
    </script>
    <asp:UpdatePanel ID="upServico" runat="server">
        <ContentTemplate>
            <input type="hidden" id="pageUsu" value="<%= this.pageUsu %>" />
            <input type="hidden" id="pageServ" value="<%= this.pageServ %>" />
            <div id="visualizacao">
                <div id="title">
                    <h1><asp:Label ID="lblNomeServ" runat="server" Text="Nome do Serviço" /></h1>
                    <asp:Label ID="lblAvaliacao" CssClass="stars" runat="server" Text="" />
                </div>    
                <br clear="all" /><br />
                <div id="left">
                    <img src='#' class='img' />
                </div>
                <div id="right">
                    <div id="info">
                        <p id='price'><asp:Label ID="lblPreco" runat="server"  CssClass="valor" /></p>
                        <asp:LinkButton ID="linkBtnOrcamento" runat="server" CssClass="nbutton">Contratar</asp:LinkButton>
                        <asp:LinkButton ID="lbFavorit" runat="server" CssClass="nbutton">Favorito</asp:LinkButton>
                    </div>
                    <p><asp:Label ID="lblDescricao" runat="server" /></p>
                </div>
                <br clear="all" /><br />
                <h3 id="btn_share"><i class="icon-chevron-down"></i>Compartilhar</h3>
                <div id="share">
                    <a href="#" class="nshare facebook" title="Facebook"><i class="icon-facebook"></i></a>
                    <a href="#" class="nshare twitter" title="Twitter""><i class="icon-twitter"></i></a>
                    <a href="#" class="nshare gplus" title="Google Plus"><i class="icon-google-plus"></i></a>
                    <a href="#" class="nshare linkedin" title="Linkedin"><i class="icon-linkedin"></i></a>
                </div>
                <br clear="all" /><br />
                <h3 id="btn_location"><i class="icon-chevron-down"></i>Localização</h3>
                <div id="location">
                    <label>Regional:</label>
                    <asp:Label ID="lblRegional" runat="server"  CssClass="valor" />
                    <br />
                    <label>Nivel de Regionalidade:</label>
                    <asp:Label ID="lblNivelRegio" runat="server" CssClass="valor" />
                </div>
                <br clear="all" />
                <a id="editar" href="EditarServico.aspx?id=this.usu" class="nbutton" runat="server"><i class="icon-edit"></i>Editar</a>
                <button id="excluir" class="nbutton" runat="server"><i class="icon-remove"></i>Excluir</button>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
