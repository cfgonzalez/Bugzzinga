using System;
using System.Collections.Generic;

namespace Data.DB4o.Repository
{
    public interface IRepositorio
    {
        void CancelarTransaccion();
        void Conectar();
        void ConfigurarEntidadesPersistentes(global::Data.DB4o.Common.IConfiguracionEntidadesPersistentes configuracionEntidades);
        void Desconectar();
        object Ejecutar(global::Data.DB4o.Common.IQuery pQuery);
        void Eliminar(object pObjeto);
        void EliminarInstancia();
        void FinalizarTransaccion();
        long GetId(object pObjeto);
        IEnumerable<Entidad> ListarTodos<Entidad>();
        void Modificar(object pObjeto);
        void RefrescarInstancia(object pObjeto, int pProfundidad);
        void Registrar(object pObjeto);
    }
}
