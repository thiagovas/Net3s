$(document).ready(function () {
    $('*[id$=TxtNome]').blur(function () {
        if ($(this).val() != "") {
            $(this).css('border', '');
        }
    })
    $('*[id$=TxtLogin]').blur(function () {
        if ($(this).val() != "") {
            $(this).css('border', '');
        }
    })
    $('*[id$=TxtSenha]').blur(function () {
        if ($(this).val() != "") {
            $(this).css('border', '');
        }
    })
    $('*[id$=TxtCSenha]').blur(function () {
        if ($(this).val() != "") {
            $(this).css('border', '');
        }
    })
})