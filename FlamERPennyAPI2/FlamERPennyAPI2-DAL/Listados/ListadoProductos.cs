using DAL.Conexion;
using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FlamERPennyAPI_DAL.Listados
{
    public static class ListadoProductos
    {
        /// <summary>
        /// Función que devuelve un listado completo de todos los productos
        /// </summary>
        /// <returns>List<Producto></returns>
        public static List<Producto> listadoCompletoProductos()
        {
            SqlConnection miConexion = new SqlConnection();
            SqlConnection miConexion2 = new SqlConnection();
            Connection gestConexion = new Connection();
            Connection gestConexion2 = new Connection();

            //Comando y lector para consulta productos
            SqlCommand comandoProd = new SqlCommand();
            SqlDataReader lectorProd = null;

            //Comando y lector para consulta categorías
            SqlCommand comandoCat = new SqlCommand();
            SqlDataReader lectorCat = null;

            //Variables para guardar los productos
            List<Producto> lista = new List<Producto>();
            int id, stock;
            double precioVenta;
            string nombre, descripcion;
            Producto oProducto;

            //Variables para guardar las categorías
            List<Categoria> categorias;
            Categoria cat;

            try
            {   
                //Conexión para obtener productos
                miConexion = gestConexion.getConnection();
                comandoProd.CommandText = "SELECT * FROM Productos";
                comandoProd.Connection = miConexion;
                lectorProd = comandoProd.ExecuteReader();

                //Preparación de conexión para obtener categorías
                comandoCat.CommandText = "SELECT Nombre_Categoria FROM Productos_Categorias WHERE Id_Producto=@id";
                comandoCat.Parameters.Add("@id", System.Data.SqlDbType.Int);

                if (lectorProd.HasRows)
                {
                    while (lectorProd.Read())
                    {
                        //Leer los datos del producto
                        id = (int)lectorProd["Id"];
                        nombre = (string)lectorProd["Nombre"];
                        precioVenta = (double)(decimal)lectorProd["Precio_Venta"];
                        descripcion = (string)lectorProd["Descripcion"];
                        stock = (int)lectorProd["Stock"];
                        categorias = new List<Categoria>();

                        //Conexión para obtener las categorías
                        miConexion2 = gestConexion2.getConnection();
                        comandoCat.Parameters["@id"].Value = id;
                        comandoCat.Connection = miConexion2;
                        lectorCat = comandoCat.ExecuteReader();

                        if (lectorCat.HasRows)
                        {
                            cat = new Categoria();

                            while (lectorCat.Read())
                            {
                                cat.nombre = (string)lectorCat["Nombre_Categoria"];

                                categorias.Add(cat);
                            }
                        }

                        //finalmente, construimos el producto completo y lo añadimos a la lista
                        oProducto = new Producto(id,nombre,precioVenta,descripcion,stock,categorias);
                        lista.Add(oProducto);
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                gestConexion.closeConnection(ref miConexion);
                gestConexion2.closeConnection(ref miConexion2);

                if (lectorProd != null)
                    lectorProd.Close();

                if (lectorCat != null)
                    lectorCat.Close();
            }

            return lista;
        }

    }
}
