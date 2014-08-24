//Directiva
bugzzinga.directive('modalPopup', function () {
    
    return {
        restrict: 'E',
        controller: modalCtrl,
        transclude: true,
        
        //Vincula una propiedad del scope parent con el valor del atributo 'template' de la directiva
        link: function(scope, element, attrs) {
            scope.filterCriteria = attrs.filterCriteria;
            scope.modalTemplate = 'Client/App/Vistas/' + attrs.template;
        },
   
        //Toma el valor del atributo 'template' y lo setea como templateUrl
        templateUrl: function($node, attrs) {
            return 'Client/App/Vistas/' + attrs.template;
        }
    };
});

//Controller del Modal
var modalCtrl = function ($scope, $modal) {
    
    $scope.mostrarPopupEditar = function () {

        //Filtra la colección de usuarios según el Código elegido en la grilla.
        var entidadesSeleccionadas = $.grep($scope.coleccion, function(entidad) {
            return eval('entidad.' + $scope.filterCriteria) == $scope.idEntidadSeleccionada;
        });

        var modalInstance = $modal.open({
            templateUrl: $scope.modalTemplate,
            controller: ModalInstanciaCtrl,
            resolve: {

                //Sucede antes de abrir el popup. Devuelve el objeto que se inyecta en ModalInstanciaCtrl
                entidadSeleccionada: function () {
                    //formatea todas las propiedades Fecha de la entidad
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
                var entidadesModificadas = $.grep($scope.coleccion, function(entidad) {
                     return eval('entidad.' + $scope.filterCriteria) == eval('response.' + $scope.filterCriteria);
                });
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
var ModalInstanciaCtrl = function ($scope, $modalInstance, $location, entidadSeleccionada, accionComplementaria) {

   //Si es un alta. (esto está bastante feo)
    if (entidadSeleccionada == null) {
        entidadSeleccionada = accionComplementaria.crearNuevo();
    }

    //Setea el scope que se bindeará al template
    $scope.entidadSeleccionada = entidadSeleccionada;
    accionComplementaria.setearScope($scope);
    accionComplementaria.popular(entidadSeleccionada);
    
    $scope.ok = function () {
        $modalInstance.close(entidadSeleccionada);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
    
    $scope.navegar = function (vista, parametro) {
        $modalInstance.dismiss('cancel');
        $location.path('/' + vista + '/' + parametro);
    };
    
    //Método para manejar la selección múltiple de elementos (C) de una colección (B) que son propiedad de otro objeto(A)
    //entidad: hace referencia al objeto A
    //entidad[coleccion]: hace referencia  la colección B
    //hijo: hace referencia a la entidad C, es decir a la entidad que pertenece a la colección que a su vez pertenece al objeto tratado.
    //filtro: Es la propiedad por la cual se busca al objeto en la colección.
    $scope.seleccionarListaMultiple = function (entidad, coleccion, hijo, filtro) {
        if (hijo.selected) {
            entidad[coleccion].push(hijo);
        } else {
            //busca en la colección parent a la entidad hija seleccionada en la lista y la elimina
            entidad[coleccion] = $.grep(entidad[coleccion], function (e) { return e[filtro] != hijo[filtro]; });
        }
    };
};
