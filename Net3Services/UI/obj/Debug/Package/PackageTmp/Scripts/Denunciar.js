$(document).ready(function () {
    var idDenunciado = getUrlVars()["id"];
    
    $('a#reportarAbuso').modal({
        url: 'Denunciar.aspx?id=' + idDenunciado,
        data: "{}",
        closeClickOut: false,
        autoRefresh: false,
        closeEsc: false
    });

    $('a#btnSalvar').click(function () {
        var tipoDenuncia = parseInt($('input:radio[name=tipo]:checked').val());
        var descricao = $("#txtDescricao").val();

        $.ajax({
            type: "POST",
            url: "Denunciar.aspx/DenunciarUsuario",
            data: "{'tipoDenuncia':'" + tipoDenuncia + "','descricao':'" + descricao + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (dados) {
                // Fecha a tela
                $("#fechar").trigger("click");
                var resposta = dados.d;
                // Mostra a mensagem retornada ao usuário
                enviarAlerta(resposta);
            }
        });
    });

});