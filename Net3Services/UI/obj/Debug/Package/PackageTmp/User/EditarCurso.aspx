<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarCurso.aspx.cs" Inherits="UI.User.EditarCurso" %>

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
        $("#btnSalvar").click(function () {
            var validade = true;
            var id = $("#valId").val();
            var index = $("#valIndex").val();
            var nome = $("#txtNomeCurso").val();
            var dataFim = $("#txtDataTermino").val();
            var dataInicio = $("#txtDataInicio").val();
            var nomeInstituicao = $("#txtNomeInstiruicao").val();

            if (validade == true) {
                $.ajax({
                    type: "POST",
                    url: "EditarCurso.aspx/Editar",
                    data: "{'id':'" + id + "', 'index': '" + index + "','nome':'"+nome+"','nomeInstituicao':'"+nomeInstituicao+"','dataInicio':'"+dataInicio+"','dataFim':'"+dataFim+"'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var mensagem = msg.d;

                        if (mensagem == "Curso excluido com sucesso.") {
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
    </script>
</head>
<body>
    <input type="hidden" id="valIndex" value="<%= this.index %>" />
    <input type="hidden" id="valId" value="<%= this.id %>" />
    <form id="formEditar" runat="server">
        <div id="tudo">
            <h1><i class='icon-edit'></i>Editar Curso</h1>
            <p id="formNet3s">
                <label>Nome Curso:</label>
                <input type="text" id="txtNomeCurso" value="<%= this.nomeCurso %>" />
                <label>Nome Instituição:</label>
                <input type="text" id="txtNomeInstiruicao" value="<%= this.nomeInstituicao %>" />
                <label>Data de Inicio:</label>
                <input type="text" id="txtDataInicio" value="<%= this.dataInicio %>" />
                <label>Data de Termino:</label>
                <input type="text" id="txtDataTermino" value="<%= this.dataFim %>" />
                <br /><br />
                <a id="btnSalvar" class="button save" href="#">Salvar</a>
            </p>    
        </div>
    </form>
</body>
</html>
