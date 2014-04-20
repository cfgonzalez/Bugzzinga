var BugzzingaApp = angular.module("BugzzingaApp", ['ngRoute', 'ngResource']);

BugzzingaApp.config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: 'PerfilesController', templateUrl: 'ClientApp/Perfiles/ListadoPerfiles.html' }).
            when('/new', { controller: 'NuevoPerfilController', templateUrl: 'ClientApp/Perfiles/DatosPerfil.html' }).
            otherwise({ redirectTo: '/' });
    });

var PerfilesFactory = BugzzingaApp.factory('PerfilesFactory', function ($resource) {        
        
    return $resource('/api/Perfiles/:nombrePerfil', { id: '@nombrePerfil' }, { update: { method: 'PUT' } });
});



var PerfilesController = BugzzingaApp.controller('PerfilesController', function ($scope,  PerfilesFactory )
    {       
        $scope.perfiles = PerfilesFactory.query();
    });

var NuevoPerfilController = BugzzingaApp.controller('NuevoPerfilController', function ($scope, $location ,PerfilesFactory)
{
    $scope.guardar = function (perfil) {

        PerfilesFactory.save(perfil, function () {
            $location.path('/')
        })
    }
});

