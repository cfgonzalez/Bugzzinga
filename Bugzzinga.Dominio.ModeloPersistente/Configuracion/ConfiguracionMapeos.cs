using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Bugzzinga.Dominio.ModeloPersistente.Configuracion
{
    public class ConfiguracionMapeos
    {

        public static void ConfigurarMapeos()
        {
            Mapper.CreateMap<Proyecto, Proyecto>();
            Mapper.CreateMap<TipoItem, TipoItem>();

            Mapper.CreateMap<Usuario, Usuario>();
            Mapper.CreateMap<Perfil, Perfil>();
        }
    }
}
