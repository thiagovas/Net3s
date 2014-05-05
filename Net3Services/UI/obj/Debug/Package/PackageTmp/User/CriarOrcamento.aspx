<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriarOrcamento.aspx.cs"
    Inherits="UI.User.CriarOrcamento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html lang="pt-br">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="utf-8" />
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/Forms.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/LightBox.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../Styles/font-awesome.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <!-- Não sei porque, mais tava travando o jQuery
    <script type="text/javascript" src="../Scripts/editarServico.js"></script>
    -->
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#txtDataInicio").mask("99/99/9999");
            //$("#txtDataFim").mask("99/99/9999");

            $("#salv").click(function () {
                var dataInicio = $("#txtDataInicio").val();
                var dataFim = $("#txtDataFim").val();
                var preco = $("#txtPreco").val();
                var descricao = $("#txtDescricao").val();

                $.ajax({
                    type: "POST",
                    url: "AprovarOrcamento.aspx/CriarOrcamento",
                    data: "{'dataInicio':'" + dataInicio + "', 'dataFim':'" + dataFim + "', 'preco':'" + preco.toString() + "', 'descricao':'" + descricao + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var mensagem = msg.d;
                        
                        if (mensagem == "Orçamento foi criado com sucesso!") {
                            ("#fechar").trigger("click");
                            //fecha a parada de modo correto
                            //$.colorbox.close();
                        }
                        else {
                            enviarAlerta(mensagem);
                        }
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="frmOrcamento" runat="server">
    <div id="tudo">
        <h1><i class='icon-money'></i>Criar Orçamento</h1>
        <p id="formNet3s">
            <label>Data de Inicio:</label>
            <input type="date" id="txtDataInicio" maxlength="10" value="" autofocus placeholder="Data de previsão do inicio da prestação do serviço" />
            <label>Data do Fim:</label>
            <input type="date" id="txtDataFim" maxlength="10" placeholder="Data de previsão do fim da prestação do serviço" />
            <br />
            <label>Preço:</label>
            <input type="number" id="txtPreco" maxlength="7" placeholder="Valor a ser cobrado pelo serviço"  />
            <br />
            <label>Descrição:</label>
            <textarea id="txtDescricao" rows="10" cols="10" placeholder="Descrição dos pormenores do orçamento. Ex: métodos de trabalho, tipo de ferramentas utlizadas, etc..."></textarea>
            <br />
            <br />
            <section id="btn">
                <a href="#" id="salv" class="button save"><span>Salvar</span></a>
            </section>
        </p>
    </div>
    </form>
</body>
</html>
