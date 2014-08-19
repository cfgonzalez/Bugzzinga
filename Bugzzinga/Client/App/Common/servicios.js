var usuarioServicio = bugzzinga.factory('usuarioServicio', function ($resource) {

    return $resource('/api/Usuarios/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' } });

});

var perfilServicio = bugzzinga.factory('perfilServicio', function ($resource) {

    return $resource('/api/Perfiles/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' } });
});

var proyectoServicio = bugzzinga.factory('proyectoServicio', function ($resource) {

    return $resource('/api/Proyectos/:id', { id: '@id' }, { update: { method: 'PUT' }, add: { method: 'POST' }, remove: { method: 'DELETE' } });
});