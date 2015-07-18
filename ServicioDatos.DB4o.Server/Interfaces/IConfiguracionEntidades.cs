using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o.CS.Config;

namespace ServicioDatos.DB4o.Server.Interfaces
{
    public interface IConfiguracionEntidades
    {
        /// <summary>
        /// Recibe como parametro una instancia de configuracion de servidor DB4o y le agrega a la misma
        /// la configuracion de activacion y profundidad de actualización y activación de cada una de las entidades 
        /// del modelo
        /// </summary>
        /// <param name="configuracion">Instancia de la configuración DB4o a la que se agregará la configuración de las entidades del modelo</param>
        /// <returns></returns>
        IServerConfiguration ConfigurarPersistenciaEntidades(IServerConfiguration configuracion);
    }
}
