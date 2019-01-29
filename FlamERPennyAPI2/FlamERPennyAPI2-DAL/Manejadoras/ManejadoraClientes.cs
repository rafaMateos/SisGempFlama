using DAL.Conexion;
using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Manejadoras
{
    public class ManejadoraClientes
    {
        /// <summary>
        /// Función que devuelve los datos de un cliente dado su ID
        /// </summary>
        /// <param name="id">ID del cliente</param>
        /// <returns>Cliente, o null en caso de que no se pudiese encontrar</returns>
        public static Cliente clientePorID(int id)
        {
            //Variables de conexión
            SqlConnection conexion = null;
            SqlDataReader lector = null;
            SqlCommand miComando = new SqlCommand();
            Connection gestConexion = new Connection();
            Cliente cliente = null;

            //Datos de los clientes
            int idCliente;
            string nombreCliente;


            try
            {
                //Conexión para obtener el cliente
                conexion = gestConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Clientes WHERE Id = @Id";
                miComando.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();
                

                if (lector.HasRows)
                {
                    lector.Read();

                    //Definir los atributos del objeto
                    nombreCliente = (string)lector["Nombre"];
                    idCliente = (int)lector["Id"];

                    cliente = new Cliente(idCliente, nombreCliente);
                }
                
            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);

                if (lector != null)
                    lector.Close();
            }

            return cliente;
        }
    }
}
