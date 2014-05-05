<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Avaliacao.aspx.cs" Inherits="UI.User.Avaliacao" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Avaliacao.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/MasterPage.css" rel="stylesheet" type="text/css" media="screen" />
    <link href='http://fonts.googleapis.com/css?family=Rokkitt:400,700|Salsa' rel='stylesheet'
        type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
    <div id="tudo">
        <div id="cabecalho">
            <label class="titulo">
                Avaliar Serviço</label>
            <a id="fechar" href="#" rel="modalclose">
                <img src="../Styles/img/icon_close.png" class="fechar" alt="Fechar" /></a>
        </div>
        <div id="corpo">
            <asp:UpdatePanel ID="upAvaliacao" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="panelContratante" runat="server" Visible="false">
                        <div id="avaliContratante">
                            <label>
                                Preço:</label>
                            <asp:Rating ID="ratPreco" runat="server" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar"
                                WaitingStarCssClass="savedRatingStar" StarCssClass="ratingStar" ReadOnly="false" />
                            <br />
                            <br />
                            <label>
                                Tempo de Execução:</label>
                            <asp:Rating ID="ratTempo" runat="server" FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar"
                                WaitingStarCssClass="savedRatingStar" StarCssClass="ratingStar" ReadOnly="false" />
                            <br />
                            <br />
                            <label>
                                Qualidade do Serviço:</label>
                            <asp:Rating ID="ratQualidade" runat="server" FilledStarCssClass="filledRatingStar"
                                EmptyStarCssClass="emptyRatingStar" WaitingStarCssClass="savedRatingStar" StarCssClass="ratingStar"
                                ReadOnly="false" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelPrestador" runat="server" Visible="false">
                        <div id="avaliPrestador">
                            <label>
                                Pagamento:</label>
                            <asp:Rating ID="ratPagamento" runat="server" FilledStarCssClass="filledRatingStar"
                                EmptyStarCssClass="emptyRatingStar" WaitingStarCssClass="savedRatingStar" StarCssClass="ratingStar"
                                ReadOnly="false" />
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:Button ID="btnAvaliar" runat="server" Text="Avaliar" CssClass="btn" OnClick="btnAvaliar_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
