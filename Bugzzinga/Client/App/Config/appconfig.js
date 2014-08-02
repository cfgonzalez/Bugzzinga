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
        when('/', { controller: 'usuarioCtrl', templateUrl: 'Client/App/Vistas/usuarios.html' }).
        otherwise({ redirectTo: '/' });
});