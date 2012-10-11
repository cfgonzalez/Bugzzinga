using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Bugzzinga.Model.Entities;
using Bugzzinga.Model.Business;

using Bugzzinga.EjemplosDominio.Ejemplos;


namespace Bugzzinga.EjemplosDominio
{
    public partial class Form1 : Form, ILogger 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestTiposDeTarea();
        }


        private void TestTiposDeTarea()
        {

            try
            {
                Perfil p1 = new Perfil();
                Perfil p2 = new Perfil();

                p1.Nombre = "Perfil 1";
                Dominio.Instancia().GestorPerfiles().Registrar(p1);
                p2.Nombre = "Perfil 1";

                p1.Descripcion = "Cambio de descripcion para el test";

                Dominio.Instancia().GestorPerfiles().Modificar(p1);
                Dominio.Instancia().GestorPerfiles().Modificar(p2);

                IList<Perfil> perfiles =
                    Dominio.Instancia().GestorPerfiles().ListarTodos();
            }
            catch (Services.Exceptions.DominioException ex)
            {

                StringBuilder mensaje = new StringBuilder();

                mensaje.Append(ex.Message);
                
                foreach (var error in ex.ErroresValidacion.GetErrores())
                {
                    mensaje.Append(Environment.NewLine);
                    mensaje.Append(" - "  + error);
                }

                MessageBox.Show(mensaje.ToString());
            }
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable<TipoTarea> resultado = Dominio.Instancia().GestorTiposDeTarea().ListarTodos();

        }

        private void btnResetearLog_Click(object sender, EventArgs e)
        {
            ResetearLog();
        }

        public void ResetearLog()
        {
            txtLog.Text = "";
        }

        public void AgregarALog(string mensaje)
        {
            txtLog.Text += Environment.NewLine + mensaje;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetearLog();
            EjemploUsuariosyPerfiles.ListarTodosLosUsuarios(this);
            EjemploUsuariosyPerfiles.RegistrarNuevoUsuario(this);
            EjemploUsuariosyPerfiles.ListarTodosLosUsuarios(this);
        }
    }
}
