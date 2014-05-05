<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarPremio.aspx.cs" Inherits="UI.User.EditarPremio" %>

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
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= txtDataPre.ClientID %>').mask("99/99/9999");

            $("#btnSalvar").click(function () {
                var validade = true;
                validade = $('#<%= txtNomeInstPre.ClientID %>').validarNome();

                if (validade)
                    validade = $('#<%= txtNomePremio.ClientID %>').validarNome();
                else
                    $('#<%= txtNomePremio.ClientID %>').validarNome();

                if (validade)
                    validade = $('#<%= txtDataPre.ClientID %>').validarData();
                else
                    $('#<%= txtDataPre.ClientID %>').validarData();

                if (validade)
                    validade = $('#<%= txtDescPre.ClientID %>').validarDescricao();
                else
                    $('#<%= txtDescPre.ClientID %>').validarDescricao();

                if (validade == true) {
                    var id = $("#valId").val();
                    var index = $("#valIndex").val();
                    var data = $('#<%= txtDataPre.ClientID %>').val();
                    var nome = $('#<%= txtNomePremio.ClientID %>').val();
                    var descricao = $('#<%= txtDescPre.ClientID %>').val();
                    var instituicao = $('#<%= txtNomeInstPre.ClientID %>').val();
                    
                    $.ajax({
                        type: "POST",
                        url: "EditarPremio.aspx/Editar",
                        data: "{'id':'" + id + "', 'index': '" + index + "','nome':'" + nome + "','instituicao':'" + instituicao + "','descricao':'" + descricao + "','data':'" + data + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            var mensagem = msg.d;

                            if (mensagem == "Idioma editado com sucesso.") {
                                parent.$.fn.colorbox.close();
                                enviarAlerta(mensagem);
                            }
                            else {
                                enviarAlerta(mensagem);
                            }
                        }
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="formEditar" runat="server">
        <input type="hidden" id="valIndex" value="<%= this.index %>" />
        <input type="hidden" id="valId" value="<%= this.id %>" />
        <div id="tudo">
            <h1><i class='icon-edit'></i>Editar Prêmio</h1>
            <p id="formNet3s">
                <label>Nome Instituição:</label>
                <asp:TextBox ID="txtNomeInstPre" runat="server" placeholder="Nome da instituição que concedeu o prêmio" TabIndex="1"></asp:TextBox>
                <label>Nome do Prêmio:</label>
                <asp:TextBox ID="txtNomePremio" runat="server" placeholder="Nome do prêmio recebido" TabIndex="2"></asp:TextBox>
                <label>Data de Expedicao:</label>
                <asp:TextBox ID="txtDataPre" runat="server" placeholder="Data de expedição do prêmio" TabIndex="3"></asp:TextBox>
                <label>Descrição:</label>
                <asp:TextBox ID="txtDescPre" runat="server" TextMode="MultiLine" MaxLength="400" TabIndex="4" placeholder="Insira uma breve descrição sobre as atividades realizadas para conquista do prêmio" />
                <br /><br />
                <a id="btnSalvar" class="button save" href="#" TabIndex="5">Salvar</a>
                <label id="msgErro"></label>
            </p>    
        </div>
    </form>
</body>
</html>
