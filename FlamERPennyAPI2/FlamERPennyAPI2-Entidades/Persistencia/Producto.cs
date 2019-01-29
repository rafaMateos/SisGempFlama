using System;
using System.Collections.Generic;
using System.Text;

namespace FlamERPennyAPI_Entidades.Persistencia
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precioVenta { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public List<Categoria> listaCategorias { get; set; }

        public Producto()
        {

        }

        public Producto(int id, string nombre, double precioVenta, string descripcion, int stock, List<Categoria> listaCategorias)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioVenta = precioVenta;
            this.descripcion = descripcion;
            this.stock = stock;
            this.listaCategorias = listaCategorias;
        }

    }
}
