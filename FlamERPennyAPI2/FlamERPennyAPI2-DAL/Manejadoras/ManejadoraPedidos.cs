using DAL.Conexion;
using FlamERPennyAPI_Entidades.Complejas;
using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Manejadoras
{
	public class ManejadoraPedidos
	{
		/// <summary>
		/// Funcion que devuelve un pedido dada su ID
		/// </summary>
		/// <param name="id">ID del pedido</param>
		/// <returns>PedidoConNombreClienteYUri o null en caso de no encontrar ese pedido</returns>
		public static PedidoConNombreClienteYUri obtenerPedidoPorId(int id)
		{
			PedidoConNombreClienteYUri pedido = null;
			Connection conexion = new Connection();
			Connection conexion2 = new Connection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlConnection sqlConnection2 = new SqlConnection();
			SqlCommand command = new SqlCommand();
			SqlCommand commandUri = new SqlCommand();
			SqlDataReader lector = null;
			SqlDataReader lectorUri = null;

			int idPedido, idCliente, idProducto;
			String nombreVendedor, nombreCliente;
			DateTime fechaPedido, fechaEntrega;
			double totalPedido;
			List<string> listaUris;

			try
			{

				//Conexión para obtener el pedido
				sqlConnection = conexion.getConnection();
				command.CommandText = "SELECT P.Id, P.Id_Cliente, P.UserName_Vendedor, P.Fecha_Pedido, P.Fecha_Entrega, P.Total_Pedido, C.Nombre AS NombreCliente FROM Pedidos AS P INNER JOIN Clientes AS C ON P.Id_Cliente = C.Id WHERE P.Id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Connection = sqlConnection;
				lector = command.ExecuteReader();
                
				if (lector.HasRows)
				{
					lector.Read();

					//Definir los atributos
					listaUris = new List<string>();
					idPedido = (int)lector["Id"];
					idCliente = (int)lector["Id_Cliente"];
					nombreVendedor = (String)lector["UserName_Vendedor"];
					nombreCliente = (String)lector["NombreCliente"];
					fechaPedido = (DateTime)lector["Fecha_Pedido"];
					fechaEntrega = lector["Fecha_Entrega"] is DBNull ? new DateTime() : (DateTime)lector["Fecha_Entrega"];
                    totalPedido = (double)(decimal)lector["Total_Pedido"];

					//Definir los parámetros del comando
					commandUri.CommandText = "SELECT Id_Producto FROM LineasDePedido WHERE Id_Pedido = @id";

                    //Definir la conexión del comando
                    commandUri.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    sqlConnection2 = conexion2.getConnection();
					commandUri.Connection = sqlConnection2;
					lectorUri = commandUri.ExecuteReader();

                    if(lectorUri.HasRows)
                    {
                        while (lectorUri.Read())
					    {
						    idProducto = (int)lectorUri["Id_Producto"];
						    listaUris.Add($"/pedido/{id}/lineaPedido/{idProducto}");
					    }
                    }
					

					pedido = new PedidoConNombreClienteYUri(id, idCliente, nombreVendedor, fechaPedido, fechaEntrega, totalPedido, nombreCliente, listaUris);

				}
			}
			catch (SqlException ex) { throw ex; }
			finally
			{
				//Cerramos el lector y la conexion
				conexion.closeConnection(ref sqlConnection);
				conexion2.closeConnection(ref sqlConnection2);

                if (lector != null)
                    lector.Close();

                if (lectorUri != null)
                    lectorUri.Close();
			}

			return pedido;
		}

        /// <summary>
        /// Inserta un nuevo pedido
        /// </summary>
        /// <param name="pedido">El pedido a insertar</param>
        /// <returns>true si se ha borrado correctamente, false en caso contrario</returns>
        public static bool insertarPedido(Pedido pedido)
		{
			Connection conexion = new Connection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand command = null;
			SqlDataReader lector = null;

			try
			{
				//Obtener conexion
				sqlConnection = conexion.getConnection();

				command = new SqlCommand("pr_insertarNuevoPedido", sqlConnection);
				command.CommandType = CommandType.StoredProcedure;

				//Definicion de los parametros del comando
				command.Parameters.AddWithValue("@Id_Cliente", pedido.idCliente);
				command.Parameters.AddWithValue("@UserName_Vendedor", pedido.nombreVendedor);

                SqlParameter exitoOutput = new SqlParameter("@exito", SqlDbType.Bit);
                exitoOutput.Direction = ParameterDirection.Output;
                command.Parameters.Add(exitoOutput);

                //Ejecutar la consulta
                command.ExecuteNonQuery();

			}
			catch (SqlException ex) { throw ex; }
			finally
			{
				//Cerramos el lector y la conexion
				conexion.closeConnection(ref sqlConnection);

                if (lector != null)
                    lector.Close();
			}

            return (bool)command.Parameters["@exito"].Value;
        }


        /// <summary>
        /// Funcion que borra un pedido dada su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true si se ha borrado correctamente, false en caso contrario</returns>
        public static bool borrarPedidoPorId(int id)
		{
			Pedido pedido = new Pedido();
			Connection miconexion = new Connection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();

			try
			{
				//Obtener conexion abierta	
				sqlconnection = miconexion.getConnection();

				//Definimos los parametros del comando
				sqlCommand = new SqlCommand("pr_borrarPedido", sqlconnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

                SqlParameter exitoOutput = new SqlParameter("@exito", SqlDbType.Bit);
                exitoOutput.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(exitoOutput);

                //Definir la conexion
                sqlCommand.Connection = sqlconnection;

				//Ejecutar la sentencia. Si hay filas afectadas, se devuelve true y viceversa
				sqlCommand.ExecuteNonQuery();
			}
			catch (SqlException ex) { throw ex; }
			finally
			{
				miconexion.closeConnection(ref sqlconnection);
			}

			return (bool)sqlCommand.Parameters["@exito"].Value;
        }


        /// <summary>
        /// Actualiza un pedido
        /// </summary>
        /// <param name="pedido">El pedido a actualizar</param>
        /// <returns>true si se ha actualizado correctamente, false en caso contrario</returns>
        public static bool actualizarPedido(Pedido pedido)
        {
            Connection conexion = new Connection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = null;

            try
            {
                //Obtener conexion
                sqlConnection = conexion.getConnection();

                command = new SqlCommand("pr_actualizarPedido", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                //Definicion de los parametros del comando
                command.Parameters.AddWithValue("@Id_Pedido", pedido.id);
                command.Parameters.AddWithValue("@Id_Cliente", pedido.idCliente);
                command.Parameters.AddWithValue("@UserName_Vendedor", pedido.nombreVendedor);
                command.Parameters.AddWithValue("@Fecha_Pedido", pedido.fechaPedido);
                command.Parameters.AddWithValue("@Fecha_Entrega", pedido.fechaEntrega);
                command.Parameters.AddWithValue("@Total_Pedido", pedido.totalPedido);

                SqlParameter exitoOutput = new SqlParameter("@exito", SqlDbType.Bit);
                exitoOutput.Direction = ParameterDirection.Output;
                command.Parameters.Add(exitoOutput);

                //Ejecutar la consulta
                command.ExecuteNonQuery();

            }
            catch (SqlException ex) { throw ex; }
            finally
            {
                //Cerramos el lector y la conexion
                conexion.closeConnection(ref sqlConnection);
            }

            return (bool)command.Parameters["@exito"].Value;
        }

	}
}


