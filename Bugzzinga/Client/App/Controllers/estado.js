bugzzinga.controller('estadoCtrl', function ($scope, $routeParams, $location, $modal, estadoServicio) {

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = estadoServicio;

    $scope.coleccion = estadoServicio.query();

    $scope.accionComplementariaModal = new AccionComplementariaModalEstado($scope, estadoServicio);

    $scope.seleccionar = function (estado) {

        $scope.idEntidadSeleccionada = estado.Nombre;

        this.selected = 'selected';
    };

    $scope.estiloFila = function (estado) {

        var estilo = { info: true };

        if ($scope.idEntidadSeleccionada == estado.Nombre) {

            estilo = { success: true };
        }

        return estilo;
    };

    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var nombre = "Estado" +  Math.floor(Math.random() * 3000) + 1;

        return EstadoFactory.Nuevo(nombre);
    };

    $scope.eliminar = function (estado) {

        //Mensaje de confirmación
        $('#lnkEstado' + estado.Nombre).confirmation({
            animation: true,
            singleton: true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                ////Invoca al servicio
                estadoServicio.remove({ nombre: estado.Nombre }, function () {

                    //Si no hubo problemas, elimina el objeto del array
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Nombre != estado.Nombre;
                    });
                });

                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalEstado($scope, estadoServicio) {

    this.estadoServicio = estadoServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    //Dependencias a popular en el modal
    this.popular = function (estado) {
        this.scope.proximosEstadosValidos = this.cargarEstadosValidos(estado, 'proximos', 'ProximosEstadosValidos');
        this.scope.anterioresEstadosValidos = this.cargarEstadosValidos(estado, 'anteriores', 'AnterioresEstadosValidos');
    };

    this.cargarEstadosValidos = function (estado, tipo, coleccionScope) {

        var self = this;

        //Trae la lista completa de estados
        var listaCompleta = estadoServicio.query({}, function (todos) {

            estado[coleccionScope] = [];

            //todos => todos los estados

            //Setea a todos en selected=false por default
            $.each(todos, function (index, value) {
                todos[index].selected = false;
            });

            //Si está editando
            if (self.scope.entidadSeleccionada.Descripcion != "") {

                //Trae los miembros del proyecto, los mergea con el total de usuarios y los marca como selected=true
                return self.estadoServicio.get({ nombreEstado: estado.Nombre, tipo: tipo }, function (estados) {

                    estado[coleccionScope] = estados;

                    //Copia auxiliar de miembros para que no se pierda en el merge
                    var auxEstadosValidos = estados.slice();

                    $.each(estado[coleccionScope], function (index, value) {
                        estado[coleccionScope][index].selected = true;
                    });

                    mergearColeccionPorPropiedad(estado[coleccionScope], todos, 'Nombre');
                    
                    //restaura los miembros originales luego del merge
                    estado[coleccionScope] = auxEstadosValidos;

                    return todos;
                });
            }
        });

        return listaCompleta;
    };
    
    //Crea una nueva instancia de Estado cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que valide el nombre del perfil en el server
        var nombre = "Estado " + Math.floor(Math.random() * 3000) + 1;

        return EstadoFactory.Nuevo(nombre);;
    };
}
function estado(nombre) {
    this.Nombre = nombre;
    this.Descripcion = "";
}

var EstadoFactory = {
    Nuevo: function (nombre) {
        return new estado(nombre);
    }
};
