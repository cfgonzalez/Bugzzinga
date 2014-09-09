bugzzinga.controller('tipoItemCtrl', function ($scope, $routeParams,tipoItemServicio, estadoServicio) {

    $scope.CodigoProyecto = $routeParams.Codigo;

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = tipoItemServicio;

    $scope.coleccion = tipoItemServicio.query();

    $scope.accionComplementariaModal = new AccionComplementariaModalTipoItem($scope, tipoItemServicio, estadoServicio);

    $scope.seleccionar = function (tipoItem) {

        $scope.idEntidadSeleccionada = tipoItem.Nombre;

        this.selected = 'selected';
    };

    $scope.estiloFila = function (tipoItem) {

        var estilo = { info: true };

        //Si la fila está seleccionada, le pone el estilo 'success'
        if ($scope.idEntidadSeleccionada == tipoItem.Nombre) {

            estilo = { success: true };
        }

        return estilo;
    };

    //Crea una nueva instancia de Tipo de Item cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return TipoItemFactory.Nuevo(codigo);
    };

    $scope.eliminar = function (tipoItem) {

        //Mensaje de confirmación
        $('#lnkTipoItem' + tipoItem.Nombre).confirmation({
            animation: true,
            singleton: true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                ////Invoca al servicio
                tipoItemServicio.remove({ nombre: tipoItem.Nombre }, function () {

                    //Si no hubo problemas, elimina el objeto del array
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Nombre != tipoItem.Nombre;
                    });
                });

                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalTipoItem($scope, tipoItemServicio, estadoServicio) {

    this.tipoItemServicio = tipoItemServicio;
    this.estadoServicio = estadoServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };
    
    this.cargarTiposItem = function () {
        return this.tipoItemServicio.query();
    };
    
    //dependencias
    this.popular = function (tipoItem) {
        this.scope.coleccionEstados = this.cargarEstados(tipoItem);
    };
    
    this.cargarEstados = function (tipoItem) {
        
        var self = this;

        //Trae la lista completa de uestados
        var listaCompleta = this.estadoServicio.query({}, function (todos) {

            tipoItem.EstadosDisponibles = [];

            //todos => todos los estados

            //Setea a todos en selected=false por default
            $.each(todos, function (index, value) {
                todos[index].selected = false;
            });

            //Si está editando
            if (self.scope.entidadSeleccionada.Descripcion != "") {

                //Trae los estados del tipo de item en curso, los mergea con el total y los marca como selected=true
                return self.estadoServicio.get({ nombreTipoItem: tipoItem.Nombre }, function (estados) {

                    tipoItem.EstadosDisponibles = estados;

                    //Copia auxiliar para que no se pierda en el merge
                    var auxEstados = estados.slice();

                    $.each(tipoItem.EstadosDisponibles, function (index, value) {
                        tipoItem.EstadosDisponibles[index].selected = true;
                    });

                    mergearColeccionPorPropiedad(tipoItem.EstadosDisponibles, todos, 'Nombre');

                    //restaura los miembros originales luego del merge
                    tipoItem.EstadosDisponibles = auxEstados;

                    return todos;
                });
            }
        });

        return listaCompleta;
    };

    //Crea una nueva instancia de Usuario cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que valide el nombre del perfil en el server
        var nombre = "TipoItem" + Math.floor(Math.random() * 3000) + 1;

        return TipoItemFactory.Nuevo(nombre, "");;
    };
}

function tipoItem(nombre, descripcion) {
    this.Nombre = nombre;
    this.Descripcion = descripcion;
}

var TipoItemFactory = {
    Nuevo: function (nombre, descripcion) {
        return new tipoItem(nombre, descripcion);
    }
};
