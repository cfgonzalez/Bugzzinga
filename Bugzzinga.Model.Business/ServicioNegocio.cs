using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugzzinga.Model.Business
{
    public static class ServicioNegocio
    {
        public static List<ITarea> TraerTareas()
        {
            //Service call here
            List<ITarea> lstTareas = new List<ITarea>();

            ITarea tarea1 = new Tarea();
            ITarea tarea2 = new Tarea();
            ITarea tarea3 = new Tarea();

            tarea1.FechaAlta = DateTime.Now;
            //tarea1.Id = 1; //Lo necesita la grilla
            tarea1.Descripcion = "<span style='cursor:pointer' onclick=VerDetalleTarea('" + "1" + "')>Esta es la tarea1</span>";

            tarea2.FechaAlta = DateTime.Now;
            //tarea2.Id = 2; //Lo necesita la grilla
            tarea2.Descripcion = "<span style='cursor:pointer' onclick=VerDetalleTarea('" + "2" + "')>Esta es la tarea2</span>";

            tarea3.FechaAlta = DateTime.Now;
            //tarea3.Id = 3; //Lo necesita la grilla            
            tarea3.Descripcion = "<span style='cursor:pointer' onclick=VerDetalleTarea('" + "3" + "')>Esta es la tarea3</span>";

            lstTareas.Add(tarea1);
            lstTareas.Add(tarea2);
            lstTareas.Add(tarea3);

            return lstTareas;
        }
    }
}
