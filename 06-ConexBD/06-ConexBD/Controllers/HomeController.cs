using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_ConexBD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() {

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost,ActionName ("Index")]
        public ActionResult IndexPost()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {

                miConexion.ConnectionString = "server=serverpersona.database.windows.net;database=personasDB;uid=Prueba44;pwd=123qwerty;";

                miConexion.Open();

                ViewData["Estado"] = miConexion.State;

            }
            catch (SqlException)
            {

                ViewData["Estado"] = "Error al intentar conectarse a la BD";

            }

            finally
            {

                miConexion.Close();

            }

            return View();
        }

        public ActionResult ListadoPersonas() {

            //Aqui va todo el ej, pero desp conectaremos con otra clase, esto es una chapuza pa aprende

            return View();
        }

    }
}