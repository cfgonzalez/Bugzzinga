using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bugzzinga.Model.Entities;

namespace Bugzzinga.Model.Business
{
    public static class ServicioNegocio
    {
        public static List<Incidencia> TraerIncidencias()
        {
            //Service call here
            List<Incidencia> lstIncidencias = new List<Incidencia>();

            Incidencia incidencia1 = new Incidencia();
            Incidencia incidencia2 = new Incidencia();
            Incidencia incidencia3 = new Incidencia();

            incidencia1.Nombre = "incidencia1";
            incidencia1.Id = 1; //Lo necesita la grilla
            incidencia1.Descripcion = "<span style='cursor:pointer' onclick=VerDetalleIncidencia('" + incidencia1.Id.ToString() + "')>Esta es la incidencia1</span>";
            
            incidencia2.Nombre = "incidencia2";
            incidencia2.Id = 2; //Lo necesita la grilla
            incidencia2.Descripcion = "<span style='cursor:pointer' onclick=VerDetalleIncidencia('" + incidencia2.Id.ToString() + "')>Esta es la incidencia2</span>";
            
            incidencia3.Nombre = "incidencia3";
            incidencia3.Id = 3; //Lo necesita la grilla            
            incidencia3.Descripcion = "<span style='cursor:pointer' onclick=VerDetalleIncidencia('" + incidencia3.Id.ToString() + "')>Esta es la incidencia3</span>";            

            lstIncidencias.Add(incidencia1);
            lstIncidencias.Add(incidencia2);
            lstIncidencias.Add(incidencia3);

            return lstIncidencias;
        }
    }
}
