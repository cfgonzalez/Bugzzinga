bugzzinga.controller('plantillaProyectoCtrl', function ($scope, $routeParams, plantillaProyectoServicio, prioridadServicio, tipoItemServicio) {

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = plantillaProyectoServicio;

    $scope.coleccion = plantillaProyectoServicio.query();

    $scope.accionComplementariaModal = new AccionComplementariaModalPlantillaProyecto($scope, plantillaProyectoServicio, prioridadServicio, tipoItemServicio);

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
function AccionComplementariaModalPlantillaProyecto($scope, plantillaProyectoServicio, prioridadServicio, tipoItemServicio) {

    this.plantillaProyectoServicio = plantillaProyectoServicio;
    this.prioridadServicio = prioridadServicio;
    this.tipoItemServicio = tipoItemServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    this.cargarPlantillasProyecto = function () {
        return this.plantillaProyectoServicio.query();
    };

    //dependencias
    this.popular = function (plantillaProyecto) {
        this.scope.coleccionPrioridades = this.cargarPrioridades(plantillaProyecto);
        this.scope.coleccionTiposItem = this.cargarTiposItem(plantillaProyecto);
    };

    this.cargarPrioridades = function (plantillaProyecto) {

        var self = this;

        //Trae la lista completa de prioridades
        var listaCompleta = this.prioridadServicio.query({}, function (todos) {

            plantillaProyecto.Prioridades = [];

            //todos => todas las prioridades

            //Setea a todos en selected=false por default
            $.each(todos, function (index, value) {
                todos[index].selected = false;
            });

            //Si está editando
            if (self.scope.entidadSeleccionada.Descripcion != "") {

                //Trae las prioridades de la plantilla en curso, las mergea con el total y los marca como selected=true
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
    
    this.cargarTiposItem = function (plantillaProyecto) {

        var self = this;

        //Trae la lista completa de tipos de item
        var listaCompleta = this.tipoItemServicio.query({}, function (todos) {

            plantillaProyecto.TiposDeItem = [];

            //todos => todos los tipos de item

            //Setea a todos en selected=false por default
            $.each(todos, function (index, value) {
                todos[index].selected = false;
            });

            //Si está editando
            if (self.scope.entidadSeleccionada.Descripcion != "") {

                //Trae las prioridades de la plantilla en curso, las mergea con el total y los marca como selected=true
                return self.tipoItemServicio.get({ nombrePlantillaProyecto: plantillaProyecto.Nombre }, function (tiposItem) {

                    plantillaProyecto.TiposDeItem = tiposItem;

                    //Copia auxiliar para que no se pierda en el merge
                    var auxTiposItem = tiposItem.slice();

                    $.each(plantillaProyecto.TiposDeItem, function (index, value) {
                        plantillaProyecto.TiposDeItem[index].selected = true;
                    });

                    mergearColeccionPorPropiedad(plantillaProyecto.TiposDeItem, todos, 'Nombre');

                    //restaura los miembros originales luego del merge
                    plantillaProyecto.TiposDeItem = auxTiposItem;

                    return todos;
                });
            }
        });

        return listaCompleta;
    };

    //Crea una nueva instancia de PlantillaProyecto cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que valide el nombre en el server
        var nombre = "PlantillaProyecto" + Math.floor(Math.random() * 3000) + 1;

        return PlantillaProyectoFactory.Nuevo(nombre,"");;
    };
}

function plantillaProyecto(nombre, descripcion) {
    this.Nombre = nombre;
    this.Descripcion = descripcion;
    this.TiposDeItem = [];
    this.Prioridades = [];
}

var PlantillaProyectoFactory = {
    Nuevo: function (nombre, descripcion) {
        return new plantillaProyecto(nombre, descripcion);
    }
};
