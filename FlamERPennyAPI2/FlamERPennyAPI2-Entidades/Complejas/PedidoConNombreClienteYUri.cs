using FlamERPennyAPI_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlamERPennyAPI_Entidades.Complejas
{
	public class PedidoConNombreClienteYUri : Pedido
    {
		public string nombreCliente { get; set; }
		public List<string> lineasPedidos { get; set; }

        public PedidoConNombreClienteYUri()
        {

        }

        public PedidoConNombreClienteYUri(int id, int idCliente, string nombreVendedor, DateTime fechaPedido, DateTime fechaEntrega, double totalPedido, string nombreCliente, List<string> lineasPedidos) : base(id, idCliente, nombreVendedor, fechaPedido, fechaEntrega, totalPedido)
        {
            this.nombreCliente = nombreCliente;
            this.lineasPedidos = lineasPedidos;
        }

    }
}
