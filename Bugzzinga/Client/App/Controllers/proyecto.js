bugzzinga.controller('proyectoCtrl', function ($scope, $routeParams, $location, $modal, proyectoServicio, usuarioServicio) {

    //Indica el servicio que se invoca al hacer click en el botón Aceptar del modal
    $scope.servicioPersistencia = proyectoServicio;

    $scope.coleccion = proyectoServicio.query();

    $scope.accionComplementariaModal = new AccionComplementariaModalProyecto($scope, proyectoServicio, usuarioServicio);

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

    $scope.eliminar = function (proyecto) {
        
        $('#lnkProyecto' + proyecto.Codigo).confirmation({
            animation: true,
            singleton: true,
            title: '¿Confirma eliminación?',
            onConfirm: function () {
                
                proyectoServicio.remove({ codigo: proyecto.Codigo }, function () {
                    
                    $scope.coleccion = $scope.coleccion.filter(function (e) {
                        return e.Codigo != proyecto.Codigo;
                    });
                });

                return false;
            }
        });
    };
});

//Delegado que se ejecuta luego de la creación del Modal
function AccionComplementariaModalProyecto($scope, proyectoServicio, usuarioServicio) {

    this.proyectoServicio = proyectoServicio;
    this.usuarioServicio = usuarioServicio;

    this.setearScope = function (scope) {
        this.scope = scope;
    };

    //Dependencias a popular en el modal
    this.popular = function (proyecto) {
        this.scope.coleccionUsuarios = this.cargarUsuarios(proyecto);
    };

    this.cargarProyectos = function () {
        return this.proyectoServicio.query();
    };
    
    this.cargarUsuarios = function (proyecto) {

        var self = this;

        //Trae la lista completa de usuarios
        var listaCompleta = usuarioServicio.query({}, function (todos) {

            proyecto.Miembros = [];

            //todos => todos los usuarios

            //Setea a todos en selected=false por default
            $.each(todos, function (index, value) {
                todos[index].selected = false;
            });

            //Si está editando
            if (self.scope.entidadSeleccionada.Nombre != "") {

                //Trae los miembros del proyecto, los mergea con el total de usuarios y los marca como selected=true
                return self.usuarioServicio.get({ codigoProyecto: proyecto.Codigo }, function(miembros) {
                    
                    proyecto.Miembros = miembros;

                    //Copia auxiliar de miembros para que no se pierda en el merge
                    var auxMiembros = miembros.slice();
                    
                    $.each(proyecto.Miembros, function(index, value) {
                        proyecto.Miembros[index].selected = true;
                    });
                    
                    mergearColeccionPorPropiedad(proyecto.Miembros, todos, 'Codigo');

                    //restaura los miembros originales luego del merge
                    proyecto.Miembros = auxMiembros;

                    return todos;
                });
            }
        });

        return listaCompleta;
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
