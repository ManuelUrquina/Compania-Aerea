using Compañia_Aerea.Controlador;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compañia_Aerea.Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Conexion conexion = new Conexion(); // Crear una instancia de la clase Conexion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos ingresados por el usuario
                string usuario = txtUsuario.Text; // Suponiendo que tienes un TextBox llamado txtUsuario para el nombre de usuario
                string contraseña = txtPassword.Text; // Suponiendo que tienes un TextBox llamado txtContraseña para la contraseña

                // Construir la consulta SQL
                string consulta = $"SELECT COUNT(*) FROM tblmiembros WHERE mimUsuario = @Usuario AND mimPassword = @Contraseña";

                // Crear un comando SQL
                using (SqlCommand comando = new SqlCommand(consulta, conexion.Conectar))
                {
                    // Agregar parámetros para evitar la inyección de SQL
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    // Abrir la conexión
                    conexion.abrir();

                    // Ejecutar la consulta y obtener el resultado
                    int count = (int)comando.ExecuteScalar();

                    // Cerrar la conexión después de usarla
                    conexion.cerrar();

                    // Verificar el resultado
                    if (count > 0)
                    {
                        // Las credenciales son válidas
                        MessageBox.Show("Inicio de sesión exitoso");

                        this.Hide();



                    }
                    else
                    {
                        // Las credenciales son inválidas
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el inicio de sesión
                MessageBox.Show("Error durante el inicio de sesión: " + ex.Message);
            }
        }
    }
}
