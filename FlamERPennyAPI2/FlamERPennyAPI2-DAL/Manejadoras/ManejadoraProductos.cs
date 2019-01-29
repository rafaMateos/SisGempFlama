using DAL.Conexion;
using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Manejadoras
{
    public static class ManejadoraProductos
    {
		/// <summary>
		/// Funcion que devuelve un producto dada su id
		/// </summary>
		/// <param name="id">ID del producto</param>
		/// <returns>Producto o null en caso de no encontrarlo</returns>
		public static Producto ProductoPorId (int id)
		{
			Producto producto = null;
			Connection conexion = new Connection();
			Connection conexion2 = new Connection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlConnection sqlConnection2 = new SqlConnection();
			SqlCommand command = new SqlCommand();
			SqlCommand commandCat = new SqlCommand();
			SqlDataReader lector = null;
			SqlDataReader lectorCategorias = null;
			List<Categoria> listaCat;

			int idProducto, stock;
            double precioVenta;
			String nombre, descripcion, nombreCat;

			try
			{
				//Obtener conexion
				sqlConnection = conexion.getConnection();

				//Definicion de los parametros de los productos
				command.CommandText = "SELECT * FROM Productos WHERE Id = @id";
				command.Connection = sqlConnection;
				command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
				lector = command.ExecuteReader();

                //Definición de los parámetros de las categorías
                commandCat.CommandText = "SELECT * FROM Productos_Categorias WHERE Id_Producto = @idProducto";
                commandCat.Parameters.Add("@idProducto", System.Data.SqlDbType.Int);
                

                if (lector.HasRows)
				{
					lector.Read();

					//Leer atributos del producto
					idProducto = (int)lector["Id"];
					nombre = (String)lector["Nombre"];
					precioVenta = (double)(decimal)lector["Precio_Venta"];
					descripcion = (String)lector["Descripcion"];
					stock = (int)lector["Stock"];

                    //Definir comando para las categorías
                    commandCat.Parameters["@idProducto"].Value = idProducto;
                    commandCat.Connection = sqlConnection;
                    sqlConnection2 = conexion2.getConnection();
                    commandCat.Connection = sqlConnection2;
                    lectorCategorias = commandCat.ExecuteReader();

                    listaCat = new List<Categoria>();

					//Comprobar si el lector tiene filas y en caso afirmativo, recorrer
					while (lectorCategorias.Read())
					{
						//Definir los atributos
						nombreCat = (String)lectorCategorias["Nombre_Categoria"];
						listaCat.Add(new Categoria(nombreCat));
					}

					producto = new Producto(idProducto, nombre, precioVenta, descripcion, stock, listaCat);
				}

			}catch (SqlException ex) { throw ex; }
			finally
			{
				//Cerramos el lector y la conexion
				conexion.closeConnection(ref sqlConnection);
                if (lector != null)
                    lector.Close();

                if(lectorCategorias != null)
				    lectorCategorias.Close();
			}

			return producto;
		}

	}
}
