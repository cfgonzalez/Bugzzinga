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
        when('/plantillaProyecto', { controller: 'plantillaProyectoCtrl', templateUrl: 'Client/App/Vistas/plantillasProyecto.html' }).
        when('/estados', { controller: 'estadoCtrl', templateUrl: 'Client/App/Vistas/estados.html' }).
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

bugzzinga.
    directive("btstAccordion", function() {
        return {
            restrict: "E",
            transclude: true,
            replace: true,
            scope: {},
            template:
                "<div class='accordion' ng-transclude></div>",
            link: function(scope, element, attrs) {

                // give this element a unique id
                var id = element.attr("id");
                if (!id) {
                    id = "btst-acc" + scope.$id;
                    element.attr("id", id);
                }

                // set data-parent on accordion-toggle elements
                var arr = element.find(".accordion-toggle");
                for (var i = 0; i < arr.length; i++) {
                    $(arr[i]).attr("data-parent", "#" + id);
                    $(arr[i]).attr("href", "#" + id + "collapse" + i);
                    $(arr[i]).attr("target", "_self" + id + "collapse" + i);
                }
                arr = element.find(".accordion-body");
                //$(arr[0]).addClass("in"); // expand first pane
                for (var i = 0; i < arr.length; i++) {
                    $(arr[i]).attr("id", id + "collapse" + i);
                }
            },
            controller: function() {
            }
        };
    }).
    directive('btstPane', function() {
        return {
            restrict: "E",
            transclude: true,
            replace: true,
            scope: {
                title: "@",
                category: "=",
                order: "="
            },
            template:
                "<div class='accordion-group' >" +
                    "  <div class='accordion-heading'>" +
                    "    <a class='accordion-toggle' data-toggle='collapse'> {{category.name}} - </a>" +
                    "  </div>" +
                    "<div class='accordion-body collapse'>" +
                    "  <div class='accordion-inner' ng-transclude></div>" +
                    "  </div>" +
                    "</div>",
            link: function(scope, element, attrs) {
                scope.$watch("title", function() {
                    // NOTE: this requires jQuery (jQLite won't do html)
                    var hdr = element.find(".accordion-toggle");
                    hdr.html(scope.title);
                });
            }
        };
    });

bugzzinga.directive('customPopover', function () {
    return {
        restrict: 'A',
        template: '<span>{{label}}</span>',
        link: function (scope, el, attrs) {
            scope.label = attrs.popoverLabel;

            $(el).popover({
                trigger: 'click',
                html: true,
                content: attrs.popoverHtml,
                placement: attrs.popoverPlacement
            });
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