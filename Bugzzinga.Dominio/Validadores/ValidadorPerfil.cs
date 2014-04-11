using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bugzzinga.Core.Intefaces;
using Bugzzinga.Core.Validaciones;

namespace Bugzzinga.Dominio.Validadores
{
    internal class ValidadorPerfil: IValidadorEntidad<Perfil>
    {
        public IResultadoValidacion Validar( Perfil entidad )
        {
            IResultadoValidacion resultadoValidacion = new ResultadoValidacion();                       
            
            if ( entidad.Nombre == string.Empty )
            {
                resultadoValidacion.AgregarError("El nombre no puede quedar en blanco" );
            }

            return resultadoValidacion;
        }


    }
}
