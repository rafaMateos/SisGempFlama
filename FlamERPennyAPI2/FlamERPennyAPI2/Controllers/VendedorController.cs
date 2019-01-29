using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlamERPennyAPI_DAL.Manejadoras;
using FlamERPennyAPI_Entidades.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace FlamERPennyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        // GET Vendedor/username
        [HttpGet]
        public IActionResult Get([FromQuery(Name = "username")] string username)
        {
            if (username == null)
                return StatusCode(418);

            string accept = Request.Headers["Accept"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(406); //Unsupported Media Type
            else
            {
                Vendedor vendedor = ManejadoraVendedores.vendedorPorNombre(username);

                if (vendedor == null)
                    return NotFound(username); 
                else
                    return Ok(vendedor);
            }

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Vendedor vendedor)
        {
            string accept = Request.Headers["Content-Type"].ToString();
            if (accept != "application/json" && accept != "*/*")
                return StatusCode(415); //Unsupported Media Type
            else
            {
                int ok = ManejadoraVendedores.insertarVendedor(vendedor);

                if (ok == 1)
                    return StatusCode(204); //Creado
                else if (ok == -1)
                    return StatusCode(409); //Conflict
                else
                    return StatusCode(400); //No se ha podido crear
            }

        }
    }
}