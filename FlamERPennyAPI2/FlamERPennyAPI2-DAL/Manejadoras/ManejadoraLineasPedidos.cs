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
    public static class ManejadoraLineasPedidos
	{
        /// <summary>
        /// Metodo que retorna la linea de pedido de un producto, buscandola por las id del producto y del pedido
        /// </summary>
        /// <param name="idPedido"></param>
        /// <param name="idProducto"></param>
        /// <returns>LineaPedidoConDetallesProducto o null en caso de no haber encontrado la líneaPedido con esos datos</returns>
        public static LineaPedidoConDetallesProducto obtenerLineaPedidoDePedidoPorIdProducto(int idPedido, int idProducto)
		{
			LineaPedidoConDetallesProducto lineaPedido = null;
			Connection conexion = new Connection();
			Connection conexion2 = new Connection();
			Connection conexion3 = new Connection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlConnection sqlConnection2 = new SqlConnection();
			SqlConnection sqlConnection3 = new SqlConnection();
			SqlCommand command = new SqlCommand();
			SqlCommand commandProd = new SqlCommand();
			SqlCommand commandCat = new SqlCommand();
			SqlDataReader lector = null;
			SqlDataReader lectorProd = null;
			SqlDataReader lectorCat = null;

			//Variables lineaPedido
			double precioUnitario, impuestos, subtotal;
			int idLinPed, cantidad;
			Producto producto = null;

			//Variables Producto
			int idProd, stock;
			String nombreProd, descripcion;
			double precioVenta;

			//Variables Categorias
			String nombreCat;
			List<Categoria> listaCat;

			try
			{
				//Conexión para obtener la líneaPedido del pedido
				sqlConnection = conexion.getConnection();
				command.CommandText = "SELECT * FROM LineasDePedido AS L " +
					"INNER JOIN Productos AS P ON L.Id_Producto = P.Id " +
					"WHERE L.Id_Producto = @idProducto AND Id_Pedido = @idPedido";
				command.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
				command.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;
				command.Connection = sqlConnection;
				lector = command.ExecuteReader();

				//Comprobar si el lector tiene filas y en caso afirmativo, recorrer
				if (lector.HasRows)
				{
					lector.Read();

					//Definir los atributos de lineas pedidos
					idLinPed = (int)lector["Id_Pedido"];
					idProd = (int)lector["Id_Producto"];
					precioUnitario = (double)(decimal)lector["Precio_Unitario"];
					cantidad = (int)lector["Cantidad"];
					impuestos = (double)(decimal)lector["Impuestos"];
					subtotal = (double)(decimal)lector["Subtotal"];

                    //Definicion de los parametros del comando
                    commandProd.CommandText = "SELECT * FROM Productos WHERE Id = @idProducto";
                    commandProd.Parameters.Add("@idProducto", System.Data.SqlDbType.Int).Value = idProducto;
                    sqlConnection2 = conexion2.getConnection();
                    commandProd.Connection = sqlConnection2;
                    lectorProd = commandProd.ExecuteReader();

                    if (lectorProd.HasRows)
					{
						lectorProd.Read();

						//Definir los atributos de productos
						idProd = (int)lectorProd["Id"];
						nombreProd = (String)lectorProd["Nombre"];
						descripcion = (String)lectorProd["Descripcion"];
						precioVenta = (double)(decimal)lectorProd["Precio_venta"];
						stock = (int)lectorProd["Stock"];

						//Definir conexión para las categorías
						commandCat.CommandText = "SELECT Nombre_Categoria FROM Productos_Categorias WHERE Id_Producto = @idProducto";
						commandCat.Parameters.Add("@idProducto", SqlDbType.Int).Value = idProducto;
                        sqlConnection3 = conexion3.getConnection();
						commandCat.Connection = sqlConnection3;
						lectorCat = commandCat.ExecuteReader();
						listaCat = new List<Categoria>();

						//Comprobar si el lector tiene filas y en caso afirmativo, recorrer
                        if(lectorCat.HasRows)
                        {
                            while (lectorCat.Read())
						    {
							    nombreCat = (String)lectorCat["Nombre_Categoria"];
							    listaCat.Add(new Categoria(nombreCat));
						    }
                        }

						//Creamos el nuevo producto
						producto = new Producto(idProd, nombreProd, precioVenta, descripcion, stock, listaCat);
					}

					//Creamos la nueva linea pedido
					lineaPedido = new LineaPedidoConDetallesProducto(idLinPed, idProd, precioUnitario, cantidad, impuestos, subtotal, producto);
				}
			}
			catch (SqlException ex) { throw ex; }
			finally
			{
				//Cerramos el lector y la conexion
				conexion.closeConnection(ref sqlConnection);
				conexion2.closeConnection(ref sqlConnection2);
				conexion3.closeConnection(ref sqlConnection3);
                if(lector != null)
				    lector.Close();

                if (lectorProd != null)
                    lectorProd.Close();

                if (lectorCat != null)
                    lectorCat.Close();
			}

			return lineaPedido;
		}

        /// <summary>
        /// Función que inserta una nueva línea de pedido
        /// </summary>
        /// <param name="lineaPedido">La línea de pedido a insertar</param>
        /// <returns>true si se ha insertado correctamente, false en caso contrario</returns>
        public static bool insertarLineaDePedido(LineaPedido lineaPedido)
        {

            Connection conexion = new Connection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = null;

            try
            {
                //Obtener conexion
                sqlConnection = conexion.getConnection();

                command = new SqlCommand("pr_insertarNuevaLineaDePedido", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                //Definicion de los parametros del comando
                command.Parameters.AddWithValue("@Id_Pedido", lineaPedido.idPedido);
                command.Parameters.AddWithValue("@Id_Producto", lineaPedido.idProducto);
                command.Parameters.AddWithValue("@Precio_Unitario", lineaPedido.precioUnitario);
                command.Parameters.AddWithValue("@Cantidad", lineaPedido.cantidad);
                command.Parameters.AddWithValue("@Impuestos", lineaPedido.impuestos);
                command.Parameters.AddWithValue("@Subtotal", lineaPedido.subtotal);

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

        /// <summary>
        /// Actualiza una linea de pedido
        /// </summary>
        /// <param name="linea">La línea de pedido a actualizar</param>
        /// <returns>true si se ha actualizado correctamente, false en caso contrario</returns>
        public static bool actualizarLineaPedidoDePedidoPorIdDeProducto(LineaPedido linea)
        {

            SqlConnection miConexion = new SqlConnection();
			SqlCommand command = null;
            Connection gestConexion = new Connection();

            try
            {
                miConexion = gestConexion.getConnection();

                command = new SqlCommand("pr_actualizarLineaPedido", miConexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id_Pedido", linea.idPedido);
                command.Parameters.AddWithValue("@Id_Producto ", linea.idProducto);
                command.Parameters.AddWithValue("@Precio_Unitario", linea.precioUnitario);
                command.Parameters.AddWithValue("@Cantidad", linea.cantidad);
                command.Parameters.AddWithValue("@Impuestos", linea.impuestos);
                command.Parameters.AddWithValue("@SubtotaL", linea.subtotal);

                SqlParameter exitoOutput = new SqlParameter("@exito", SqlDbType.Bit);
                exitoOutput.Direction = ParameterDirection.Output;
                command.Parameters.Add(exitoOutput);

                command.ExecuteNonQuery();

            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                gestConexion.closeConnection(ref miConexion);
            }

			return (bool)command.Parameters["@exito"].Value;
		}

        /// <summary>
        /// Metodo que borra una linea de pedido dadas sus ID del pedido y su ID del producto
        /// </summary>
        /// <param name="idPedido">ID del pedido</param>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>true si se ha borrado correctamente, false en caso contrario</returns>
        public static bool borrarLineaPedidoDePedidoPorIdProducto(int idPedido, int idProducto)
		{
			Connection miconexion = new Connection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand;

			try
			{
				//Obtener conexion abierta	
				sqlconnection = miconexion.getConnection();

				//Definimos los parametros del comando
				sqlCommand = new SqlCommand("pr_borrarLineaDePedido", sqlconnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.Add("@Id_Pedido", SqlDbType.Int).Value = idPedido;
				sqlCommand.Parameters.Add("@ID_Producto", SqlDbType.Int).Value = idPedido;

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

	}
}
