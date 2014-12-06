
bugzzinga.controller('itemCtrl', function ($scope, $routeParams, itemServicio, tipoItemServicio, prioridadServicio, usuarioServicio, registroLogServicio, estadoServicio) {
    
    //Activación del item del menú
    $scope.init = function () {

        $("ul li").removeClass("active");

        $('#menuProyectos').addClass("active");
    };

    $scope.CodigoProyecto = $routeParams.Codigo;

    $scope.idEntidadSeleccionada = 0;

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = itemServicio;

    $scope.coleccion = itemServicio.get({ codigoProyecto: $scope.CodigoProyecto });

    $scope.accionComplementariaModal = new AccionComplementariaModalItem($scope, itemServicio, tipoItemServicio, prioridadServicio, usuarioServicio, registroLogServicio, estadoServicio);

    $scope.seleccionar = function (item) {

        $scope.idEntidadSeleccionada = item.Codigo;

        this.selected = 'selected';
    };

    $scope.estiloFila = function (item) {

        var estilo = { info: true };

        //Si la fila está seleccionada, le pone el estilo 'success'
        if ($scope.idEntidadSeleccionada == item.Codigo) {

            estilo = { success: true };
        }

        return estilo;
    };

    $scope.eliminar = function (item) {

        //Mensaje de confirmación
        $('#lnkItem' + item.Codigo).confirmation({
            animation: true,
            singleton: true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                ////Invoca al servicio
                itemServicio.remove({ codigo: item.Codigo }, function () {

                    //Si no hubo problemas, elimina el objeto del array
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Codigo != item.Codigo;
                    });
                });

                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalItem($scope, itemServicio, tipoItemServicio, prioridadServicio, usuarioServicio, registroLogServicio, estadoServicio) {

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    this.popular = function (item) {
        this.scope.coleccionTiposItem = this.cargarTiposItem(item);
        this.scope.coleccionPrioridades = this.cargarPrioridades(item);
        this.scope.coleccionUsuarios = this.cargarUsuarios(item);
        this.scope.coleccionRegistrosLog = this.cargarRegistrosLog(item);
        this.scope.coleccionProximosEstadosValidos = this.cargarProximosEstadosValidos(item.Estado);
    };

    this.cargarTiposItem = function (item) {
        return tipoItemServicio.query();
    };
     
    this.cargarPrioridades = function (item) {
        return prioridadServicio.query();
    };
     
    this.cargarUsuarios = function (item) {
        return usuarioServicio.query();
    };

    this.cargarRegistrosLog = function (item) {
        return registroLogServicio.get({ nombreItem: item.Nombre });
    };
    
    this.cargarProximosEstadosValidos = function (estadoActual) {

        //Trae la lista completa de estados
        return estadoServicio.get({ nombreEstado: estadoActual.Nombre, tipo: 'proximos'});
    };

    //Crea una nueva instancia de Item cuando es un alta
    this.crearNuevo = function () {

        //TODO: Ver como acceder a un recurso de Angular para que traiga este codigo desde el server
        var codigo = Math.floor(Math.random() * 3000) + 1;

        return ItemFactory.Nuevo(codigo);
    };
}

//Definición de la clase y factory del usuario vacío
function item(codigo) {

    this.Codigo = codigo;

    this.Nombre = "";

    this.Apellido = "";

    this.Tipo = null;
    
    this.Responsable = null;
    
    this.Prioridad = null;
}

var ItemFactory = {
    Nuevo: function (codigo) {
        return new item(codigo);;
    }
};










