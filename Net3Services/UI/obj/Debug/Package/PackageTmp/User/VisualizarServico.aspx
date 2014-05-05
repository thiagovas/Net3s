<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true"
    CodeBehind="VisualizarServico.aspx.cs" Inherits="UI.User.VisualizarServico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Visualizar.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="myScriptManager" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            /* Variaveis que armazenam os id's do usuário e do serviço */
            var usu = $("#pageUsu").val();
            var serv = $("#pageServ").val();

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
                            $('#<%= lblUniMed.ClientID  %>').text(alteracoes[6]);
                            $('#<%= lblCategoria.ClientID  %>').text(alteracoes[7]);
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
                <div id="principal">
                    <h1><asp:Label ID="lblNomeServ" runat="server" Text="Nome do Serviço" /></h1>
                    <label id='avali'>
                        <asp:Label ID="lblAvaliacao" runat="server" Text="" />
                    </label>
                    <br />
                    <div id='compartilhar'>
                        <!-- Botão Linkedin -->
                        <label class='btnCompartilhar'>
                            <script src="http://platform.linkedin.com/in.js" type="text/javascript"></script>
                            <script type="IN/Share" data-url="<?php the_permalink() ?>" data-counter="right"></script>
                        </label>
                        <!-- Botão Tweet -->
                        <label class='btnCompartilharEsp'>
                            <a href="http://twitter.com/share?url=http://migre.me/api.txt?url=<?php the_permalink() ?>"
                                rel="nofollow" data-via="net3s" class="twitter-share-button" data-count="horizontal">
                                Tweet</a>
                            <script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
                        </label>
                        <!-- Botão Plus One -->
                        <label class='btnCompartilharEsp'>
                            <script type="text/javascript" src="https://apis.google.com/js/plusone.js">
                                { lang: 'pt-BR' }
                            </script>
                            <g:plusone size="medium"></g:plusone>
                        </label>
                        <!-- Botão Curtir -->
                        <label class='btnCompartilhar'>
                            <iframe src="http://www.facebook.com/plugins/like.php?href=<?php the_permalink() ?>&amp;layout=button_count&amp;show_faces=false&amp;width=80&amp;action=like&amp;colorscheme=light"
                                scrolling="no" frameborder="0" allowtransparency="true" style="border: none;
                                overflow: hidden; width: 80px; height: 20px"></iframe>
                        </label>
                    </div>
                </div>
                <br /><br />
                <div id="conteudoVisu">
                    <label><i class='icon-file'></i>Descrição:</label>
                    <asp:Label ID="lblDescricao" runat="server" CssClass="valor" />
                    <br />
                    <label><i class='icon-group'></i>Categoria:</label>
                    <asp:Label ID="lblCategoria" runat="server"  CssClass="valor" />
                    <br />
                    <label><i class='icon-reorder'></i>Unidade de Medida:</label>
                    <asp:Label ID="lblUniMed" runat="server"  CssClass="valor" />
                    <br />
                    <label><i class='icon-money'></i>Preço:</label>
                    <asp:Label ID="lblPreco" runat="server"  CssClass="valor" />
                    <br />
                    <label><i class='icon-map-marker'></i>Regional:</label>
                    <asp:Label ID="lblRegional" runat="server"  CssClass="valor" />
                    <br />
                    <label><i class='icon-signal'></i>Nivel de Regionalidade:</label>
                    <asp:Label ID="lblNivelRegio" runat="server" CssClass="valor" />
                </div>
                <br />
                <div>
                    <a id="editar" href="EditarServico.aspx?id=this.usu"  class="button edit" runat="server">Editar Serviço</a> &nbsp;
                    <button id="excluir" class="button delete" runat="server">Excluir Serviço</button> &nbsp;
                    <asp:LinkButton ID="linkBtnOrcamento" runat="server" CssClass="button money">Contratar</asp:LinkButton>
                    <br />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
