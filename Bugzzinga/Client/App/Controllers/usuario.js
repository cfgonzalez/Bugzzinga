
var usuarioServicio = bugzzinga.factory('usuarioServicio', function ($resource) {

    return $resource('/api/Usuarios/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

var perfilServicio = bugzzinga.factory('perfilServicio', function ($resource) {

    return $resource('/api/Perfiles/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

bugzzinga.controller('usuarioCtrl', function ($scope, $routeParams, usuarioServicio, perfilServicio ) {

    $scope.codigoEntidadSeleccionada = 0;

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = usuarioServicio;
    
    $scope.coleccion = usuarioServicio.query();

    
});


