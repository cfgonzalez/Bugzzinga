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
        return this.estadoServicio.get({ tipoItemNombre: tipoItem.Nombre }, function (response) {
            tipoItem.EstadosDisponibles = response;
        });
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
