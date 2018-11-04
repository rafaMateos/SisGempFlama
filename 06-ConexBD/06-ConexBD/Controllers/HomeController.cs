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

                miConexion.ConnectionString = "server=serverpersona.database.windows.net;database=personasDB;uid=rmateos;pwd=Sevillamalo16;";

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

            SqlConnection miConexion = new SqlConnection();
            List<Models.clsPersona> listaPer = new List<Models.clsPersona>();
            
            SqlDataReader miLector = null;
            Models.clsPersona oPersona;

            try
            {

                //miConexion.ConnectionString = "server=serverpersona.database.windows.net;database=personasDB;uid=Prueba;pwd=123qwerty.;";
                miConexion.ConnectionString = "server=serverpersona.database.windows.net;database=personasDB;uid=rmateos;pwd=Sevillamalo16;";

                miConexion.Open();
                SqlCommand miComando = new SqlCommand("SELECT IDPersona,nombrePersona,apellidosPersona,fechaNacimiento,direccion,IDDepartamento FROM Personas", miConexion); 

                //miComando.CommandText = "SELECT * FROM Personas";

                //miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {

                    while (miLector.Read())
                    {


                        oPersona = new Models.clsPersona();
                        oPersona.idPersona = (int)miLector["IDPersona"];
                        oPersona.nombre = (String)miLector["nombrePersona"];
                        oPersona.Apellidos = (String)miLector["apellidosPersona"];
                        oPersona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                        //oPersona.telefono = (String)miLector["telefono"];
                        oPersona.direccion = (String)miLector["direccion"];
                        oPersona.IdDept = (int)miLector["IDDepartamento"];
                        listaPer.Add(oPersona);

                    }
                }
                

                miLector.Close();
                miConexion.Close();



            }
            catch (SqlException)
            {

                ViewData["Estado"] = "Error al intentar conectarse a la BD";

            }

            finally
            {

                miConexion.Close();

            }

            return View(listaPer);
        }

    }
}