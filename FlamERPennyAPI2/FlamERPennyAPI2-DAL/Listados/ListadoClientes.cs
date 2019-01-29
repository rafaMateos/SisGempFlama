using DAL.Conexion;
using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Listados
{
    public class ListadoClientes
    {
        /// <summary>
        /// Función que devuelve el listado completo de todos los clientes
        /// </summary>
        /// <returns>List<Cliente></returns>
        public static List<Cliente> listadoCompletoClientes()
        {
            //Variables
            List<Cliente> lista = new List<Cliente>();
            SqlConnection conexion = null;
            SqlDataReader lector = null;
            SqlCommand miComando = new SqlCommand();
            Connection gestConexion = new Connection();

            //Datos de los clientes
            int idCliente;
            string nombreCliente;


            try
            {
                //Conexión para obtener los clientes
                conexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM vw_ListaClientesCompleta";
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();
                
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        //Definir los atributos del objeto
                        idCliente = (int)lector["Id"];
                        nombreCliente = (string)lector["Nombre"];

                        //Añadir objeto a la lista
                        lista.Add(new Cliente(idCliente, nombreCliente));
                    }
                }

            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);

                if (lector != null)
                    lector.Close();
            }

            return lista;
        }
    }
}
