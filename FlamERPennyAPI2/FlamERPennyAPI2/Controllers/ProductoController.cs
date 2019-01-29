using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlamERPennyAPI_DAL.Listados;
using FlamERPennyAPI_DAL.Manejadoras;
using FlamERPennyAPI_Entidades.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace FlamERPennyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        // GET ListadoProductos
        [HttpGet]
        public IActionResult GetListadoProductos()
        {
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
            else
            {
                List<Producto> listado = ListadoProductos.listadoCompletoProductos();

                return Ok(listado); //200
            }
        }

        // GET producto/{id}
        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
            else
            {
                Producto producto = ManejadoraProductos.ProductoPorId(id);

                if (producto != null)
                    return Ok(producto); //200
                else
                    return NotFound(id); //404
            }
        }
    }
}
