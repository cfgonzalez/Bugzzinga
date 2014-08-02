﻿
var usuarioServicio = bugzzinga.factory('usuarioServicio', function ($resource) {

    return $resource('/api/Usuarios/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

var perfilServicio = bugzzinga.factory('perfilServicio', function ($resource) {

    return $resource('/api/Perfiles/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

function AccionCargarPerfiles($scope, perfilServicio, usuarioServicio) {

    this.perfilServicio = perfilServicio;
    this.usuarioServicio = usuarioServicio;

    this.setearScope = function(scope) {
        this.scope = scope;
    };

    this.ejecutar = function() {
        this.scope.coleccionPerfiles = this.cargarPerfiles();
        this.scope.coleccionUsuarios = this.cargarUsuarios();
    };

    this.cargarPerfiles = function() {
        return this.perfilServicio.query();
    };

    this.cargarUsuarios = function() {
        return this.usuarioServicio.query();
    };
}

bugzzinga.controller('usuarioCtrl', function ($scope, $routeParams, usuarioServicio, perfilServicio ) {

    $scope.codigoEntidadSeleccionada = 0;
    
    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = usuarioServicio;

    $scope.coleccion = usuarioServicio.query();

    //GET de los perfiles
    $scope.accionCargarPerfiles = new AccionCargarPerfiles($scope, perfilServicio, usuarioServicio);

    $scope.seleccionarUsuario = function (usuario) {
        $scope.codigoEntidadSeleccionada = usuario.Codigo;
        this.selected = 'selected';
    };
    
    $scope.estiloFilaUsuario = function (usuario) {

        var estilo = { info: true };

        //Si la fila está seleccionada, le pone el estilo 'success'
        if ($scope.codigoEntidadSeleccionada == usuario.Codigo) {

            estilo = { success: true };
        }

        return estilo;
    };
});


