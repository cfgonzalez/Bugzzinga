bugzzinga.controller('proyectoCtrl', function ($scope, $routeParams, $location, $modal, proyectoServicio) {

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = proyectoServicio;

    $scope.coleccion = proyectoServicio.query();

    $.each($scope.coleccion, function (index,value) {
            value.FechaInicio = $filter('date')(value.FechaInicio, "dd/MM/yyyy");
        }
    );

    $scope.accionComplementariaModal = new AccionComplementariaModalProyecto($scope, proyectoServicio);

    $scope.seleccionar = function (proyecto) {

        $scope.idEntidadSeleccionada = proyecto.Codigo;

        this.selected = 'selected';
    };

    $scope.estiloFila = function (proyecto) {

        var estilo = { info: true };

        //Si la fila está seleccionada, le pone el estilo 'success'
        if ($scope.idEntidadSeleccionada == proyecto.Codigo) {

            estilo = { success: true };
        }

        return estilo;
    };

    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return ProyectoFactory.Nuevo(proyecto);
    };

    $scope.eliminar = function (proyecto) {

        //Mensaje de confirmación
        $('#lnkProyecto' + proyecto.Codigo).confirmation({
            animation: true,
            singleton: true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                ////Invoca al servicio
                proyectoServicio.remove({ codigo: proyecto.Codigo }, function () {

                    //Si no hubo problemas, elimina el objeto del array
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Nombre != proyecto.Codigo;
                    });
                });

                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalProyecto($scope, proyectoServicio) {

    this.proyectoServicio = proyectoServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    //no hay dependencias a popular en el modal
    this.popular = function () {
        return null;
    };

    this.cargarProyectos = function () {
        return this.proyectoServicio.query();
    };

    //Crea una nueva instancia de Usuario cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que valide el nombre del perfil en el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return ProyectoFactory.Nuevo(codigo);;
    };
}

function proyecto(codigo) {
    this.Codigo = codigo;
    this.Nombre = "";
    this.Descripcion = "";
    this.FechaInicio = new Date();
    this.TiposDeItem = [];
    this.items = [];
    this.Prioridades = [];
}

var ProyectoFactory = {
    Nuevo: function (codigo) {
        return new proyecto(codigo);
    }
};
