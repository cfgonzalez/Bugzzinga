bugzzinga.controller('plantillaProyectoCtrl', function ($scope, $routeParams, plantillaProyectoServicio, prioridadServicio) {

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = plantillaProyectoServicio;

    $scope.coleccion = plantillaProyectoServicio.query();

    $scope.accionComplementariaModal = new AccionComplementariaModalPlantillaProyecto($scope, plantillaProyectoServicio, prioridadServicio);

    $scope.seleccionar = function (plantillaProyecto) {

        $scope.idEntidadSeleccionada = plantillaProyecto.Nombre;

        this.selected = 'selected';
    };

    $scope.estiloFila = function (plantillaProyecto) {

        var estilo = { info: true };

        //Si la fila está seleccionada, le pone el estilo 'success'
        if ($scope.idEntidadSeleccionada == plantillaProyecto.Nombre) {

            estilo = { success: true };
        }

        return estilo;
    };

    //Crea una nueva instancia de Tipo de Item cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return PlantillaProyectoFactory.Nuevo(codigo);
    };

    $scope.eliminar = function (plantillaProyecto) {

        //Mensaje de confirmación
        $('#lnkPlantillaProyecto' + plantillaProyecto.Nombre).confirmation({
            animation: true,
            singleton: true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                ////Invoca al servicio
                plantillaProyectoServicio.remove({ nombre: plantillaProyecto.Nombre }, function () {

                    //Si no hubo problemas, elimina el objeto del array
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Nombre != plantillaProyecto.Nombre;
                    });
                });

                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalPlantillaProyecto($scope, plantillaProyectoServicio, prioridadServicio) {

    this.plantillaProyectoServicio = plantillaProyectoServicio;
    this.prioridadServicio = prioridadServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    this.cargarPlantillasProyecto = function () {
        return this.plantillaProyectoServicio.query();
    };

    //dependencias
    this.popular = function (plantillaProyecto) {
        this.scope.coleccionPrioridades = this.cargarPrioridades(plantillaProyecto);
    };

    this.cargarPrioridades = function (plantillaProyecto) {

        var self = this;

        //Trae la lista completa de uestados
        var listaCompleta = this.prioridadServicio.query({}, function (todos) {

            plantillaProyecto.Prioridades = [];

            //todos => todos los estados

            //Setea a todos en selected=false por default
            $.each(todos, function (index, value) {
                todos[index].selected = false;
            });

            //Si está editando
            if (self.scope.entidadSeleccionada.Nombre != "") {

                //Trae los estados del tipo de item en curso, los mergea con el total y los marca como selected=true
                return self.prioridadServicio.get({ nombrePlantillaProyecto: plantillaProyecto.Nombre }, function (prioridades) {

                    plantillaProyecto.Prioridades = prioridades;

                    //Copia auxiliar para que no se pierda en el merge
                    var auxPrioridades = prioridades.slice();

                    $.each(plantillaProyecto.Prioridades, function (index, value) {
                        plantillaProyecto.Prioridades[index].selected = true;
                    });

                    mergearColeccionPorPropiedad(plantillaProyecto.Prioridades, todos, 'Nombre');

                    //restaura los miembros originales luego del merge
                    plantillaProyecto.Prioridades = auxPrioridades;

                    return todos;
                });
            }
        });

        return listaCompleta;
    };

    //Crea una nueva instancia de Usuario cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que valide el nombre en el server
        var nombre = "TipoItem" + Math.floor(Math.random() * 3000) + 1;

        return PlantillaProyectoFactory.Nuevo(nombre);;
    };
}

function plantillaProyecto(nombre) {
    this.Nombre = nombre;
}

var PlantillaProyectoFactory = {
    Nuevo: function (nombre) {
        return new plantillaProyecto(nombre);
    }
};
