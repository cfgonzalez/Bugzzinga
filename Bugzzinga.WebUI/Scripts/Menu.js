$(document).ready(function () {

    $('#menu li a').click(function () {
        $('#menu li a').removeClass('current');
        $(this).addClass('current');
    });   
});
