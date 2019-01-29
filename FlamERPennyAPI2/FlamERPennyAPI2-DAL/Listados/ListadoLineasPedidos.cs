using DAL.Conexion;
using FlamERPennyAPI_Entidades.Complejas;
using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Listados
{
    public static class ListadoLineasPedidos
    {
        /// <summary>
        /// Función que devuelve el listado completo de todas las lineaspedido de un pedido segun su ID
        /// </summary>
        /// <param name="idPedido">La ID del pedido</param>
        /// <returns>List<LineaPedidoConDetallesProducto></returns>
        public static List<LineaPedidoConDetallesProducto> listadoLineasPedidoPorID(int idPedido)
        {
            List<LineaPedidoConDetallesProducto> listadoLineasPedido = new List<LineaPedidoConDetallesProducto>();
            Connection conexion = new Connection();
            Connection conexion2 = new Connection();
            SqlConnection sqlConnection = new SqlConnection();
            SqlConnection sqlConnection2 = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlCommand commandCat = new SqlCommand();
            SqlDataReader lector = null;
            SqlDataReader lectorCat = null;

            //Variables lineaPedido
            double precioUnitario, impuestos, subtotal;
            int idLinPed, cantidad;
            Producto producto = null;

            //Variables Producto
            int idProd, stock;
            string nombreProd, descripcion;
            double precioVenta;

            //Variables Categorias
            string nombreCat;
            List<Categoria> listaCat;

            try
            {
                //Conexión para obtener las líneas de pedido
                sqlConnection = conexion.getConnection();
                command.CommandText = "SELECT * FROM LineasDePedido AS LP INNER JOIN Productos AS P ON LP.Id_Producto = P.Id WHERE LP.Id_Pedido = @idPedido";
                //command.CommandText = "SELECT * FROM fn_LineasDePedidoDeUnPedido(@idPedido)";
                command.Parameters.Add("@idPedido", SqlDbType.Int).Value = idPedido;
                command.Connection = sqlConnection;
                lector = command.ExecuteReader();
                
                if (lector.HasRows)
                {
                    //Preparación de conexión para obtener las categorías del producto
                    commandCat.CommandText = "SELECT Nombre_Categoria FROM Productos_Categorias WHERE Id_Producto = @idProducto";
                    commandCat.Parameters.Add("@idProducto", SqlDbType.Int);

                    while (lector.Read())
                    {
                        //Definir los atributos de lineas pedidos
                        idLinPed = (int)lector["Id_Pedido"];
                        idProd = (int)lector["Id_Producto"];
                        precioUnitario = (double)(decimal)lector["Precio_Unitario"];
                        cantidad = (int)lector["Cantidad"];
                        impuestos = (double)(decimal)lector["Impuestos"];
                        subtotal = (double)(decimal)lector["Subtotal"];

                        //Definir los atributos de productos
                        nombreProd = (string)lector["Nombre"];
                        descripcion = (string)lector["Descripcion"];
                        precioVenta = (double)(decimal)lector["Precio_venta"];
                        stock = (int)lector["Stock"];

                        //Definir conexión para las categorías
                        commandCat.Parameters["@idProducto"].Value = idProd;
                        sqlConnection2 = conexion2.getConnection();
                        commandCat.Connection = sqlConnection2;
                        lectorCat = commandCat.ExecuteReader();
                        listaCat = new List<Categoria>();

                        //Comprobar si el lector tiene filas y en caso afirmativo, recorrer
                        if (lectorCat.HasRows)
                        {
                            while (lectorCat.Read())
                            {
                                nombreCat = (string)lectorCat["Nombre_Categoria"];
                                listaCat.Add(new Categoria(nombreCat));
                            }
                        }

                        //Creamos el nuevo producto
                        producto = new Producto(idProd, nombreProd, precioVenta, descripcion, stock, listaCat);

                        //Creamos la nueva linea pedido
                        listadoLineasPedido.Add(new LineaPedidoConDetallesProducto(idLinPed, idProd, precioUnitario, cantidad, impuestos, subtotal, producto));
                    }

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

                if (lectorCat != null)
                    lectorCat.Close();
            }

            return listadoLineasPedido;
        }
    }

}
