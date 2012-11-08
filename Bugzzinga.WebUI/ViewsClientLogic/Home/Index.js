$(document).ready(function () {

    $('a', '#mainMenu').each(function () {
        $(this).css("minor");
    });

    $('#homeMenu').addClass("selected");
});

function VerDetalleTarea(id) {
    window.location.pathname = "/TareaDetalle/Index/" + id; 
}
