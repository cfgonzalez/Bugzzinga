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
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return EstadoFactory.Nuevo(estado);
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
        this.scope.proximosEstadosValidos = this.cargarProximosEstadosValidos(estado);
    };

    //this.cargarProyectos = function () {
    //    return this.proyectoServicio.query();
    //};

    this.cargarProximosEstadosValidos = function (estado) {

        var self = this;

        //Trae todos los estados
        return estadoServicio.query({}, function (todos) {

            //Setea a todos en selected=false por default
            $.each(todos, function (index, value) {
                todos[index].selected = false;
            });

            //Trae los miembros del proyecto
            var proximosEstadosValidos = self.estadoServicio.get({ nombre: estado.Nombre }, function (response) {

                estado.ProximosEstadosValidos = response;

                //Setea a todos en selected=false por default
                $.each(estado.ProximosEstadosValidos, function (index, value) {
                    estado.ProximosEstadosValidos[index].selected = false;
                });

                _.map(estado.ProximosEstadosValidos, function (obj) {
                    _.extend(_.clone(todos), obj);
                });

                //Marca a los estados previamente elegidos como selected=true
                for (var seleccionado in estado.ProximosEstadosValidos) {
                    var elegido = todos.filter(function (o) { return o.Nombre == estado.ProximosEstadosValidos[seleccionado].Nombre; });
                    elegido.selected = true;
                }
            });
        });
    };

    //Crea una nueva instancia de Usuario cuando es un alta
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
