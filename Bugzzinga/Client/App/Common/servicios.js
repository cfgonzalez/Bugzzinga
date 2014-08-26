var usuarioServicio = bugzzinga.factory('usuarioServicio', function ($resource) {
    return $resource('/api/Usuarios/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' }, get: { method: 'GET', isArray: true } });
});

var perfilServicio = bugzzinga.factory('perfilServicio', function ($resource) {

    return $resource('/api/Perfiles/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' } });
});

var proyectoServicio = bugzzinga.factory('proyectoServicio', function ($resource) {

    return $resource('/api/Proyectos/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' } });
});


var tipoItemServicio = bugzzinga.factory('tipoItemServicio', function ($resource) {

    return $resource('/api/TiposItem/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' }, get: { method: 'GET', isArray: true } });
});

var estadoServicio = bugzzinga.factory('estadoServicio', function ($resource) {

    return $resource('/api/Estados/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' }, get: { method: 'GET', isArray: true } });
});


//Chequea las propiedades de tipo Fecha en un objeto, y las formatea correctamente
//var formateadorServicio = bugzzinga.factory('formateadorServicio', function ($filter) {
//    return {
//        FormatearFechas: function (entidad) {
//            for (var propiedad in entidad) {
//                if (entidad.hasOwnProperty(propiedad) && propiedad.indexOf("Fecha") > -1 && !isNaN(Date.parse(entidad[propiedad]))) {
//                   entidad[propiedad] = $filter('date')(new Date(entidad[propiedad]), 'dd-MM-yyyy');
//                }
//            }
//            return entidad;
//        }
//    };
//});
