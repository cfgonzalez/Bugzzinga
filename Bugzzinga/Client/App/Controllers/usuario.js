
var usuarioServicio = bugzzinga.factory('usuarioServicio', function ($resource) {

    return $resource('/api/Usuarios/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE'} });

});

var perfilServicio = bugzzinga.factory('perfilServicio', function ($resource) {

    return $resource('/api/Perfiles/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModal($scope, perfilServicio, usuarioServicio) {

    this.perfilServicio = perfilServicio;
    this.usuarioServicio = usuarioServicio;

    this.setearScope = function(scope) {
        this.scope = scope;
    };

    this.popular = function() {
        this.scope.coleccionPerfiles = this.cargarPerfiles();
        this.scope.coleccionUsuarios = this.cargarUsuarios();
    };

    this.cargarPerfiles = function() {
        return this.perfilServicio.query();
    };

    this.cargarUsuarios = function () {
        
        return this.usuarioServicio.query();
    };
    
    //Crea una nueva instancia de Usuario cuando es un alta
    this.crearNuevoUsuario = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return UsuarioFactory.Nuevo(codigo);
    };
}

bugzzinga.controller('usuarioCtrl', function ($scope, $routeParams, usuarioServicio, perfilServicio ) {

    $scope.codigoEntidadSeleccionada = 0;
    
    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = usuarioServicio;

    $scope.coleccion = usuarioServicio.query();

    $scope.accionComplementariaModal = new AccionComplementariaModal($scope, perfilServicio, usuarioServicio);

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

    $scope.eliminar = function (usuario) {
        
        ////Invoca al servicio
        usuarioServicio.remove({ codigo: usuario.Codigo }, function () {

            //Si no hubo problemas, elimina el objeto del array
            $scope.coleccion = $scope.coleccion.filter(function (e) {
                return e.Codigo != usuario.Codigo;
            });
        });
    };
});

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

//Encuentra el indice en el array dado el valor de una propiedad
function findIndexByKeyValue(obj, key, value) {
    for (var i = 0; i < obj.length; i++) {
        if (obj[i][key] == value) {
            return i;
        }
    }
    return null;
}