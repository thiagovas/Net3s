<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarServico.aspx.cs"
    Inherits="UI.User.EditarServico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Forms.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/LightBox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/editarServico.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
</head>
<body>
    <form id="formEditar" runat="server">
    <div id="tudo">
        <h1><i class='icon-edit'></i>Editar Serviço</h1>
        <p id="formNet3s">
            <label>
                Nome do Serviço:</label>
            <input type="text" id="txtNome" class="campos" maxlength="40" value="<%= this.nomeServico %>"
                tabindex="1" autofocus placeholder="Informe o nome do serviço" />
            <a href="../Help/nomeServicoHelp.html?width=360" id="help1" class="jTip" name="Nome do Serviço:">
                ?</a>
            <label>
                Preço:</label>
            <input type="text" id="txtPreco" class="campos" maxlength="9" value="<%= this.precoServico %>"
                tabindex="2" placeholder="Infome o preço a ser cobrado pelo serviço" />
            <a href="../Help/precoServicoHelp.html?width=360" id="help2" class="jTip" name="Preço do Serviço:">
                ?</a>
            <label>
                Uni. Medida:</label>
            <asp:DropDownList ID="ddlUnidadeMed" runat="server" TabIndex="3">
                <asp:ListItem Value="Alqueire">Alqueire</asp:ListItem>
                <asp:ListItem Value="Ano">Ano</asp:ListItem>
                <asp:ListItem Value="Are">Are</asp:ListItem>
                <asp:ListItem Value="Arroba">Arroba</asp:ListItem>
                <asp:ListItem Value="Caixa">Caixa</asp:ListItem>
                <asp:ListItem Value="Centímetro">Cent&#237;metro linear</asp:ListItem>
                <asp:ListItem Value="Centímetro²">Cent&#237;metro&#178;</asp:ListItem>
                <asp:ListItem Value="Centímetro³">Cent&#237;metro&#179;</asp:ListItem>
                <asp:ListItem Value="Decímetro">Dec&#226;metro</asp:ListItem>
                <asp:ListItem Value="Decigrama">Decigrama</asp:ListItem>
                <asp:ListItem Value="Decâmetro">Dec&#237;metro</asp:ListItem>
                <asp:ListItem Value="Dia">Dia</asp:ListItem>
                <asp:ListItem Value="Empreitada">Empreitada</asp:ListItem>
                <asp:ListItem Value="Galão">Gal&#227;o</asp:ListItem>
                <asp:ListItem Value="Grama">Grama</asp:ListItem>
                <asp:ListItem Value="Grão metrico">Gr&#227;o metrico</asp:ListItem>
                <asp:ListItem Value="Fardo">Fardo</asp:ListItem>
                <asp:ListItem Value="Hectare">Hectare</asp:ListItem>
                <asp:ListItem Value="Hectômetro">Hect&#244;metro</asp:ListItem>
                <asp:ListItem Value="Hora">Hora</asp:ListItem>
                <asp:ListItem Value="Jardas">Jardas</asp:ListItem>
                <asp:ListItem Value="Léguas">L&#233;guas</asp:ListItem>
                <asp:ListItem Value="Libras">Libras</asp:ListItem>
                <asp:ListItem Value="Mês">M&#234;s</asp:ListItem>
                <asp:ListItem Value="Metro linea">Metro linear</asp:ListItem>
                <asp:ListItem Value="Metro²">Metro&#178;</asp:ListItem>
                <asp:ListItem Value="Metro³">Metro&#179;</asp:ListItem>
                <asp:ListItem Value="Miligrama">Miligrama</asp:ListItem>
                <asp:ListItem Value="Milhas">Milhas</asp:ListItem>
                <asp:ListItem Value="Milimetro">Milimetro</asp:ListItem>
                <asp:ListItem Value="Minuto">Minuto</asp:ListItem>
                <asp:ListItem Value="Onça">On&#231;a</asp:ListItem>
                <asp:ListItem Value="Pés">P&#233;s</asp:ListItem>
                <asp:ListItem Value="Polegadas">Polegadas</asp:ListItem>
                <asp:ListItem Value="Polegadas²">Polegadas&#178;</asp:ListItem>
                <asp:ListItem Value="Quilate">Quilate</asp:ListItem>
                <asp:ListItem Value="Quilograma">Quilograma</asp:ListItem>
                <asp:ListItem Value="Quilometro linear">Quilometro linear</asp:ListItem>
                <asp:ListItem Value="Quilômetro²">Quil&#244;metro&#178;</asp:ListItem>
                <asp:ListItem Value="Semana">Semana</asp:ListItem>
                <asp:ListItem Value="Tonel">Tonel</asp:ListItem>
                <asp:ListItem Value="Tonelada">Tonelada</asp:ListItem>
                <asp:ListItem Value="Unidade">Unidade</asp:ListItem>
            </asp:DropDownList>
            <a href="../Help/uniMedServicoHelp.html?width=360" id="help4" class="jTip" name="Unidade de Medida:">
                ?</a>
            <label>
                Categoria:</label>
            <asp:DropDownList ID="ddlCategoria" runat="server" TabIndex="4">
            </asp:DropDownList>
            <a href="../Help/categoriaServicoHelp.html?width=360" id="help5" class="jTip" name="Categoria:">
                ?</a>
            <label>
                Regional:</label>
            <asp:RadioButton ID="rbSim" runat="server" Text="Sim" GroupName="Regional" TabIndex="5" />
            <asp:RadioButton ID="rbNao" runat="server" Text="Não" GroupName="Regional" TabIndex="6" />
            <a href="../Help/regionalServicoHelp.html?width=360" id="A1" class="jTip" name="Serviço Regional:">
                ?</a>
            <label>
                Nivel Regionalidade:</label>
            <asp:DropDownList ID="ddlNivelRegionalidade" runat="server" TabIndex="7">
                <asp:ListItem>País</asp:ListItem>
                <asp:ListItem>Estado</asp:ListItem>
                <asp:ListItem>Cidade</asp:ListItem>
            </asp:DropDownList>
            <a href="../Help/nivelRegServicoHelp.html?width=360" id="help7" class="jTip" name="Nivel de Regionalidade:">
                ?</a>
            <label>
                Descrição:</label>
            <textarea id="txtDescricao" rows="10" cols="10" tabindex="8"><%= this.descricao %></textarea>
            <a href="../Help/descricaoServicoHelp.html?width=360" id="help8" class="jTip" name="Descrição do Serviço:" placeholder="Insira uma breve descrição sobre o serviço">
                ?</a>
            <br />
            <br />
            <section id="btn">
                <a href="#" id="linkBtnSalvar" class="button save">Salvar</a>
            </section>
            <label id='msgErro'>
            </label>
        </p>
    </div>
    </form>
</body>
</html>
