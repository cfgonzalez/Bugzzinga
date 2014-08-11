var bugzzinga = angular.module('bugzzinga', ['ui.bootstrap', 'ngRoute', 'ngResource'], function ($routeProvider, $locationProvider, $httpProvider)
{
    var interceptor = ['$rootScope', '$q', function (scope, $q) {

        function success(response) {
            return response;
        }

        function error(response) {
            var status = response.status;

            if (status == 401) {
                window.location = "./index.html";
                return;
            }
            // otherwise
            return $q.reject(response);

        }

        return function (promise) {
            return promise.then(success, error);
        }
    }];
    $httpProvider.responseInterceptors.push(interceptor);
});

bugzzinga.config(function ($routeProvider) {
    $routeProvider.
        when('/usuarios', { controller: 'usuarioCtrl', templateUrl: 'Client/App/Vistas/usuarios.html' }).
        when('/perfiles', { controller: 'perfilCtrl', templateUrl: 'Client/App/Vistas/perfiles.html' }).
        when('/proyectos', { controller: 'proyectoCtrl', templateUrl: 'Client/App/Vistas/proyectos.html' }).
        otherwise({ redirectTo: '/' });
});

bugzzinga.config(function ($logProvider) {
    $logProvider.debugEnabled(true);
});