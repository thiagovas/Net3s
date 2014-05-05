$(document).ready(function () {
    $('a#Denuncia').modal({
        url: 'AtenderDenuncia.aspx?id=' + $('#Denuncia').attr('name'),
        data: "{}",
        closeClickOut: false,
        autoRefresh: true,
        closeEsc: true,
        position: 'relative',
        referencePosition: $('#MenuMain'),
        top: 0,
        left: 70
    });
});