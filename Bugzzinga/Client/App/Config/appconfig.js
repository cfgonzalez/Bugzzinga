var bugzzinga = angular.module('bugzzinga', ['ui.bootstrap', 'ngRoute', 'ngResource']);

bugzzinga.config(function ($routeProvider) {
    $routeProvider.
        when('/', { controller: 'usuarioCtrl', templateUrl: 'Client/App/Vistas/usuarios.html' }).
        otherwise({ redirectTo: '/' });
});