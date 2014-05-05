$(document).ready(function () {
    $('#<%= salvar.ClientID %>').click(function () {
        var punicao = $('#<%= CbmPunicao.ClientID %>').val();
        var resposta = $('#resposta').val();

        atualizaDenuncias(punicao, resposta);

        $('#sair').trigger('click');
        alert("Denuncia Atendida com sucesso!");
    })
})