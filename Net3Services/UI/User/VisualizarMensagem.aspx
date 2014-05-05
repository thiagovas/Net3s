<%@ Page Title="" Language="C#" MasterPageFile="~/User/Master.Master" AutoEventWireup="true" CodeBehind="VisualizarMensagem.aspx.cs" Inherits="UI.User.VisualizarMensagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Mensagens.css" rel="stylesheet" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/themes/ui-lightness/jquery-ui.css">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Scripts/Mensagens.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js"></script>
    <div id="wave">
        <!-- Nomes dos usuários -->
        <div id="topBar">Marcio Junior, Breno Silva e Pires, Thiago Vieira de Alcântara Silva</div>
        <!-- -->
        <div id="subBar">
            <img src="../Componentes/BuscaImagens.ashx?id=50062f4a6fa6d20644000019" alt="Marcio Junio" />
            <img src="../Componentes/BuscaImagens.ashx?id=1" alt="Breno Silva e Pires" />
            <img src="../Componentes/BuscaImagens.ashx?id=1" alt="Thiago Vieira de Alcântara Silva" />
        </div>
        <!-- Slide que mostra/esconde as mensagens -->
        <div id="sliderContainer">
            <div id="slider"></div>
        </div>
        <div id="commentArea">
            <!-- comentários -->
        </div>
        <input type="button" class="button save" id="waveButtonMain" value="Add a comment" onclick="addComment()" />
        <footer id="bottomBar"></footer>
    </div>
</asp:Content>
