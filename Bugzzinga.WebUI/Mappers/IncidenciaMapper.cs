using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bugzzinga.ViewModels;
using Bugzzinga.Model.Entities;

namespace Bugzzinga.Mappers
{
    public static class IncidenciaMapper
    {
        public static IncidenciaViewModel MapearIncidenciaViewModel(int Id)
        {
            IncidenciaViewModel viewModel = new IncidenciaViewModel();                       
            Incidencia incidencia = GetIncidencia();

            //Construye un objeto con los datos que va a consumir la interfaz de usuario
            viewModel.Descripcion = incidencia.Descripcion;
            viewModel.Nombre = incidencia.Nombre;
            viewModel.NombreUsuario = incidencia.Usuario.NombreUsuario;

            return viewModel;
        }

        //TODO: Creación de los objetos y carga desde la DB     
        private static Incidencia GetIncidencia()
        {
            Incidencia incidencia = new Incidencia();

            incidencia.Id = 1;
            incidencia.Nombre = "Bug #1";
            incidencia.Descripcion = "No me anda la interné";
            incidencia.Usuario = GetUsuario();

            return incidencia;
        }

        private static Usuario GetUsuario()
        {
            Usuario usuario = new Usuario();

            usuario.Apellido = "Fulanito";
            usuario.Nombre = "Cosme";
            usuario.NombreUsuario = "cosmefulanito";
            usuario.Email = "cosme@fulanito.com";

            return usuario;
        }
    }
}