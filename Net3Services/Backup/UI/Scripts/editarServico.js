$(document).ready(function () {
    $('#<%= rbSim.ClientID  %>').click(function (e) {
        var ddlRegionalidade = $('#<%= ddlNivelRegionalidade.ClientID %>');

        if (this.checked) {
            ddlRegionalidade.removeAttr('disabled');
        }
    });

    $('#<%= rbNao.ClientID  %>').click(function (e) {
        var ddlRegionalidade = $('#<%= ddlNivelRegionalidade.ClientID %>');

        if (this.checked) {
            ddlRegionalidade.attr('disabled', true);
        }
    });

    $("#linkBtnSalvar").click(function () {
        var validade = true;
        validade = $("#txtNome").validarNome();

        if (validade)
            validade = $("#txtPreco").validarNumero();
        else
            $("#txtPreco").validarNumero();

        if (validade)
            validade = $("#txtDescricao").validarDescricao();
        else
            $("#txtDescricao").validarDescricao();

        if (validade) {
            var descricao = $("#txtDescricao").val();
            var nomeServ = $("#txtNome").val();
            var preco = parseFloat($("#txtPreco").val());
            var uniMedida = $("#<%= ddlUnidadeMed.ClientID %>").val();
            var categoria = $("#<%= ddlCategoria.ClientID %>").val();

            var regional = $("#<%= rbSim.ClientID %>").is(':checked');
            var nivelRegionalidade = "";

            if (regional == true) {
                nivelRegionalidade = $("#<%= ddlNivelRegionalidade.ClientID %>").val();
            }

            $.ajax({
                type: "POST",
                url: "VisualizarServico.aspx/Editar",
                data: "{'descricao':'" + descricao + "','nivelRegionalidade':'" + nivelRegionalidade + "','nomeServ':'" + nomeServ + "','preco':'" + preco.toString() + "','regional':'" + regional + "','uniMedida':'" + uniMedida + "','categoria':'" + categoria + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var mensagem = msg.d;

                    if (mensagem == "Serviço editado com sucesso.") {
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