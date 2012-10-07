using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            Application.Run(new Form1());
        }
    }
}
