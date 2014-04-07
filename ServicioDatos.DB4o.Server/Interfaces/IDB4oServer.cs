using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioDatos.DB4o.Server.Interfaces
{
    public interface IDB4oServer: IDisposable
    {
        void Iniciar(ConfiguracionServer configuracion);
        void Finalizar();
        IObjectContainer CrearConexion();
        void FinalizarConexion(IObjectContainer cliente);

    }
}
