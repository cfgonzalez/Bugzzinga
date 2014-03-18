/// <reference path="Common.d.ts" />

module Bugzzinga.ViewModels
{ 
    export class ProyectoViewModel
    {       
        Codigo: KnockoutObservableString;
        Nombre: KnockoutObservableString;
        Descripcion: KnockoutObservableString;
        FechaInicio: KnockoutObservableDate;

        constructor()
        { 
            this.Codigo = ko.observable();
            this.Nombre = ko.observable();
            this.Descripcion = ko.observable();
            this.FechaInicio = ko.observable();          

            ko.applyBindings(this);
        }

        Submit(): void {

            var url = '/Proyecto/Guardar';

            ////Serializa los datos del form
            var data = ko.toJSON(this);

            //Valida el form
            //if (!$('form').valid()) return;            

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
        }         
    }
}