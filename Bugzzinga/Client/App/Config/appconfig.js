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
        when('/items/:Codigo', { controller: 'itemCtrl', templateUrl: 'Client/App/Vistas/items.html' }).
        when('/tiposItem/:Codigo', { controller: 'tipoItemCtrl', templateUrl: 'Client/App/Vistas/tiposItem.html' }).
        otherwise({ redirectTo: '/' });
});

bugzzinga.config(function ($logProvider) {
    $logProvider.debugEnabled(true);
});

bugzzinga.filter('fechaFormateada', function($filter) {
    return function (input) {
        if(input)
        {
            if (!isNaN(Date.parse(input))) {
                input = $filter('date')(new Date(input), 'dd-MM-yyyy');
            }

            return input;
        }
    };
});

//bugzzinga.directive('mostrarFechaFormateada', function ($filter) {
//    return {
//        link: function(scope, element, attrs, ctrl) {
//            ctrl.$formatters.unshift(function(modelValue) {
//                return $filter('date')(modelValue, 'dd-MM-yyyy');
//            });

//            ctrl.$parsers.unshift(function(viewValue) {
//                return $filter('date')(viewValue, 'dd-MM-yyyy');
//            });
//        },
//        restrict: 'A',
//        require: 'ngModel'
//    };
//});