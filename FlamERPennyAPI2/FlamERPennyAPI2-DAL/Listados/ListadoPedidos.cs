using DAL.Conexion;
using FlamERPennyAPI_Entidades.Complejas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Listados
{
    public class ListadoPedidos
    {
        /// <summary>
        /// Función que devuelve un listado con todos los pedidos con el nombre del cliente y las uris de sus lineasPedido
        /// </summary>
        /// <returns>List<PedidoConNombreClienteYUri></returns>
        public static List<PedidoConNombreClienteYUri> listadoPedidosConNombreClienteYUri()
        {
            //Variables
            List<PedidoConNombreClienteYUri> lista = new List<PedidoConNombreClienteYUri>();
            SqlConnection conexion = null;
            SqlConnection conexion2 = null;
            SqlDataReader lectorPedidos = null;
            SqlDataReader lectorLineas = null;
            SqlCommand comandoPedidos = new SqlCommand();
            SqlCommand comandoLineas = new SqlCommand();
            Connection gestConexion = new Connection();
            Connection gestConexion2 = new Connection();

            //Datos pedido
            int id, idCliente;
            string nombreVendedor, nombreCliente;
            DateTime fechaPedido, fechaEntrega;
            double totalPedido;
            List<string> listadoUris;

            //Datos de lineas de pedido
            int idProducto;

            try
            {
                //Conexión para obtener los pedidos
                conexion = gestConexion.getConnection();
                comandoPedidos.CommandText = "SELECT P.Id, P.Id_Cliente, P.UserName_Vendedor, P.Fecha_Pedido, P.Fecha_Entrega, P.Total_Pedido, C.Nombre AS NombreCliente FROM Pedidos AS P INNER JOIN Clientes AS C ON P.Id_Cliente = C.Id";
                comandoPedidos.Connection = conexion;
                lectorPedidos = comandoPedidos.ExecuteReader();

                
                if (lectorPedidos.HasRows)
                {
                    //Definir los parámetros del comando
                    comandoLineas.CommandText = "SELECT Id_Producto FROM LineasDePedido WHERE Id_Pedido = @id";

                    //Añadir el parámetro
                    comandoLineas.Parameters.Add("@id", System.Data.SqlDbType.Int);

                    while (lectorPedidos.Read())
                    {
                        listadoUris = new List<string>();
                        id = (int)lectorPedidos["Id"];
                        idCliente = (int)lectorPedidos["Id_Cliente"];
                        nombreVendedor = (string)lectorPedidos["UserName_Vendedor"];
                        fechaPedido = (DateTime)lectorPedidos["Fecha_Pedido"];
                        fechaEntrega = lectorPedidos["Fecha_Entrega"] is DBNull ? new DateTime() : (DateTime)lectorPedidos["Fecha_Entrega"];
                        totalPedido = (double)(decimal)lectorPedidos["Total_Pedido"];
                        nombreCliente = (string)lectorPedidos["NombreCliente"];


                        //Ejecutamos
                        comandoLineas.Parameters["@id"].Value = id;
                        conexion2 = gestConexion2.getConnection();
                        comandoLineas.Connection = conexion2;
                        lectorLineas = comandoLineas.ExecuteReader();

                        if (lectorLineas.HasRows)
                        {
                            while (lectorLineas.Read())
                            {
                                idProducto = (int)lectorLineas["Id_Producto"];
                                listadoUris.Add($"/pedido/{id}/lineaPedido/{idProducto}");
                            }
                        }

                        lista.Add(new PedidoConNombreClienteYUri(id, idCliente, nombreVendedor, fechaPedido, fechaEntrega, totalPedido, nombreCliente, listadoUris));
                    }

                }

            }
            catch (SqlException e) { throw e; }
            finally
            {
                gestConexion.closeConnection(ref conexion);
                if(conexion2 != null)
                    gestConexion2.closeConnection(ref conexion2);
                if(lectorLineas != null)
                    lectorLineas.Close();

                if(lectorPedidos != null)
                    lectorPedidos.Close();
            }

            return lista;
        }
    }
}
