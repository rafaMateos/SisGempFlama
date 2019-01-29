using System;

namespace FlamERPennyAPI_Entidades.Persistencia
{
    public class Pedido
    {
        public int id { get; set; }
        public int idCliente { get; set;  }
        public string nombreVendedor { get; set; }
        public DateTime fechaPedido { get; set; }
        public DateTime fechaEntrega { get; set; }
        public double totalPedido { get; set; }


        public Pedido()
        {

        }

        public Pedido(int id, int idCliente, string nombreVendedor, DateTime fechaPedido, DateTime fechaEntrega, double totalPedido)
        {
            this.id = id;
            this.idCliente = idCliente;
            this.nombreVendedor = nombreVendedor;
            this.fechaPedido = fechaPedido;
            this.fechaEntrega = fechaEntrega;
            this.totalPedido = totalPedido;
        }
    }
}
