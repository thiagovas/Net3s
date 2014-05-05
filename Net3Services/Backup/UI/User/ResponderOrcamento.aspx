<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResponderOrcamento.aspx.cs" Inherits="UI.User.ResponderOrcamento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/ValidacoesN3S.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/MasterPage.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Servico.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/editarServico.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#contratar').click(function () {
                $.ajax({
                    type: "POST",
                    url: "ResponderOrcamento.aspx/ResponderOrc",
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
</head>
<body>
    <form id="frmResposta" runat="server">
   <div id="tudo">
        <div id="cabecalho">
            <label class="titulo">
                Responder Orçamento</label>
            <a id="A1" href="#" rel="modalclose">
                <img src="../Styles/img/icon_close.png" class="fechar" alt="Fechar" /></a>
        </div>
        <div id="corpo">
            <label class="labelOrc">Serviço:</label>&nbsp;<asp:Label ID="lblServ" runat="server" CssClass="labelRespOrc"></asp:Label>
            <br />
            <br />
            <label class="labelOrc">Prestador do Serviço:</label>&nbsp;<asp:Label ID="lblPrest" runat="server" CssClass="labelRespOrc"></asp:Label>
            <br />
            <br />
            <label class="labelOrc">Contratante:</label>&nbsp;<asp:Label ID="lblContrat" runat="server" CssClass="labelRespOrc"></asp:Label>
            <br />
            <br />
            <label class="labelOrc">Data de Inicio do Orçamento:</label>&nbsp;<asp:Label ID="lblDataIni" runat="server" CssClass="labelRespOrc"></asp:Label>
            <br />
            <br />
            <label class="labelOrc">Data de Fim:</label>&nbsp;<asp:Label ID="lblDataFim" runat="server" CssClass="labelRespOrc"></asp:Label>
            <br />
            <br />
            <label class="labelOrc">Descrição:</label>&nbsp;<asp:Label ID="lblDesc" runat="server" CssClass="labelRespOrc"></asp:Label>
            <br />
            <br />
            <label class="labelOrc">Preço:</label>&nbsp;<asp:Label ID="lblPreco" runat="server" CssClass="labelRespOrc"></asp:Label>
            <br />
            <br />
            <div style="text-align: right">
                 <a id="editar" class="btn">Responder</a>
                 <a id="fechar" class="btn" rel="modalclose">Cancelar</a>
             </div>
            <br />
        </div>
    </div>
    </form>
</body>
</html>
