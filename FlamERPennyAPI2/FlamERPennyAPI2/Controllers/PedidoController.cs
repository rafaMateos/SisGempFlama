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
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // GET Pedido
        [HttpGet]
        public IActionResult Get()
        {
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Unsupported Media Type
            else
            {
                List<PedidoConNombreClienteYUri> listado = ListadoPedidos.listadoPedidosConNombreClienteYUri();

                return Ok(listado);
            }
        }

        // GET Pedido/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Unsupported Media Type
            else
            {
                PedidoConNombreClienteYUri p = ManejadoraPedidos.obtenerPedidoPorId(id);

                if (p != null)
                    return Ok(p);
                else
                    return NotFound(id);
            }

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            string accept = Request.Headers["Content-Type"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(415); //Unsupported Media Type
            else
            {
                bool ok = ManejadoraPedidos.insertarPedido(pedido);

                if (ok)
                    return StatusCode(204);
                else
                    return StatusCode(400);
            }

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult PutPedido(Pedido pedido)
        {
            string accept = Request.Headers["Content-Type"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(415); //Unsupported Media Type
            else
            {
                bool ok = ManejadoraPedidos.actualizarPedido(pedido);

                if (ok)
                    return StatusCode(204);
                else
                    return NotFound(pedido.id);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool ok = ManejadoraPedidos.borrarPedidoPorId(id);

            if (ok)
                return StatusCode(204);
            else
                return NotFound(id);
        }
    }
}
