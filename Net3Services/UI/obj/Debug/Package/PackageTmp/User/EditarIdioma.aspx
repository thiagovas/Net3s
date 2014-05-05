<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarIdioma.aspx.cs" Inherits="UI.User.EditarIdioma" %>

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
    <script type="text/javascript" src="../Scripts/Plugins-full.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnSalvar").click(function () {

                var validade = true;
                validade = $('#<%= txtNomeIdioma.ClientID %>').validarNome();
                
                if (validade == true) {
                    var id = $("#valId").val();
                    var index = $("#valIndex").val();
                    var fluencia = $('#<%= ddlFluencia.ClientID %>').val();
                    var nomeIdioma = $('#<%= txtNomeIdioma.ClientID %>').val();
                    
                    $.ajax({
                        type: "POST",
                        url: "EditarIdioma.aspx/Editar",
                        data: "{'id':'" + id + "', 'index': '" + index + "','nomeIdioma':'" + nomeIdioma + "','fluencia':'" + fluencia + "'}",
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
            <h1><i class='icon-edit'></i>Editar Idioma</h1>
            <p id="formNet3s">
                <label>Nome Idioma:</label>
                <asp:TextBox ID="txtNomeIdioma" runat="server" autofocus TabIndex="1" placeholder="Informe o nome do idioma"></asp:TextBox>
                <label>Fluência:</label>
                <asp:DropDownList ID="ddlFluencia" runat="server" TabIndex="2">
                    <asp:ListItem Value="Iniciante">Iniciante</asp:ListItem>
                    <asp:ListItem Value="Intermerdiario">Intermerdiário</asp:ListItem>
                    <asp:ListItem Value="Avancado">Avançado</asp:ListItem>
                    <asp:ListItem Value="Fluente">Fluente</asp:ListItem>
                    <asp:ListItem Value="Nativo">Nativo</asp:ListItem>
                </asp:DropDownList>
                <br /><br />
                <a id="btnSalvar" class="button save" href="#" TabIndex="3">Salvar</a>
                <label id="msgErro"></label>
            </p>    
        </div>
    </form>
</body>
</html>
