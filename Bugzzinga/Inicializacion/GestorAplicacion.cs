﻿using Bugzzinga.Contexto.IoC;
using ServicioDatos.DB4o.Server;
using ServicioDatos.DB4o.Server.Interfaces;
using StructureMap;
using System.Web.Configuration;

namespace Bugzzinga.Inicializacion
{
    public class GestorAplicacion
    {
        public static void IniciarAplicacion()
        {
            ConfigurarIoC();
            
            ConfiguracionServer configuracionServidor = new ConfiguracionServer();
            configuracionServidor.RutaArchivos = Properties.Settings.Default.DirectorioBD;
            configuracionServidor.NombreArchivoBD = Properties.Settings.Default.NombreBD;
            configuracionServidor.Puerto = 0;
            configuracionServidor.PersistenciaTransparente = true;
            configuracionServidor.ActivacionTransparente = true;

            IDB4oServer servidorBD = ObjectFactory.GetInstance<IDB4oServer>();
            servidorBD.Iniciar(configuracionServidor);
        }

        private static void ConfigurarIoC()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new RegistryWeb()));
        }

        public static void FinalizarAplicacion()
        {
            IDB4oServer servidorBD = ObjectFactory.GetInstance<IDB4oServer>();
            servidorBD.Finalizar();
        }
    }
}