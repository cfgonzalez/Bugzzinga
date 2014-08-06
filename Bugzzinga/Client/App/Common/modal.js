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
var modalCtrl = function ($scope, $modal) {

    $scope.mostrarPopupEditar = function () {

        //Filtra la colección de usuarios según el Código elegido en la grilla.
        var entidadesSeleccionadas = $.grep($scope.coleccion, function (entidad) { return entidad.Codigo == $scope.codigoEntidadSeleccionada; });

        var modalInstance = $modal.open({
            templateUrl: $scope.modalTemplate,
            controller: ModalInstanciaCtrl,
            resolve: {

                //Sucede antes de abrir el popup. Devuelve el objeto que se inyecta en ModalInstanciaCtrl
                entidadSeleccionada: function () {
                    return entidadesSeleccionadas[0];
                },

                accionComplementaria: function(){
                    return $scope.accionComplementariaModal;
                }
            }
        });

        //Sucede después de aceptar el popup
        modalInstance.result.then(function (entidad) {
            $scope.servicioPersistencia.update(entidad, function (response) {

                //Actualiza la referencia de la entidad modificada, para que se actualice el binding y se refresque la grilla
                var entidadesModificadas = $.grep($scope.coleccion, function (entidad) { return entidad.Codigo == response.Codigo; });
                entidadesModificadas[0] = response;
            });
        });
    };
    
    $scope.mostrarPopupAgregar = function () {

        $scope.entidadSeleccionada = null;

        var modalInstance = $modal.open({
            templateUrl: $scope.modalTemplate,
            controller: ModalInstanciaCtrl,
            resolve: {
                
                entidadSeleccionada: function () {
                    return null; //La entidad seleccionada es null para un alta
                },

                accionComplementaria: function () {
                    return $scope.accionComplementariaModal;
                }
            }
        });

        //Mete la nueva instancia en la colección bindeada a la grilla
        modalInstance.result.then(function (entidad) {
            $scope.servicioPersistencia.add(entidad, function (response) {
                $scope.coleccion.push(response);
            });
        });
    };
    
};

//Sucede antes de abrir el popup
var ModalInstanciaCtrl = function ($scope, $modalInstance, entidadSeleccionada, accionComplementaria) {

    //Si es un alta. (esto está bastante feo)
    if (entidadSeleccionada == null) {
        entidadSeleccionada = accionComplementaria.crearNuevoUsuario();
    }

    //Setea el scope que se bindeará al template
    $scope.entidadSeleccionada = entidadSeleccionada;
    accionComplementaria.setearScope($scope);
    accionComplementaria.popular();

    $scope.ok = function () {
        $modalInstance.close(entidadSeleccionada);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};



