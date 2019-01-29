using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlamERPennyAPI_Entidades.Complejas
{
	public class LineaPedidoConDetallesProducto : LineaPedido
	{
		public Producto producto { get; set; }

        public LineaPedidoConDetallesProducto()
        {

        }

        public LineaPedidoConDetallesProducto(int idPedido, int idProducto, double precioUnitario, int cantidad, double impuestos, double subtotal, Producto producto) : base(idPedido, idProducto, precioUnitario, cantidad, impuestos, subtotal)
        {
            this.producto = producto;
        }
    }
}
