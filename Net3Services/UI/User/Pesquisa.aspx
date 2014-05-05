<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pesquisa.aspx.cs" Inherits="UI.User.Pesquisa2" %>
<%@ Register TagPrefix="n3s" TagName="notificacoes" Src="~/Componentes/Notificacoes.ascx" %>
<%@ Register TagPrefix="n3s" TagName="infoPesquisa" Src="~/Componentes/InformacoesPesquisa.ascx" %>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="utf-8" />
    <title>Net3s</title>
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <link href="../Styles/Atualizacoes.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Forms.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/colorbox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/jquery.confirm.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.confirm.js"></script>
    <script type="text/javascript" src="../Scripts/modernizr-1.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.colorbox-min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var idLog = $("#idLog").val();
            var idUrl = $("#idUrl").val();

            $('#menu-trigger').click(function () {
                $(this).next('#conteudoMenu').slideToggle();
                $(this).toggleClass('active');

                if ($(this).hasClass('active'))
                    $(this).find('span').html('&#x25B2;')
                else
                    $(this).find('span').html('&#x25BC;')
            });

            $('#notifi-trigger').click(function () {
                $(this).next('#conteudoNotifi').slideToggle();
                $(this).toggleClass('active');

                if ($(this).hasClass('active'))
                    $(this).find('span').html('&#x25B2;')
                else
                    $(this).find('span').html('&#x25BC;')
            });
        });

        // Realiza a busca quando o navegador não suporta o tipo search 
        $('.busca').keypress(function (e) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) {
                var busca = $('.busca').val();
                window.location = "../User/Pesquisa.aspx?paran=" + busca;
            }
        });

        // Realiza a quando utilizar o sistema de voz 
        function efetuarBuscaFala(event) {
            var busca = $('.busca').val();
            window.location = "../User/Pesquisa.aspx?paran=" + busca;
        }

        // Realiza a busca quando pressionar enter no campo
        function efetuarBuscaEnter(input) {
            var busca = $('.busca').val();
            window.location = "../User/Pesquisa.aspx?paran=" + busca;
        }
    </script>
</head>
<body>
   <input type="hidden" id="idUrl" value="<%= this.idUrl %>" />
   <input type="hidden" id="idLog" value="<%= this.idLog %>" />
   <form id="formPesquisa" runat="server">   
       <header id="cabecalho">
		    <div class="contCabecalho">
  		        <a href="../User/Perfil.aspx?id=<%= this.idLog %>"><img src="../Styles/img/logo.png" class="logo" /></a>
                <input type="search" name="busca" onsearch="efetuarBuscaEnter(this)" class="busca" autosave="busca_net3s" results="5" placeholder="Buscar" grammar="builtin:search" 
                    x-webkit-speech="" lang="pt-br" speech="" onwebkitspeechchange="efetuarBuscaFala()"/>
                <nav id="menu">
                    <ul>
                        <li id="notificacoes">
                            <a id="notifi-trigger" href="#">Notificações <span>&#x25BC;</span></a>
                            <div id="conteudoNotifi">
                                <n3s:notificacoes ID="notificacoesN3S" runat="server" />
                            </div>
                        </li>
                        <li id="subMenu">
                            <a id="menu-trigger" href="#"><%= this.nomeUsu %> <span>&#x25BC;</span></a>
                            <div id="conteudoMenu">
                                <a href="../User/Perfil.aspx?id=<%= this.idLog %>">Perfil</a><br />
                                <a href="../User/Atualizacoes.aspx?id=<%= this.idLog %>">Atualizações</a><br />
                                <a href="../User/ConfigGeral.aspx?id=<%= this.idLog %>">Configurações</a><br />
                                <a href="../Logout.aspx">Sair</a><br />
                            </div>
                        </li>
                    </ul>
                </nav>
		    </div>
	    </header>
       <div id="conteudo">
            <asp:ScriptManager ID="myScriptManager" runat="server" EnablePageMethods="true" />
            <asp:Panel ID="PanelPrincipal" runat="server">
                <asp:UpdatePanel ID="upPagina" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:UpdateProgress id="updateProgress" runat="server">
                            <ProgressTemplate>
                                <div class="loading">
                                    <span><i class="icon-spinner icon-spin"></i>Carregando ...</span>
                                </div>
                         </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div id="lateral">
                            <header class="titulo"><h4>Filtros de Busca</h4></header>
                            <nav class="menu">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lbUsuarios" runat="server" OnClick="lbUsuarios_Click"><i class="icon-user"></i>Usuários</asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lbServicos" runat="server" OnClick="lbServicos_Click"><font class='iconesTres'>a</font>Serviços</asp:LinkButton>
                                    </li>
                                </ul>
                            </nav>
                            <br />
                            <asp:Panel ID="panelFiltrosServico" runat="server" Visible="false">
                                <header class="titulo"><h4>Categorias</h4></header>
                                <nav class="menu">
                                    <asp:BulletedList ID="blListCategorias" DisplayMode="LinkButton" runat="server" OnClick="blListCategorias_Click" />
                                </nav>            
                                <br />
                                <header class="titulo"><h4>Classificação</h4></header>
                                <nav class="menu">
                                    <asp:BulletedList ID="blListClassificacoes" DisplayMode="LinkButton" runat="server" OnClick="blListClassificacoes_Click" />
                                </nav>            
                                <br />
                                <nav class="menu">
                                    <ul>
                                        <li><asp:LinkButton CssClass="menu" ID="lbRemoverFiltroServ" runat="server" OnClick="lbRemoverFiltroServ_Click"><i class="icon-remove"></i>Remover Filtros</asp:LinkButton></li>
                                    </ul>
                                </nav>
                            </asp:Panel>
                        </div>
                        <div id="meio">
                            <h2><asp:Label ID="lblTitulo" runat="server" Text="Titulo" /></h2>
                            <div id="formNet3s">
                                <label>Buscar Por:</label>
                                <asp:TextBox ID="txtFiltro" runat="server" CssClass="campos" grammar="builtin:search"
                                    x-webkit-speech="" lang="pt-br" speech="" onwebkitspeechchange="efetuarBusca()" />
                                <br />
                                <asp:LinkButton ID="lbPesquisar" runat="server" CssClass="nbutton" OnClick="lbPesquisar_Click"><i class='icon-search'></i>Pesquisar</asp:LinkButton>
                            </div>
                            <br clear="all" />
                            <div id="visuAtualizacoes">
                                <n3s:infoPesquisa runat="server" ID="searchResult" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <footer class="rodape">
			    <nav id="links">
                    <p>Copyright (c) 2011 - NET3 Services. Todos os direitos reservados.</p>
			        <p><a href="#">Sobre</a> | <a href="#">Ajuda</a> | <a href="#">Anúncio</a></p>
			    </nav>
                <nav id="mongo">
			        <a href="http://www.mongodb.org/" target="new"><img src="../Styles/img/logoMongoDb.png" /></a>
			    </nav>
		    </footer>
        </div>
    </form>
</body>
</html>
