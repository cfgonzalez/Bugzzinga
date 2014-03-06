using Db4objects.Db4o;
using System;
namespace Bugzzinga.Persistencia.Interfaces
{
    public interface IRepositorio
    {
        IObjectContainer ContenedorObjetos { get; }
        void Dispose();
    }
}
