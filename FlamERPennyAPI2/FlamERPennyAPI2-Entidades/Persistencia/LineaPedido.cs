using System;
using System.Collections.Generic;
using System.Text;

namespace FlamERPennyAPI_Entidades.Persistencia
{
    public class LineaPedido
    {
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public double precioUnitario { get; set; }
        public int cantidad { get; set; }
        public double impuestos { get; set; }
        public double subtotal { get; set; }

        public LineaPedido()
        {

        }

        public LineaPedido(int idPedido, int idProducto, double precioUnitario, int cantidad, double impuestos, double subtotal)
        {
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.precioUnitario = precioUnitario;
            this.cantidad = cantidad;
            this.impuestos = impuestos;
            this.subtotal = subtotal;
        }
    }
}
