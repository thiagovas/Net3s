<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfContato.aspx.cs" Inherits="UI.User.ConfContato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../Styles/MasterPage.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Network.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnAdd').click(function () {
                $.ajax({
                    type: "POST",
                    url: "Perfil.aspx/AdicionaNetwork",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {
                        $("#fechar").trigger("click");
                    }
                });
            });
        });

    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tudo">
        <div id="cabecalho">
            <label class="titulo">
                Confirmação da Solicitação de Contato</label>
            <a id="fechar" href="#" rel="modalclose">
                <img src="../Styles/img/icon_close.png" class="fechar" alt="Fechar" /></a>
        </div>
        <div id="corpo">
            <br />
            <label class="labelCadServ">
                Deseja realmente adicionar este usuário ao seu network?</label>
            <br />
            <br />
            <div style="text-align: right; margin-right: 5px;">
                <a href="#" id="btnAdd" class="btn">Adicionar</a>
                <a href="#" id="btnCancel" rel="modalclose" class="btn">Cancelar</a>
            </div>
            <br />
            </div>
        </div>
    </form>
</body>
</html>
