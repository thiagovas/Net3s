<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtenderDenuncia.aspx.cs"
    Inherits="UIAdmin.Admin.AtenderDenuncia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../Styles/Botoes.css" type="text/css" />
    <link rel="Stylesheet" href="../Styles/MasterAdm.css" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/AtenderDenuncia.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tudo">
        <div id="cabecalho">
            <label class="titulo">Atender Denuncia</label>
            <a id="fechar" href="#" rel="modalclose"><img src="../Styles/img/icon_close.png" class="fechar" alt="Fechar" /></a>
        </div>
        <div id="corpo">
            <!--Gambiarra suprema-->
            <input type="hidden" id="IidDenum" value="<%= this.idDenunc%>" />
            <!--fim da gambiarra-->
            <label>
                Tipo da denuncia:
            </label>
            <asp:Label ID="LblTipoDenuncia" runat="server"></asp:Label><br />
            <br />
            <label>
                Denunciante:
            </label>
            <img src="BuscaImagens.ashx?id=<%= this.idDenum %>" class="imagem" alt="" />&nbsp;
            &nbsp;
            <label>
                Denunciado:
            </label>
            <a id="ImgAcu">
                <img src="BuscaImagens.ashx?id=<%= this.idAcu %>" class="imagem" alt="" />
            </a>&nbsp;<br />
            <label>
                Desccrição:
            </label>
            <textarea id="descricao" rows="5" cols="50" disabled="disabled"><%= this.descDenum %></textarea><br />
            <br />
            <label id="pinto">
                Punição:
            </label>
            <select id="punicao">
                <option value="">Selecione</option>
                <option value="Afastar">Afastar</option>
                <option value="Banir">Banir</option>
                <option value="Inocentar">Inocentar</option>
            </select>
            <br />
            <label>
                Resposta:
            </label>
            <textarea id="resposta" rows="5" cols="50"></textarea><br />
            <p>
                <a id="salvar" class="btn"><span>Salvar</span></a>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
