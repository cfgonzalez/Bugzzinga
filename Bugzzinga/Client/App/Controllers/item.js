
 bugzzinga.controller('itemCtrl', function ($scope, $routeParams, itemServicio, tipoItemServicio) {

    $scope.CodigoProyecto = $routeParams.Codigo;

    $scope.idEntidadSeleccionada = 0;

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = itemServicio;

    $scope.coleccion = itemServicio.get({ codigoProyecto: $scope.CodigoProyecto });

    $scope.accionComplementariaModal = new AccionComplementariaModalItem($scope, itemServicio, tipoItemServicio);

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
 function AccionComplementariaModalItem($scope, itemServicio, tipoItemServicio) {

     this.itemServicio = itemServicio;
     this.tipoItemServicio = tipoItemServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    this.popular = function (item) {
        this.scope.coleccionTiposItem = this.cargarTiposItem(item);
    };

    this.cargarTiposItem = function (item) {
        return tipoItemServicio.query();
    };

    //Crea una nueva instancia de Usuario cuando es un alta
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

    this.TipoItem = "";
}

var ItemFactory = {
    Nuevo: function (codigo) {
        return new item(codigo);;
    }
};










