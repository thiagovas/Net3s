<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Denunciar.aspx.cs" Inherits="UI.User.Denunciar" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Denunciar.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/MasterPage.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/ValidacoesN3S.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tudo">
        <div id="cabecalho">
            <label class="titulo">
                Reportar Abuso</label>
            <a id="fechar" href="#" rel="modalclose">
                <img src="../Styles/img/icon_close.png" class="fechar" alt="Fechar" /></a>
        </div>
        <div id="corpo">
            Tipo da denuncia:
            <br />
            <input type="radio" name="tipo" value="0" checked="checked" />Foto inadequada no perfil
            <br />
            <input type="radio" name="tipo" value="1" />Serviços inadequados
            <br />
            <input type="radio" name="tipo" value="2" />Conteúdo indevido
            <br />
            <input type="radio" name="tipo" value="3" />Span
            <br />
            <input type="radio" name="tipo" value="4" />Conteúdo ilegal
            <br />
            <input type="radio" name="tipo" value="5" />Conteúdo pornográfico
            <br />
            <input type="radio" name="tipo" value="6" />Outros
            <br /><br />
            Descrição:
            <br />
            <textarea id="txtDescricao" name="descricao" rows="5" class="camposMultiLine" cols="40"></textarea>
            <br /><br /><br /><br /><br />
            <p>
                <a id="btnSalvar" class="btn" href="#">Salvar</a>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
