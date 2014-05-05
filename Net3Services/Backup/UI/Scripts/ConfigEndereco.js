$(document).ready(function () {
    $("#txtCep").mask("99999-999");

    $("#btnSalvar").click(function () {
        var validade = true;
        validade = $("#txtRua").validarNome();

        if (validade == true) {
            validade = $("#txtNumero").validarNumero();
        }
        else {
            validade = $("#txtNumero").validarNumero();
        }

        if (validade == true) {
            validade = $("#txtComplemento").validarNumero();
        }
        else {
            validade = $("#txtComplemento").validarNumero();
        }

        if (validade == true) {
            validade = $("#txtBairro").validarNome();
        }
        else {
            $("#txtBairro").validarNome();
        }

        if (validade == true) {

            var id = $("#idUsu").val();
            var cep = $("#txtCep").val();
            var rua = $("#txtRua").val();
            var bairro = $("#txtBairro").val();
            var numero = $("#txtNumero").val();
            var comple = $("#txtComplemento").val();
            var pais = $("#<%= ddlPais.ClientID  %>").val();
            var estado = $("#<%= ddlEstado.ClientID  %>").val();
            var cidade = $("#<%= ddlCidade.ClientID  %>").val();

            $.ajax({
                type: "POST",
                url: "ConfigEndereco.aspx/EditarEndereco",
                data: "{'id':'" + id + "', 'cep':'" + cep + "', 'bairro':'" + bairro + "', 'rua':'" + rua + "', 'numero':'" + numero + "', 'comple':'" + comple + "', 'pais':'" + pais + "', 'estado':'" + estado + "', 'cidade':'" + cidade + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var mensagem = msg.d;
                    enviarAlerta(mensagem);
                    if (mensagem == "Seu perfil foi atualizado com sucesso.") {
                        $("#<%= atualizaSessao.ClientID %>").trigger("click");
                    }
                }
            });
        }
    });

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        $("#txtCep").mask("99999-999");

        $("#btnSalvar").click(function () {
            var validade = true;
            validade = $("#txtRua").validarNome();

            if (validade == true) {
                validade = $("#txtNumero").validarNumero();
            }
            else {
                validade = $("#txtNumero").validarNumero();
            }

            if (validade == true) {
                validade = $("#txtComplemento").validarNumero();
            }
            else {
                validade = $("#txtComplemento").validarNumero();
            }

            if (validade == true) {
                validade = $("#txtBairro").validarNome();
            }
            else {
                $("#txtBairro").validarNome();
            }

            if (validade == true) {

                var id = $("#idUsu").val();
                var cep = $("#txtCep").val();
                var rua = $("#txtRua").val();
                var bairro = $("#txtBairro").val();
                var numero = $("#txtNumero").val();
                var comple = $("#txtComplemento").val();
                var pais = $("#<%= ddlPais.ClientID  %>").val();
                var estado = $("#<%= ddlEstado.ClientID  %>").val();
                var cidade = $("#<%= ddlCidade.ClientID  %>").val();

                $.ajax({
                    type: "POST",
                    url: "ConfigEndereco.aspx/EditarEndereco",
                    data: "{'id':'" + id + "', 'cep':'" + cep + "', 'bairro':'" + bairro + "', 'rua':'" + rua + "', 'numero':'" + numero + "', 'comple':'" + comple + "', 'pais':'" + pais + "', 'estado':'" + estado + "', 'cidade':'" + cidade + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var mensagem = msg.d;
                        enviarAlerta(mensagem);
                        if (mensagem == "Seu perfil foi atualizado com sucesso.") {
                            $("#<%= atualizaSessao.ClientID %>").trigger("click");
                        }
                    }
                });
            }
        });
    });
});