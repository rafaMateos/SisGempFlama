using DAL.Conexion;
using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Manejadoras
{
    public class ManejadoraVendedores
    {
        public static int insertarVendedor(Vendedor vendedor)
        {
            Connection conexion = new Connection();
            int insertado;
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = null;

            try
            {
                command = new SqlCommand();
                sqlConnection = conexion.getConnection();
                command.CommandText = "INSERT INTO Vendedores (Username) VALUES (@name)";

                //Definicion de los parametros del comando
                command.Parameters.AddWithValue("@name", vendedor.username);
                command.Connection = sqlConnection;

                //Ejecutar la consulta
                insertado = command.ExecuteNonQuery();

            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627)
                    insertado = -1;
                else
                    throw ex;
            }
            finally
            {
                conexion.closeConnection(ref sqlConnection);
            }

            return insertado;
        }

        public static Vendedor vendedorPorNombre(string username)
        {
            //Variables de conexión
            SqlConnection conexion = null;
            SqlDataReader lector = null;
            SqlCommand command = new SqlCommand();
            Connection gestConexion = new Connection();
            Vendedor vendedor = null;

            //Datos de los clientes
            int idCliente;
            string nombreCliente;


            try
            {
                //Conexión para obtener el cliente
                conexion = gestConexion.getConnection();
                command.CommandText = "SELECT Username FROM Vendedores WHERE Username = @username";
                command.Parameters.AddWithValue("@username", username);
                command.Connection = conexion;
                lector = command.ExecuteReader();


                if (lector.HasRows)
                {
                    vendedor = new Vendedor(username);
                }

            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);

                if (lector != null)
                    lector.Close();
            }

            return vendedor;
        }
    }
}
