<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="ListarMensagens.aspx.cs" Inherits="UI.User.ListarMensagens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Atualizacoes.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="visuAtualizacoes">
        <h1>Mensagens</h1>
        <br /><br />

        <!-- Fazer este HTML para CADA conversa. -->
        <a href="VisualizarMensagem.aspx">
            <div class='atualizacao'>
                <article class='conteudo'>
                    <!--
                        Na hora verifique se tem 2 usuários (vc e outro), 3 (vc e outros 2 caras) ou 3+ (vc, outros 2 e toda a
                        torcida do flamengo) para aplicar a class. As classes vão ser:
                         - 2 usuários: picOne
                         - 3 usuários: picTwo
                         - 3 + usuários: picThree (quando for 3+ pegar randomicamente as 3 fotos que vão aparecer, ou a dos 3 
                           ultimos comentários. Vc decide isso)
                        Nos imgs não coloque a foto do usuário que está lendo as mensagens. 
                    -->
                    <div class="photos">
                        <div class="picOne">
                            <img src="#" />
                        </div>
                    </div>
                    <!-- Faça uma string com os nomes concatenados, separados por virgula, e depois aplique um FormatarMensagem(nomes, 52)
                         neles (melhorexplicado abaixo) para não ficar feio caso tenha muitas pessoas na conversa.  
                         Obs: Este 52 eu testei para ver o que ia fica bom. Use ele! 
                    -->
                    <p class='nome'>Marcio Junior</p>
                    <!-- 
                        Quando for colocar a data chamar o método estático FormatarDataPublicacao do clsUtilidades.
                        Tem que fazer isso para a data aparecer formatada 'bonitinha' na tela (se tiver vontade veja no método o que ele faz).
                    -->
                    <time pubdate class='data'> 01/01/2013 </time> 
                    <br /><br /><br />
                    <!-- 
                        Quando for colocar a data chamar o método estático FormatarMensagem do clsUtilidades. Ele só dá o "truncate" na 
                        mensagem, mais é melhor usar ele dó que chamar toda hora, pq daí se a gente escolher mostrar um núemro maior
                        ou menor de caracteres no futuro não vamos ter problemas.
                    -->
                    <p class='mensagem'> bla bla bla bla mensagem</p>
                </article>
            </div>
        </a>
        <!-- Exemplo 3 usuários -->
        <a href="VisualizarMensagem.aspx">
            <div class='atualizacao'>
                <article class='conteudo'>
                    <div class="photos">
                        <div class="picTwo">
                            <img src="#" class="first" />
                            <img src="#" class="second" />
                        </div>
                    </div>
                    <p class='nome'>Marcio Junior, Breno Silva e Pires</p>
                    <time pubdate class='data'> 01/01/2013 </time> 
                    <br /><br /><br />
                    <p class='mensagem'> bla bla bla bla mensagem</p>
                </article>
            </div>
        </a>
        <!-- Exemplo 3+ usuários -->
        <a href="VisualizarMensagem.aspx">
            <div class='atualizacao'>
                <article class='conteudo'>
                    <div class="photos">
                        <div class="picThree">
                            <img src="#" class="first" />
                                <img src="#" class="second" />
                                <img src="#" class="third" />
                        </div>
                    </div>
                    <p class='nome'>Marcio Junior, Breno Silva e Pires, Thiago Vieira de...</p>
                    <time pubdate class='data'> 01/01/2013 </time> 
                    <br /><br /><br />
                    <p class='mensagem'> bla bla bla bla mensagem</p>
                </article>
            </div>
        </a>

    </div>
</asp:Content>
