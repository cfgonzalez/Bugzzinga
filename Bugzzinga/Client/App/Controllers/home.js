bugzzinga.controller('homeCtrl', function ($scope) {
    //Activa el item de menu
    $scope.init = function () {

        $("ul li").removeClass("active");

        $('#menuHome').addClass("active");
    };
});