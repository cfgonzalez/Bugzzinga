bugzzinga.controller('perfilCtrl', function ($scope, $routeParams, perfilServicio) {

    //Activación del item del menú
    $scope.init = function () {

        $("ul li").removeClass("active");

        $('#menuPerfiles').addClass("active");
    };

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = perfilServicio;

    $scope.coleccion = perfilServicio.query();
    
    $scope.accionComplementariaModal = new AccionComplementariaModalPerfil($scope, perfilServicio);
    
    $scope.seleccionar = function (perfil) {

        $scope.idEntidadSeleccionada = perfil.Nombre;

        this.selected = 'selected';
    };

    $scope.estiloFila = function (perfil) {

        var estilo = { info: true };

        //Si la fila está seleccionada, le pone el estilo 'success'
        if ($scope.idEntidadSeleccionada == perfil.Nombre) {

            estilo = { success: true };
        }

        return estilo;
    };
    
    //Crea una nueva instancia de Perfil cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return UsuarioFactory.Nuevo(codigo);
    };
    
    $scope.eliminar = function (perfil) {

        //Mensaje de confirmación
        $('#lnkPerfil' + perfil.Nombre).confirmation({
            animation: true,
            singleton: true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                ////Invoca al servicio
                perfilServicio.remove({ nombre: perfil.Nombre }, function () {

                    //Si no hubo problemas, elimina el objeto del array
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Nombre != perfil.Nombre;
                    });
                });

                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalPerfil($scope, perfilServicio) {

    this.perfilServicio = perfilServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    //no hay dependencias a popular en el modal
    this.popular = function () {
        return null;
    };

    this.cargarPerfiles = function () {
        return this.perfilServicio.query();
    };

    //Crea una nueva instancia de Perfil cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que valide el nombre del perfil en el server
        var nombre = "Perfil" + Math.floor(Math.random() * 3000) + 1;

        return PerfilFactory.Nuevo(nombre, "");;
    };
}

function perfil(nombre, descripcion) {
    this.Nombre = nombre;
    this.Descripcion = descripcion;
}

var PerfilFactory = {
    Nuevo: function (nombre, descripcion) {
        return new perfil(nombre, descripcion);
    }
};
