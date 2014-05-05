$(document).ready(function () {
    $('asp:LinkButton[id$ = LkSair]').blur(function (e) {
        $(this).css('color', 'green');
    })
})