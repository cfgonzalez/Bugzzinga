using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bugzzinga.ViewModels;
using Bugzzinga.Model.Business;

namespace Bugzzinga.Mappers
{
    public static class TareaMapper
    {
        public static TareaViewModel MapearTareaViewModel(int Id)
        {
            TareaViewModel viewModel = new TareaViewModel();                       
            Tarea tarea = GetTarea();

            //Construye un objeto con los datos que va a consumir la interfaz de usuario
            viewModel.Descripcion = tarea.Descripcion;
            viewModel.Nombre = tarea.FechaAlta.ToString();
            viewModel.NombreUsuario = tarea.FechaAlta.ToString();

            return viewModel;
        }

        //TODO: Creación de los objetos y carga desde la DB     
        private static Tarea GetTarea()
        {
            Tarea tarea = new Tarea();

            //tarea.Id = 1;
            //tarea.Nombre = "Bug #1";
            tarea.Descripcion = "No me anda la interné";
            //tarea.Usuario = GetUsuario();

            return tarea;
        }

        private static Usuario GetUsuario()
        {
            Usuario usuario = new Usuario();

            usuario.Apellido = "Fulanito";
            usuario.Nombre = "Cosme";
            //usuario.NombreUsuario = "cosmefulanito";
            usuario.Email = "cosme@fulanito.com";

            return usuario;
        }
    }
}