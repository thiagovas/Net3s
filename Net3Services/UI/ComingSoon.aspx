<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComingSoon.aspx.cs" Inherits="UI.CommingSoon" %>

<!DOCTYPE html>
<html lang="pt-br">
<head id="Head1" runat="server">
    <title>Net3 Services</title>
    <link rel="shortcut icon" href="../Imagens/favicon.ico" />
    <link href="../Styles/Default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <link href='http://fonts.googleapis.com/css?family=Josefin+Slab:400,700' rel='stylesheet' type='text/css' /> 
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container">
            <div class="st-container">
                <input type="radio" name="radio-set" checked="checked" id="st-control-1" />
                <a href="#st-panel-1">Bem Vindo</a>
                <input type="radio" name="radio-set" id="st-control-2" />
                <a href="#st-panel-2" >O que é o Net3s?</a>
                <input type="radio" name="radio-set" id="st-control-3" />
                <a href="#st-panel-3">Progresso</a>
                <div class="st-scroll">
                    <section class="st-panel" id="st-panel-1">
				        <div class="st-deco" data-icon="8"></div>
                        <img src="Styles/img/logo.png" alt="" class="logo" />
  					    <br />
                        <img src="Styles/img/GLOBO.png" class="globo" alt="" />
                        <div class="textos">
                            <h2><i class="icon-warning-sign"></i>Página em construção</h2>
                            <input type="email" tabindex="1" style="width:360px;" class="camposTexto" placeholder="Informe seu e-mail para ser informado sobre o lançamento do Net3s" autofocus />
                            <asp:Button ID="btnSubscribe" runat="server" Text="Enviar" CssClass="button" TabIndex="2" />
                        </div>
                        <div class="rodape">
                            Net3 Services © 2011&nbsp;&nbsp;|&nbsp;&nbsp;
                            <a href="http://net3services.wordpress.com/" target="new" TabIndex="9">Blog</a> · 
                            <a href="https://twitter.com/net3s" target="new" TabIndex="11">Twitter</a> · <a href="http://www.facebook.com/net3s" target="new" TabIndex="12">Facebook</a>
                        </div>
                    </section>
                    <section class="st-panel st-color" id="st-panel-2">
				        <div class="st-deco" data-icon="K"></div>
                        <img src="Styles/img/logo.png" alt="" class="logo" />
  					    <div class="about">
                            <ul>
                                <li><h2>O que é o net3s?</h2></li>
                                <li>
                                    O Net3 Services é uma rede social voltada para o mundo dos negócios, abrangendo todas as áreas e pessoas envolvidas na prestação de serviços , ou seja, o terceiro setor da economia.
                                    Contando com o recurso das redes sociais e anúncios on-line de serviços freelance, os usuários podem oferecer serviços e anunciar necessidades de serviços, podendo receber ofertas para realizarem serviços ou para suprir as suas necessidades. O sistema é inovador nessa área, pois não existem redes sociais voltadas para esse tipo de incorporação entre os usuários.
                                </li>
                            </ul>
                        </div>
                        <div class="rodape">
                            Net3 Services © 2011&nbsp;&nbsp;|&nbsp;&nbsp;
                            <a href="http://net3services.wordpress.com/" target="new" TabIndex="9">Blog</a> · 
                            <a href="https://twitter.com/net3s" target="new" TabIndex="11">Twitter</a> · <a href="http://www.facebook.com/net3s" target="new" TabIndex="12">Facebook</a>
                        </div>
				    </section>
                    <section class="st-panel" id="st-panel-3">
				        <div class="st-deco" data-icon="u"></div>
                        <img src="Styles/img/logo.png" alt="" class="logo" />
  					    <div class="progress">
                            <h2>Progresso de desenvolvimento</h2>
                            <h4>Atualmente <span>77%</span> do <span>Net3s</span> foi concluído</h4>
                            <div class="progressbar progressbar-purple">
                                <div class="progressbar-inner"></div>
                            </div>
                            <div class="esquerda">
                                <h4>Feito</h4>
                                <ul>
                                    <li><i class="icon-ok"></i>Design das páginas</li>
                                    <li><i class="icon-ok"></i>Banco de Dados</li>
                                    <li><i class="icon-ok"></i>Feed de Notícias</li>
                                    <li><i class="icon-ok"></i>Network (Amigos)</li>
                                    <li><i class="icon-ok"></i>Módulo Usuário</li>
                                    <li><i class="icon-ok"></i>Módulo Serviços</li>
                                    <li><i class="icon-ok"></i>Módulo Orçamentos</li>
                                </ul>
                            </div>
                            <div class="meio">
                                <h4>Em Execução</h4>
                                <ul>
                                    <li><i class="icon-caret-right"></i>Emissão de Boleto Bancário</li>
                                    <li><i class="icon-caret-right"></i>Módulo Currículo</li>
                                    <li><i class="icon-caret-right"></i>Módulo Mensagens</li>
                                </ul>
                            </div>
                            <div class="direita">
                                <h4>A Fazer</h4>
                                <ul>
                                    <li><i class=" icon-remove"></i>Avaliação de Serviços</li>
                                    <li><i class=" icon-remove"></i>Módulo Busca</li>
                                    <li><i class=" icon-remove"></i>Geoposicionamento</li>
                                </ul>
                            </div>
                        </div>
				    </section>
                </div> <!-- // st-scroll -->
            </div> <!-- // st-container -->
        </div>
    </form>
</body>
</html>
