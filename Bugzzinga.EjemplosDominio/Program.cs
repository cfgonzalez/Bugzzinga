using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Data.DB4o.Server;
using Data.DB4o.Repository;

using StructureMap;

namespace Bugzzinga.EjemplosDominio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bugzzinga.EjemplosDominio.IoC.ConfiguracionIoC.ConfigurarAplicacion();

            ConfiguracionServidorBD configuracion = new ConfiguracionServidorBD();

            configuracion.Bd = System.IO.Directory.GetCurrentDirectory() + @"\..\..\BD\Test.yap";


            ServidorBD.Instancia().IniciarServidor(configuracion);

            configuracion.Puerto = 0;
            ObjectFactory.GetInstance<IContextoContenedor>().SetContenedor(ServidorBD.Instancia().CrearConexion());

            Application.Run(new Form1());
        }
    }
}
