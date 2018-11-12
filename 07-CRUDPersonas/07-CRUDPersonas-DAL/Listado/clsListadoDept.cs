using _07_CRUD_Personas_DAL.Conexion;
using _07_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_DAL.Listado
{
    public class clsListadoDept
    {

        public List<clsDepartamento> listadoCompletoPersonasConNombreDept() {

            SqlConnection miConexion;
            List<clsDepartamento> ret = new List<clsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsDepartamento oDept;
           
            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();
            miComando.CommandText = "SELECT * FROM Departamentos";
            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {

                    oDept = new clsDepartamento();
                    oDept.Id = (int)miLector["IDDepartamento"];
                    oDept.Nombre = (String)miLector["nombreDepartamento"];
                    ret.Add(oDept);

                }
            }


            miLector.Close();
            connection.closeConnection(ref miConexion);


            return ret;

        }
    }
}
