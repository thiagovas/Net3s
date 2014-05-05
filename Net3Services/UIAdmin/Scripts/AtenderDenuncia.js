$(document).ready(function () {
    $('a#ImgAcu').click(function () {
        window.open("www.net3s.com.br/user/perfil.aspx?id=" + IidDenum.val());
    });
    $('a#salvar').click(function () {
        var punicao = $('#punicao').val();
        var resp = $('#resposta').val();
        var idDenum = $('#IidDenum').val();

        //verificações
        if (punicao != "") {
            if (resp != "") {
                $.ajax({
                    type: "POST",
                    data: "{'punicao':'" + punicao + "','resposta':'" + resp + "','idDenum':'" + idDenum + "'}",
                    url: "AtenderDenuncia.aspx/atualizaDenuncias",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (resposta) {
                        //fecha o light box
                        $('a#fechar').trigger('click');
                        //Alerta que a denuncia foi atendida
                        if (resposta.d == "ok")
                            alert("Denuncia atendida com sucesso!");
                        //se não mostra o erro que retornou
                        else
                            alert(resposta.d);
                    }
                });
            } else { alert("preencha a resposta!"); }
        } else { alert("preencha a punição!"); }
    });
});