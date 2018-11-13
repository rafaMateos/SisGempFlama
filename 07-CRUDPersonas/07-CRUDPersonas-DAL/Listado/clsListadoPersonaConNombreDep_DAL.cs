using _07_CRUD_Personas_DAL.Conexion;
using _07_CRUDPersonas_Entidades;
using _07_CRUDPersonas_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CRUDPersonas_DAL.Listado
{
    public class clsListadoPersonaConNombreDep_DAL
    {

        public List<clsPersonaConNombreDeDepartamento> listadoCompletoPersonasConNombreDept()
        {

            clsPersonaConNombreDeDepartamento oPersona = new clsPersonaConNombreDeDepartamento();

            SqlConnection miConexion;
            List<clsPersonaConNombreDeDepartamento> ret = new List<clsPersonaConNombreDeDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();
            miComando.CommandText = "select IDPersona,nombrePersona,fechaNacimiento,telefono,direccion,nombreDepartamento from Personas inner join Departamentos on Personas.IDDepartamento = Departamentos.IDDepartamento";
            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {

                    oPersona = new clsPersonaConNombreDeDepartamento();
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.nombre = (String)miLector["nombrePersona"];
                    oPersona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                    oPersona.telefono = (String)miLector["telefono"];
                    oPersona.direccion = (string)miLector["direccion"];
                    oPersona.nombreDepartamento = (string)miLector["nombreDepartamento"];
                    ret.Add(oPersona);

                }
            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return ret;

        }
    }
}
