bugzzinga.factory('usuarioServicio', ['$http', function ($http) {

    return {
        traerUsuarios: function () {
            return $http.post('Usuarios/TraerTodos');
        }
    };

}]);

bugzzinga.controller('usuarioCtrl', ['$scope', '$http', 'usuarioServicio', function ($scope, $http, usuarioServicio, $dialogs) {

    usuarioServicio.traerUsuarios().success(function (data) {
        $scope.usuarios = data;
    });
    
    $scope.codigoUsuarioSeleccionado = 0;
}]);


//Controllers para el Modal
var usuarioModalCtrl = function ($scope, $modal, $http) {

    $scope.open = function () {
       
        //Filtra la colección de usuarios según el Código elegido en la grilla.
        var usuariosSeleccionados = $.grep($scope.usuarios, function (usuario) { return usuario.Codigo == $scope.codigoUsuarioSeleccionado; });

        var modalInstance = $modal.open({
            templateUrl: 'usuarioModal.html',
            controller: ModalInstanceCtrl,
            resolve: {
                //Sucede antes de abrir el popup. Devuelve el objeto que se inyecta en ModalInstanceCtrl
                usuarioSeleccionado: function () {
                    return usuariosSeleccionados[0];
                }
            }
        });

        //Sucede después de aceptar el popup
        modalInstance.result.then(function (usuario) {
            $http.post("/Usuarios/Grabar",
                $.param(usuario),
                {
                    headers: {'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
                }
            ).success(function (response) {

                //Actualiza la referencia del usuario modificado, para que te actualice el binding y se refresque la grilla
                var usuariosModificados = $.grep($scope.usuarios, function (usuario) { return usuario.Codigo == response.data.Codigo; });
                usuariosModificados[0] = response.data;
            });
        });
    };
};

//Sucede antes de abrir el popup
var ModalInstanceCtrl = function ($scope, $modalInstance, usuarioSeleccionado) {
    
    //Setea el scope que se bindeará al template
    $scope.usuarioSeleccionado = usuarioSeleccionado;

    $scope.ok = function () {
        $modalInstance.close(usuarioSeleccionado);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};
