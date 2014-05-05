<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmaFinalizar.aspx.cs" Inherits="UI.User.ConfirmaFinalizar" %>

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
                    url: "ConfirmaFinalizar.aspx/finalizarServico",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (resp) {
                        $("#fechar").trigger("click");
                        $(window.document.location).attr('href', 'avaliar.aspx?id=' + resp.d);
                    }
                });
            });
        });
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="tudo">
        <div id="cabecalho">
            <label class="titulo">
                Confirma a Finalização de Serviço</label>
            <a id="fechar" href="#" rel="modalclose">
                <img src="../Styles/img/icon_close.png" class="fechar" alt="Fechar" /></a>
        </div>
        <div id="corpo">
            <br />
            <label class="labelCadServ">
                Deseja realmente finalizar serviço?</label>
            <br />
            <br />
            <br />
            <div style="text-align: right; margin-right: 5px;">
                <a href="#" id="btnAdd" class="btn">Finalizar</a>
                <a href="#" id="btnCancel" rel="modalclose" class="btn">Cancelar</a>
            </div>
            <br />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
