using System;
namespace Bugzzinga.Model.Business
{
    interface ILogTarea
    {
        string Comentarios { get; set; }
        DateTime Fecha { get; set; }
        Usuario Usuiario { get; set; }
    }
}
