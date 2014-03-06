using Bugzzinga.Core.Configuracion;
using Bugzzinga.Persistencia.Interfaces;
using Db4objects.Db4o;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugzzinga.Dominio.ModeloPersistente
{
    public class DecoradorPersistente
    {
        internal IRepositorio _bd;

        internal IObjectContainer BD
        {
            get
            {
                if (this._bd == null)
                {
                    this._bd = ObjectFactory.With<string>(ConfiguracionBD.PathBD).GetInstance<IRepositorio>();
                }

                return this._bd.ContenedorObjetos;
            }
        }
    }
}
