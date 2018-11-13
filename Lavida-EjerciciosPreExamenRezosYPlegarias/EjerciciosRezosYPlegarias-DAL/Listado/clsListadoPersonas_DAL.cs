
using EjercicioRezosYPlegarias_Entidades.Persistencia;
using EjerciciosRezosYPlegarias_DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRezosYPlegarias_DAL.Listado
{
    public class clsListadoPersonas_DAL
    {
        /// <summary>
        /// Funcion que devuelve una List de personas 
        /// </summary>
        /// <returns>List Personas</clsPersonas></returns>
        public List<clsPersona> listadoCompletoPersonas() {

            SqlConnection miConexion;
            List<clsPersona> ret =  new List<clsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona oPersona;
            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();
            miComando.CommandText = "SELECT * FROM personas";
            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {

                    oPersona = new clsPersona();
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.nombre = (String)miLector["nombrePersona"];
                    oPersona.Apellidos = (String)miLector["apellidosPersona"];
                    oPersona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                    oPersona.telefono = (String)miLector["telefono"];
                    oPersona.direccion = (String)miLector["direccion"];
                    oPersona.IdDept = (int)miLector["IDDepartamento"];
                    ret.Add(oPersona);

                }
            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return ret;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDepet"></param>
        /// <returns></returns>
        public List<clsPersona> listadoCompletoPersonasPorDep(int idDepet)
        {

            SqlConnection miConexion;
            List<clsPersona> ret = new List<clsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona oPersona;
            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();

            miComando.CommandText = "SELECT * FROM personas WHERE IDDepartamento = @IDDep";
            miComando.Parameters.Add("@IDDep", System.Data.SqlDbType.Int).Value = idDepet;


            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {

                    oPersona = new clsPersona();
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.nombre = (String)miLector["nombrePersona"];
                    oPersona.Apellidos = (String)miLector["apellidosPersona"];
                    oPersona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                    oPersona.telefono = (String)miLector["telefono"];
                    oPersona.direccion = (String)miLector["direccion"];
                    oPersona.IdDept = (int)miLector["IDDepartamento"];
                    ret.Add(oPersona);

                }
            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return ret;

        }
    }
}
