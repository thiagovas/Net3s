$(document).ready(function () {
    $("#btnSalvar").click(function () {
        var nome = $("#txtNome").val();
        var site = $("#txtSite").val();
        var email = $("#txtEmail").val();
        var genero = $('#<%= cmbSexo.ClientID  %>').val();

        var cpf = $("#txtCpf").val();
        var rg = $("#txtRg").val();
        var dataNasc = $("#txtDataNasc").val();
        var telUm = $("#txtTelefone1").val();
        var telDois = $("#txtTelefone2").val();
        var celUm = $("#txtCel1").val();
        var celDois = $("#txtCel2").val();

        $.ajax({
            type: "POST",
            url: "Perfil.aspx/EditarUser",
            data: "{'nome':'" + nome + "','site':'" + site + "','email':'" + email + "','genero':'" + genero + "','cpf':'" + cpf + "','rg':'" + rg + "','dataNasc':'" + dataNasc + "','telUm':'" + telUm + "','telDois':'" + telDois + "','celUm':'" + celUm + "','celDois':'" + celDois + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var mensagem = msg.d;
                enviarAlerta(mensagem);

                if (mensagem == "Perfil editado com sucesso.") {
                    $("#fechar").trigger("click");
                }
            }
        });
    });

});