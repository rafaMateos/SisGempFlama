using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlamERPennyAPI_DAL.Listados;
using FlamERPennyAPI_DAL.Manejadoras;
using FlamERPennyAPI_Entidades.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace FlamERPennyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET cliente
        [HttpGet]
        public IActionResult Get()
        {
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
            else
            {
                List<Cliente> listado = ListadoClientes.listadoCompletoClientes();

                return Ok(listado);
            }
        }

        // GET cliente/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Not Acceptable
            else
            {
                Cliente cliente = ManejadoraClientes.clientePorID(id);

                if (cliente != null)
                    return Ok(cliente); //200
                else
                    return NotFound(id); //404
            }
        }
        
    }
}
