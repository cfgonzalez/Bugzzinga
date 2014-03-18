var Bugzzinga;
(function (Bugzzinga) {
    (function (ViewModels) {
        var ProyectoViewModel = (function () {
            function ProyectoViewModel() {
                this.Codigo = ko.observable();
                this.Nombre = ko.observable();
                this.Descripcion = ko.observable();
                this.FechaInicio = ko.observable();
                ko.applyBindings(this);
            }
            ProyectoViewModel.prototype.Submit = function () {
                var url = '/Proyecto/Guardar';
                var data = ko.toJSON(this);
                var settings = {
                    type: 'POST',
                    contentType: "application/json;charset=utf-8",
                    data: data,
                    accepts: 'JSON',
                    success: function () {
                        alert("ok");
                    }
                };
                $.ajax(url, settings);
            };
            return ProyectoViewModel;
        })();
        ViewModels.ProyectoViewModel = ProyectoViewModel;        
    })(Bugzzinga.ViewModels || (Bugzzinga.ViewModels = {}));
    var ViewModels = Bugzzinga.ViewModels;
})(Bugzzinga || (Bugzzinga = {}));
