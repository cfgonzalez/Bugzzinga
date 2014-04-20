var BugzzingaApp = angular.module("BugzzingaApp", ['ngRoute', 'ngResource']);

BugzzingaApp.config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: 'PerfilesController', templateUrl: 'ClientApp/Perfiles/ListadoPerfiles.html' }).
            when('/new', { controller: 'PerfilesController', templateUrl: 'ClientApp/Perfiles/DatosPerfil.html' }).
            when('/edit/:id', { controller: 'PerfilesController', templateUrl: 'ClientApp/Perfiles/DatosPerfil.html' }).
            otherwise({ redirectTo: '/' });
    });

var PerfilesFactory = BugzzingaApp.factory('PerfilesFactory', function ($resource) {        
        
    return $resource('/api/Perfiles/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

var PerfilesController = BugzzingaApp.controller('PerfilesController', function ($scope, $location, $routeParams , PerfilesFactory )
{
    $scope.esUnAlta = true;

    if ($routeParams.id != null)
    {
        $scope.perfil = PerfilesFactory.get({ id: $routeParams.id });
        $scope.esUnAlta = false;
    }   
   
    $scope.perfiles = PerfilesFactory.query();

    $scope.traerPerfiles = function ()
    {
        return PerfilesFactory.query();
    }
     
    $scope.guardar = function (perfil) {

        if ($scope.esUnAlta) {
            PerfilesFactory.save(perfil, function () {
                $location.path('/');
            });
        }
        else {
            PerfilesFactory.update(perfil, function () {
                $location.path('/');
            });
        }
    }

    $scope.eliminar = function () {
        var nombrePerfilABorrar = this.perfil.Nombre;
        PerfilesFactory.remove({ nombrePerfil: nombrePerfilABorrar }, function () {
            $("#perfil_" + nombrePerfilABorrar).fadeOut();
        });
    }
});