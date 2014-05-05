<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OldDefault.aspx.cs" Inherits="UI.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Net3Services</title>
    <link href="../Styles/estilo.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jPaginate.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/lightBox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href='http://fonts.googleapis.com/css?family=Rokkitt:400,700|Salsa' rel='stylesheet'
        type='text/css' />
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins.js"></script>
    <script type="text/javascript">
        function efetuarBusca(event) {
            document.getElementById('<%=btnPesquisar.ClientID%>').click();
        }

        $(function () {
            $('ul.nav a').bind('click', function (event) {
                var $anchor = $(this);

                $('html, body').stop().animate({
                    scrollTop: $($anchor.attr('href')).offset().top
                }, 1500, 'easeInOutExpo');
                event.preventDefault();
            });
        });

        $(document).ready(function () {
            // Contratar
            $('.btnContratar').modal({
                url: 'logarCadastrar.aspx',
                closeClickOut: true,
                position: 'relative',
                referencePosition: $('#centroPes')
            });

            // Paginação ao criar o elemento com a busca
            $("#numPag").paginate({
                count: $("#hidNumPags").val(),
                start: 1,
                display: 10,
                border: true,
                border_color: '#fff',
                text_color: '#fff',
                background_color: '#3f3f3f',
                border_hover_color: '#ccc',
                text_hover_color: '#000',
                background_hover_color: '#fff',
                images: false,
                mouse: 'press',
                onChange: function (page) {
                    $('._current', '#pesquisa').removeClass('_current').hide();
                    $('#p' + page).addClass('_current').show();
                }
            });

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function () {
                var numPaginas = $("#hidNumPags").val();

                $('.btnContratar').modal({
                    url: 'logarCadastrar.aspx',
                    closeClickOut: true,
                    position: 'relative',
                    referencePosition: $('div#centroPes')
                });

                $("#numPag").paginate({
                    count: $("#hidNumPags").val(),
                    start: 1,
                    display: 10,
                    border: true,
                    border_color: '#fff',
                    text_color: '#fff',
                    background_color: '#3f3f3f',
                    border_hover_color: '#ccc',
                    text_hover_color: '#000',
                    background_hover_color: '#fff',
                    images: false,
                    mouse: 'press',
                    onChange: function (page) {
                        $('._current', '#pesquisa').removeClass('_current').hide();
                        $('#p' + page).addClass('_current').show();
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form runat="server" name="frmLogin">
    <asp:ScriptManager ID="sManagerPagina" runat="server">
    </asp:ScriptManager>
    <div id="center">
        <div id="login">
            <div id="marca">
                <img src="../Styles/img/marca.png" width="670" height="70" alt="Net3" /></div>
            <div id="formLogin">
                <div class="camposTexto">
                    <asp:TextBox ID="txtLogin" runat="server" CssClass="input" placeholder="Login/Email"
                        TabIndex="1"></asp:TextBox>
                    <asp:CheckBox ID="chkLembrar" runat="server" CssClass="input" OnCheckedChanged="chkLembrar_CheckedChanged" />&nbsp; Lembrar-me
                </div>
                <div class="camposTexto">
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="input" TextMode="Password" placeholder="Senha"
                        TabIndex="2"></asp:TextBox>
                    <div style="margin-top: 5px">
                        <a href="RecuperarSenha.aspx" class="linkw" style="margin-top: 5px;">Esqueci minha senha</a></div>
                </div>
                <asp:Button ID="btnLogar" runat="server" Text="ENTRAR" CssClass="button" Height="21px"
                    Width="59px" OnClick="btnLogar_Click" />
            </div>
        </div>
        <div id="banner">
            <div id="globo">
                <img src="Styles/img/GLOBO.png" alt="" style="height: 324px; width: 338px" />
            </div>
            <img src="../Styles/img/banner.png" height="165" style="width: 1119px; margin-left: 75px;"
                alt="" />
        </div>
        <div id="cadastro">
            <div class="linkCadastro">
                Ainda não conhece o Net3 Services?<br />
                <br />
                <div style="margin-top: 5px">
                    <a href="CadastroUsuario.aspx">CADASTRE-SE AGORA MESMO!</a></div>
                <br />
                <ul class="nav">
                    <li><a href="#conteudoPes" class="btn">Localizar Serviços</a></li>
                </ul>
            </div>
        </div>
        <div id="thumbsUsers">
            &nbsp;</div>
        <div id="rodape">
            <a href="#">Net3 Services © 2011</a>&nbsp;&nbsp;|&nbsp;&nbsp; <a href="#">Sobre
            </a> · <a href="#">Anúnciar</a> · <a href="#">Desenvolvedores</a> · <a href="http://net3services.wordpress.com/"
                target="new">Blog</a> · <a href="#">Termos de Uso</a> · <a href="Twitter.aspx">Twitter</a>
        </div>
    </div>
    <div id="pesquisaOff">
        <div class="separadorTop">
        </div>
        <div id="conteudoPes">
            <div id="topPes">
                <img src="../Styles/img/logo.png" alt="Net3 Services" id="logoPes" />
                <div id="voltar">
                    <ul class="nav">
                        <li><a href="#center" id="voltarTopo">Voltar ao Topo</a></li>
                    </ul>
                </div>
            </div>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPesquisar">
                <asp:UpdatePanel ID="upPesquisa" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="lateralPes">
                            <h3>
                                Categorias</h3>
                            <img src='../Styles/img/6.png' alt='' />
                            <asp:LinkButton ID="lbAdvocacia" runat="server" CssClass="link" OnClick="lbAdvocacia_Click">Advocacia</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/175.png' alt='' />
                            <asp:LinkButton ID="lbArtesanato" runat="server" CssClass="link" OnClick="lbArtesanato_Click">Artesanatos e Hobbies</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/131.png' alt='' />
                            <asp:LinkButton ID="lbAutomoveis" runat="server" CssClass="link" OnClick="lbAutomoveis_Click">Autom&oacute;veis e Veículos</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/69.png' alt='' />
                            <asp:LinkButton ID="lbBeleza" runat="server" CssClass="link" OnClick="lbBeleza_Click">Beleza e Est&eacute;tica</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/120.png' alt='' />
                            <asp:LinkButton ID="lbCasaDeco" runat="server" CssClass="link" OnClick="lbCasaDeco_Click">Casa e Decora&ccedil;&atilde;o</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/200.png' alt='' />
                            <asp:LinkButton ID="lbConstrucao" runat="server" CssClass="link" OnClick="lbConstrucao_Click">Constru&ccedil;&atilde;o Civil</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/3.png' alt='' />
                            <asp:LinkButton ID="lbConsultoria" runat="server" CssClass="link" OnClick="lbConsultoria_Click">Consultoria</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/95.png' alt='' />
                            <asp:LinkButton ID="lbCultura" runat="server" CssClass="link" OnClick="lbCultura_Click">Cultura e Arte</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/22.png' alt='' />
                            <asp:LinkButton ID="lbEducacao" runat="server" CssClass="link" OnClick="lbEducacao_Click">Educação</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/782.png' alt='' />
                            <asp:LinkButton ID="lbEsporte" runat="server" CssClass="link" OnClick="lbEsporte_Click">Esporte</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/785.png' alt='' />
                            <asp:LinkButton ID="lbFestas" runat="server" CssClass="link" OnClick="lbFestas_Click">Festas e Eventos</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/125.png' alt='' />
                            <asp:LinkButton ID="lbFotografia" runat="server" CssClass="link" OnClick="lbFotografia_Click">Fotografia</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/971.png' alt='' />
                            <asp:LinkButton ID="lbGastronomia" runat="server" CssClass="link" OnClick="lbGastronomia_Click">Gastronomia</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/21.png' alt='' />
                            <asp:LinkButton ID="lbInformatica" runat="server" CssClass="link" OnClick="lbInformatica_Click">Inform&aacute;tica e Tecnologia</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/462.png' alt='' />
                            <asp:LinkButton ID="lbJardinagem" runat="server" CssClass="link" OnClick="lbJardinagem_Click">Jardinagem</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/206.png' alt='' />
                            <asp:LinkButton ID="lbJogos" runat="server" CssClass="link" OnClick="lbJogos_Click">Jogos e Enrtetenimento</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/1.png' alt='' />
                            <asp:LinkButton ID="lbManutencao" runat="server" CssClass="link" OnClick="lbManutencao_Click">Manuten&ccedil;&atilde;o Dom&eacute;stica</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/203.png' alt='' />
                            <asp:LinkButton ID="lbMarketing" runat="server" CssClass="link" OnClick="lbMarketing_Click">Marketing e Comunica&ccedil;&atilde;o</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/870.png' alt='' />
                            <asp:LinkButton ID="lbMedicina" runat="server" CssClass="link" OnClick="lbMedicina_Click">Medicina Alternativa</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/576.png' alt='' />
                            <asp:LinkButton ID="lbModa" runat="server" CssClass="link" OnClick="lbModa_Click">Moda, Roupas e Acess&oacute;rios</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/17.png' alt='' />
                            <asp:LinkButton ID="lbMusica" runat="server" CssClass="link" OnClick="lbMusica_Click">M&uacute;sica</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/191.png' alt='' />
                            <asp:LinkButton ID="lbSaude" runat="server" CssClass="link" OnClick="lbSaude_Click">Sa&uacute;de</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/166.png' alt='' />
                            <asp:LinkButton ID="lbSeguranca" runat="server" CssClass="link" OnClick="lbSeguranca_Click">Seguran&ccedil;a</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/923.png' alt='' />
                            <asp:LinkButton ID="lbServGerais" runat="server" CssClass="link" OnClick="lbServGerais_Click">Servi&ccedil;os Gerais</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/66.png' alt='' />
                            <asp:LinkButton ID="lbTransportes" runat="server" CssClass="link" OnClick="lbTransportes_Click">Transportes</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/399.png' alt='' />
                            <asp:LinkButton ID="lbTurismo" runat="server" CssClass="link" OnClick="lbTurismo_Click">Turismo e Lazer</asp:LinkButton>
                            <br />
                            <img src='../Styles/img/294.png' alt='' />
                            <asp:LinkButton ID="lbVeterinaria" runat="server" CssClass="link" OnClick="lbVeterinaria_Click">Veterin&aacute;ria</asp:LinkButton>
                        </div>
                        <div id="centroPes">
                            <h3>
                                <asp:Label ID="lblTitulo" runat="server" Text="Últimas Ofertas"></asp:Label></h3>
                            <div id="searchwrapper">
                                <asp:TextBox ID="txtPesquisa" placeholder="Nome do serviço" CssClass="searchbox"
                                    runat="server" AutoCompleteType="Search" grammar="builtin:search" x-webkit-speech=""
                                    lang="pt-br" speech="" onwebkitspeechchange="efetuarBusca()"></asp:TextBox>
                                <asp:Button ID="btnPesquisar" CssClass="searchbox_submit" runat="server" Text=""
                                    OnClick="btnPesquisar_Click" />
                            </div>
                            <br />
                            <br />
                            <asp:PlaceHolder ID="phPesquisa" runat="server"></asp:PlaceHolder>
                            <input type="hidden" runat="server" id="hidNumPags" value="" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
        <div class="separadorBottom">
        </div>
    </div>
    <div id="net3">
        Net3 Services © 2011
    </div>
    </form>
</body>
</html>
