bugzzinga.factory('usuarioServicio', ['$http', function ($http) {

    return {
        traerUsuarios: function () {
            return $http.post('Usuarios/TraerTodos');
        }
    };

}]);

bugzzinga.controller('usuarioCtrl', ['$scope', '$http', 'usuarioServicio', function ($scope, $http, usuarioServicio, $dialogs) {

    $scope.codigoEntidadSeleccionada = 0;

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = "/Usuarios/Grabar";

    usuarioServicio.traerUsuarios().success(function (data) {
        $scope.coleccion = data;
    });
}]);


