<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pesquisa.aspx.cs" Inherits="UI.User.Pesquisa" %>

<%@ Register TagPrefix="n3s" TagName="propaganda" Src="~/Componentes/Propagandas.ascx" %>
<%@ Register TagPrefix="n3s" TagName="notificacoes" Src="~/Componentes/Notificacoes.ascx" %>
<%@ Register TagPrefix="n3s" TagName="infoPesquisa" Src="~/Componentes/InformacoesPesquisa.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/Servico.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Pesquisa.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/MasterPage.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/ValidacoesN3S.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/ListUsu.css" rel="stylesheet" type="text/css" media="screen" />
    <link href='http://fonts.googleapis.com/css?family=Rokkitt:400,700|Salsa' rel='stylesheet' type='text/css' />
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins.js"></script>
    <script type="text/javascript">
        function efetuarBuscaPelaBarra(event) {
            var busca = $('.searchbox').val();
            window.location = "Pesquisa.aspx?paran=" + busca;
        }

        function efetuarBusca(event) {
            document.getElementById('<%=lbPesquisar.ClientID%>').click();
        }

        $(document).ready(function () {
            $('#notificacao').click(function () {
                $('#conteudoNotificacao').slideToggle('slow');
            });

            // Executa a busca ao pressionar a tecla enter no campo 'txtBuscarInfo'     
            $('.searchbox').keypress(function (e) {
                var code = (e.keyCode ? e.keyCode : e.which);
                if (code == 13) {
                    $('.searchbox_submit').trigger("click");
                }
            });

            // Executa a busca ao pressionar a tecla enter no campo 'txtFiltro'     
            $('#<%= txtFiltro.ClientID %>').keypress(function (e) {
                var code = (e.keyCode ? e.keyCode : e.which);
                if (code == 13) {
                    efetuarBusca();
                }
            });
        });
    </script>
</head>
<body>
    <div id="wrapper">
        <div id="menuTop">
            <img src="../Styles/img/logo.png" id="logo" alt="Net3 Services" />
            <!-- Barra de busca -->
            <div id="searchwrapper">
                <form id="formPesquisa" action="" method="post">
                <input type="text" class="searchbox" placeholder="Busque por serviços/usuários" grammar="builtin:search" x-webkit-speech="" lang="pt-br" speech="" onwebkitspeechchange="efetuarBuscaPelaBarra()" />
                <button class="searchbox_submit" onclick="location.href = 'Pesquisa.aspx?paran=' + $('.searchbox').val(); return false;"></button>
                </form>
            </div>
            <!-- Menu na barra principal -->
            <div id="opcoes">
                <a href="#" id="notificacao" class="link">Notificações</a>
                <asp:HyperLink ID="hlPerfil" runat="server" CssClass="link">Perfil</asp:HyperLink>
                <a href="ConfigGeral.aspx" id="hlConfiguracoes" class="link">Configurações</a>
                <a href="../Default.aspx" id="A2" class="link">Sair</a>
            </div>
        </div>
        <div id="conteudoNotificacao">
            <n3s:notificacoes ID="notificacoesN3S" runat="server" />
        </div>
        <br />
        <form id="formGeral" runat="server">
        <asp:ScriptManager ID="myScriptManager" runat="server" EnablePageMethods="true" />
        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbPesquisar">
            <asp:UpdatePanel ID="upPagina" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- Menu latera; -->
                    <div id="ladoEsquerdo">
                        <br />
                        <font class="subTitulo">Buscar</font>
                        <br />
                        <img src="../Styles/img/54.png" class="menuIcoPes" alt="" />
                        <asp:LinkButton CssClass="menu" ID="lbUsuarios" runat="server" OnClick="lbUsuarios_Click">Usuários</asp:LinkButton>
                        <img src="../Styles/img/1.png" class="menuIcoPes" alt="" />
                        <asp:LinkButton CssClass="menu" ID="lbServicos" runat="server" OnClick="lbServicos_Click">Serviços</asp:LinkButton>
                        <br />
                        <asp:Panel ID="panelFiltrosServico" runat="server" Visible="false">
                            <div class="filtros">
                                <font class="subTitulo">Fitros de Busca</font>
                                <br />
                                <span class="subTituloPes">Categorias</span>
                                <div>
                                    <asp:BulletedList ID="blListCategorias" DisplayMode="LinkButton" runat="server" OnClick="blListCategorias_Click" />
                                </div>
                                <br />
                                <span class="subTituloPes">Classificação</span>
                                <div>
                                    <asp:BulletedList ID="blListClassificacoes" DisplayMode="LinkButton" runat="server"
                                        OnClick="blListClassificacoes_Click" />
                                </div>
                                <img src='../Styles/img/118.png' class='menuIcoPes' alt="" />
                                <asp:LinkButton CssClass="menu" ID="lbRemoverFiltroServ" runat="server" OnClick="lbRemoverFiltroServ_Click">Remover Filtros</asp:LinkButton>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="panelFiltrosUsuario" runat="server" Visible="false">
                            <div class="filtros">
                                <font class="subTitulo">Fitros de Busca</font>
                                <br />
                                <span class="subTituloPes">Gênero</span>
                                <div>
                                    <asp:BulletedList ID="blListGenero" DisplayMode="LinkButton" runat="server" OnClick="blListGenero_Click" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="conteudo">
                        <br />
                        <asp:Image ID="imgIcone" runat="server" CssClass="iconePesquisa" />
                        <font class="tituloPes">
                            <asp:Label ID="lblTitulo" runat="server" Text="Titulo" /></font>
                        <br />
                        <br />
                        <hr />
                        <!-- Filtro da Pesquisa -->
                        <asp:Label ID="lblFiltro" runat="server" Text="Filtro:" CssClass="labelPesqisa" />
                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="campos" grammar="builtin:search"
                            x-webkit-speech="" lang="pt-br" speech="" onwebkitspeechchange="efetuarBusca()" />
                        <br />
                        <asp:Label ID="lblFiltroUm" runat="server" Text="Pesquisar Por:" CssClass="labelPesqisa" />
                        <asp:DropDownList ID="lbOpcoesBusca" runat="server" CssClass="camposOption">
                        </asp:DropDownList>
                        <br />
                        <div id="btnPesquisar">
                            <asp:LinkButton ID="lbPesquisar" runat="server" CssClass="btn" OnClick="lbPesquisar_Click">Pesquisar</asp:LinkButton>
                        </div>
                        <br />
                        <br />
                        <div>
                            <!-- Resultaddo da Pesquisa -->
                            <n3s:infoPesquisa runat="server" ID="informacao" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        </form>
        <div id="footer">
            <div id="mongo">
                <b>Powered By</b>
                <br />
                <a href="http://www.mongodb.org/" target="new">
                    <img src="../Styles/img/mongo.png" alt="Powered By MongoDB" /></a>
            </div>
            <center>
                <p>
                    Copyright (c) 2011 - NET3 Services. Todos os direitos reservados.</p>
                <p>
                    <a href="#">Sobre</a> | <a href="#">Ajuda</a> | <a href="#">Anúncio</a></p>
            </center>
        </div>
    </div>
</body>
</html>
