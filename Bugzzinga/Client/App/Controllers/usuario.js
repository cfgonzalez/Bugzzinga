﻿bugzzinga.controller('usuarioCtrl', function ($scope, $routeParams, usuarioServicio, perfilServicio ) {

    //Activación del item del menú
    $scope.init = function () {

        $("ul li").removeClass("active");

        $('#menuUsuarios').addClass("active");
    };

    $scope.idEntidadSeleccionada = 0;
    
    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = usuarioServicio;

    $scope.coleccion = usuarioServicio.query();

    $scope.accionComplementariaModal = new AccionComplementariaModalUsuario($scope, perfilServicio, usuarioServicio);

    $scope.seleccionar = function (usuario) {
        
        $scope.idEntidadSeleccionada = usuario.Codigo;
        
        this.selected = 'selected';
    };
    
    $scope.estiloFila = function (usuario) {

        var estilo = { info: true };

        //Si la fila está seleccionada, le pone el estilo 'success'
        if ($scope.idEntidadSeleccionada == usuario.Codigo) {

            estilo = { success: true };
        }

        return estilo;
    };
    
    //El repeater crea automáticamente en $scope.perfil una instancia del objeto perfil seleccionado
    $scope.refrescarSeleccion = function () {
        $scope.entidadSeleccionada.Perfil = $scope.perfil;
    };

    $scope.eliminar = function (usuario) {
        
        //Mensaje de confirmación
        $('#lnkUsuario' + usuario.Codigo).confirmation({
            animation: true,
            singleton:true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                ////Invoca al servicio
                usuarioServicio.remove({ codigo: usuario.Codigo }, function () {

                    //Si no hubo problemas, elimina el objeto del array
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Codigo != usuario.Codigo;
                    });
                });
                
                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalUsuario($scope, perfilServicio, usuarioServicio) {

    this.perfilServicio = perfilServicio;
    this.usuarioServicio = usuarioServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    this.popular = function (usuario) {
        this.scope.coleccionPerfiles = this.cargarPerfiles(usuario);
    };

    this.cargarPerfiles = function () {
        return perfilServicio.query();
    };

    //Crea una nueva instancia de Usuario cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return UsuarioFactory.Nuevo(codigo);
    };
}

//Definición de la clase y factory del usuario vacío
function usuario(codigo) {
    
    this.Codigo = codigo;
    
    this.Nombre = "";
    
    this.Apellido = "";
    
    this.Perfil = "";
}

var UsuarioFactory = {
    Nuevo: function (codigo) {
        return new usuario(codigo);;
    }
};
