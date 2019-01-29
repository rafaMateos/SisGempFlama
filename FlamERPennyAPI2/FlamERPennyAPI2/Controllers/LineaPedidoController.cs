using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlamERPennyAPI_DAL.Listados;
using FlamERPennyAPI_DAL.Manejadoras;
using FlamERPennyAPI_Entidades.Complejas;
using FlamERPennyAPI_Entidades.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace FlamERPennyAPI.Controllers
{
    [Route("pedido/{id}/[controller]")]
    [ApiController]
    public class LineaPedidoController : ControllerBase
    {
        //GET Pedido
        /*[HttpGet]
        public List<LineaPedidoConDetallesProducto> Get(int id)
        {
            return ListadoLineasPedidos.listadoLineasPedidoPorID(id);
        }*/

		[HttpGet]
		public ActionResult Get(int id)
		{
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Unsupported Media Type

            List<LineaPedidoConDetallesProducto> result = ListadoLineasPedidos.listadoLineasPedidoPorID(id);

			if (result.Count == 0)
				return NotFound(id); //404
			else
				return Ok(result);	//200
		}

		// GET /pedido/{id}/lineaPedido
		/*[HttpGet("{idProducto}")]
        public LineaPedidoConDetallesProducto Get(int id, int idProducto)
        {
            return ManejadoraLineasPedidos.obtenerLineaPedidoDePedidoPorIdProducto(id, idProducto);
        }*/

		[HttpGet("{idProducto}")]
		public ActionResult Get(int id, int idProducto)
		{
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Unsupported Media Type

            LineaPedidoConDetallesProducto result = ManejadoraLineasPedidos.obtenerLineaPedidoDePedidoPorIdProducto(id, idProducto);
			
			if (result != null)
				return Ok(result); //200
			else
				return NotFound(idProducto); //404
		}

		// POST api/values 
		/*[HttpPost]
        public bool Post([FromBody] LineaPedido lineaPedido)
        {
            return ManejadoraLineasPedidos.insertarLineaDePedido(lineaPedido);
        }*/

		[HttpPost]
		public ActionResult Post([FromBody] LineaPedido lineaPedido)
		{
            string accept = Request.Headers["Content-Type"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(415); //Unsupported Media Type

            bool result = ManejadoraLineasPedidos.insertarLineaDePedido(lineaPedido);

			if (result)
				return Ok(lineaPedido); //200
			else
				return StatusCode(400); //Bad Request
		}

		// PUT api/values/5
		/*[HttpPut]
        public bool Put(int id, [FromBody] LineaPedido lineaPedido)
        {
            return ManejadoraLineasPedidos.actualizarLineaPedidoDePedidoPorIdDeProducto(lineaPedido);
        }*/

		[HttpPut]
		public ActionResult Put(int id, [FromBody] LineaPedido lineaPedido)
		{
            string accept = Request.Headers["Content-Type"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(415); //Unsupported Media Type

            bool result = ManejadoraLineasPedidos.actualizarLineaPedidoDePedidoPorIdDeProducto(lineaPedido);

            if (result)
				return Ok(result); //200 Okie Dokie
			else
				return NotFound(lineaPedido.idProducto); //404
		}

		// DELETE api/values/5
		/*[HttpDelete("{idProducto}")]
        public bool Delete(int id, int idProducto)
        {
            return ManejadoraLineasPedidos.borrarLineaPedidoDePedidoPorIdProducto(id, idProducto);
        }*/

		[HttpDelete("{idProducto}")]
		public ActionResult Delete(int id, int idProducto)
		{
			bool result = ManejadoraLineasPedidos.borrarLineaPedidoDePedidoPorIdProducto(id, idProducto);

			if (result)
				return Ok(result); //200
			else
				return NotFound(idProducto); //404
		}
	}
}
