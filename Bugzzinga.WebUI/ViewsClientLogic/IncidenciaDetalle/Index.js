$(document).ready(function () {

    $('#btnVerFoto').click(function () {
      
        //Postback     
        $('#loading').show();
        $.ajax(
            {
                cache: false,
                type: "POST",
                url: partialImagenPerfilURL,
                success: function (view) {

                    //Callback: restaura el estado de los divs
                    $('#foto').empty();
                    $('#foto').html(view);
                    $('#loading').hide();
                },
                error: function (req, status, error) {
                    $('#foto').html(error);
                }
            });
    });

});  

