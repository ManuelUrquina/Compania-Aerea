using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compañia_Aerea.Controlador
{
    internal class Conexion
    {

        string cadena = "data source = STMAPRRMDFSP609\\SQLEXPRESS; database= bd_aerea; integrated security = true";

        public SqlConnection Conectar = new SqlConnection();

        public Conexion()
        {
            Conectar.ConnectionString = cadena;
        }

        public void abrir()
        {
            try 
            {
                
                Conectar.Open();
            } 
            
            catch(Exception ex) 
            {
                MessageBox.Show("No se pudo abrir el error es el siguiente: " + ex.Message);
            }

        }

        public void cerrar()
        {
            Conectar.Close();
        }




    }
}
