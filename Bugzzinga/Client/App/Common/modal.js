//Directiva
bugzzinga.directive('modalPopup', function () {
    
    return {
        restrict: 'E',
        controller: modalCtrl,
        
        //Vincula una propiedad del scope parent con el valor del atributo 'template' de la directiva
        link: function (scope, element, attrs) {
            scope.modalTemplate = 'Client/App/Vistas/' + attrs.template;
        },
        
        //Toma el valor del atributo 'template' y lo setea como templateUrl
        templateUrl: function ($node, attrs) {
            return 'Client/App/Vistas/' + attrs.template;
        }
    };
});

//Controller del Modal
var modalCtrl = function ($scope, $modal, $http) {

    $scope.open = function () {

        //Filtra la colección de usuarios según el Código elegido en la grilla.
        var entidadesSeleccionadas = $.grep($scope.coleccion, function (entidad) { return entidad.Codigo == $scope.codigoEntidadSeleccionada; });

        var modalInstance = $modal.open({
            templateUrl: $scope.modalTemplate,
            controller: ModalInstanciaCtrl,
            resolve: {
                //Sucede antes de abrir el popup. Devuelve el objeto que se inyecta en ModalInstanciaCtrl
                entidadSeleccionada: function () {
                    return entidadesSeleccionadas[0];
                }
            }
        });

        //Sucede después de aceptar el popup
        modalInstance.result.then(function (entidad) {
            $http.post($scope.servicioPersistencia,
                $.param(entidad),
                {
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
                }
            ).success(function (response) {

                //Actualiza la referencia de la entidad modificada, para que te actualice el binding y se refresque la grilla
                var entidadesModificadas = $.grep($scope.coleccion, function (entidad) { return entidad.Codigo == response.Codigo; });
                entidadesModificadas[0] = response;
            });
        });
    };
};

//Sucede antes de abrir el popup
var ModalInstanciaCtrl = function ($scope, $modalInstance, entidadSeleccionada) {

    //Setea el scope que se bindeará al template
    $scope.entidadSeleccionada = entidadSeleccionada;

    $scope.ok = function () {
        $modalInstance.close(entidadSeleccionada);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};



