<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SocilicarOrcamento.aspx.cs"
    Inherits="UI.User.SocilicarOrcamento" %>

<!DOCTYPE html>
<html lang="pt-br">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Forms.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/LightBox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= btnOrcamento.ClientID %>").click(function () {
                var idServico = $('#<%= ddlServicos.ClientID %>').val();
                var prioridade = $('#<%= ddlPrioridade.ClientID %>').val();
                var validade = true;

                var quantidade = $('#txtPreco').val();
                if (quantidade <= 0 || quantidade == '') {
                    validade = false;
                    $('#txtPreco').css({ 'border': '1px solid red', 'background-color': '#FF6666' });
                    $('#squantidade').text('Campo de quantidade não pode ser vazio');
                } else {
                    $('#txtPreco').css({ 'border': '1px solid gray', 'background-color': '#FFFFFF' });
                    $('#squantidade').text('');
                }

                var descricao = $('#txtDescricao').val();
                var regex = /^[a-zA-Z0-9 áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ]{1,400}$/;
                if (descricao == '') {
                    validade = false;
                    $('#txtDescricao').css({ 'border': '1px solid red', 'background-color': '#FF6666' });
                    $('#sdesc').text('Campo de descrição não pode ser vazio');
                } else {
                    $('#txtDescricao').css({ 'border': '1px solid gray', 'background-color': '#FFFFFF' });
                    $('#sdesc').text('');
                }

                if (validade) {

                    //This disgrace will now work, son of a bitch
                    descricao = $('#txtDescricao').val();
                    quantidade = $('#txtPreco').val();

                    $.ajax({
                        type: 'POST',
                        url: 'Perfil.aspx/AdicionaSolicitacao',
                        data: "{'assunto':'Orçamento', 'descricao':'" + descricao + "', 'prioridade':'" + prioridade + "', 'idServico':'" + idServico + "', 'qtdContratada':'" + quantidade + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (link) {
                            //alert("FOI!");
                            $.colorbox.close();
                        }
                    });
                }
            });
        });    

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tudo">
        <h1><i class='icon-credit-card'></i>Solicitar Orçamento</h1>
        <p id="formNet3s">
            <label>Serviço:</label>
            <asp:DropDownList ID="ddlServicos" runat="server" autofocus TabIndex="1">
            </asp:DropDownList>  
            <a href="../Help/servicoOrcamentoHelp.html" id="help1" class="jTip" name="Selecionar Serviço:">?</a>
            <label>Prioridade:</label>
            <asp:DropDownList ID="ddlPrioridade" runat="server" CssClass="camposOption" TabIndex="2">
                <asp:ListItem Value="0">Baixa</asp:ListItem>
                <asp:ListItem Value="1">Média</asp:ListItem>
                <asp:ListItem Value="2">Alta</asp:ListItem>
                <asp:ListItem Value="3">Urgente</asp:ListItem>
            </asp:DropDownList>
            <a href="../Help/prioridadeOrcamentoHelp.html" id="help2" class="jTip" name="Prioridade:">?</a>
            <label>Quantidade Contratada:</label>
            <input type="text" id="txtPreco" TabIndex="3" placeholder="Quantidade a ser contratada por unidade de medida"/>
            <a href="../Help/qtdContratadaOrcamentoHelp.html?width=360" id="help3" class="jTip" name="Quantidade Contratada:">?</a>
            <label>Descrição da atividade:</label>
            <textarea rows="4" cols="30" id="txtDescricao" TabIndex="4" placeholder="Descrição do trabalho a ser desenvolvido pelo prestador do serviço"></textarea>
            <a href="../Help/descricaoOrcamentoHelp.html?width=360" id="A3" class="jTip" name="Descrição:">?</a>
            <br />
            <br />
            <section id="btn">
                <asp:LinkButton ID="btnOrcamento" runat="server" CssClass="button money" TabIndex="5">Solicitar</asp:LinkButton>
            </section>
        </p>
    </div>
    </form>
</body>
</html>
