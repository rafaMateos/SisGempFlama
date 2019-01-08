
using _07_ApiRestPersona_DAL.Conexion;
using _07_ApiRestPersona_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ApiRestPersona_DAL.Manejadoras
{
    public class clsManejadoraPersonaDal
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona PersonaPorId_DAL(int id)
        {

            SqlConnection miConexion;
            List<clsPersona> ret = new List<clsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona oPersona = null;
            clsMyConnection connection = new clsMyConnection();

            
            miConexion = connection.getConnection();
            miComando.CommandText = "SELECT * FROM personas where IDPersona = @id";
            miComando.Connection = miConexion;
            

            //Preparamos el parametro.
            SqlParameter param;
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = id;
            miComando.Parameters.Add(param);

            miLector = miComando.ExecuteReader();

            //Preparamos el parametro 2 forma
            //miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            if (miLector.HasRows)
            {

                miLector.Read();

                oPersona = new clsPersona();
                oPersona.idPersona = (int)miLector["IDPersona"];
                oPersona.nombre = (String)miLector["nombrePersona"];
                oPersona.Apellidos = (String)miLector["apellidosPersona"];
                oPersona.fechaNacimiento = (DateTime)miLector["fechaNacimiento"];
                oPersona.telefono = (String)miLector["telefono"];
                oPersona.direccion = (String)miLector["direccion"];
                oPersona.IdDept = (int)miLector["IDDepartamento"];


            }


            miLector.Close();
            connection.closeConnection(ref miConexion);

            return oPersona;

        }


        /// <summary>
        /// Metodo el cual nos creara una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CrearPersona_DAL(clsPersona nPersona)
        {

            SqlConnection miConexion;

            SqlCommand miComando = new SqlCommand();
            int filas;
            clsMyConnection connection = new clsMyConnection();

            miConexion = connection.getConnection();
            miComando.CommandText = "INSERT INTO Personas(nombrePersona,apellidosPersona,fechaNacimiento,telefono,direccion,IDDepartamento)values(@nombre,@apellidos,@fechaNac,@telefono,@direccion,@Iddept)";
            miComando.Connection = miConexion;

            SqlParameter param;
            param = new SqlParameter();
            

            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nPersona.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = nPersona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = nPersona.fechaNacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = nPersona.telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = nPersona.direccion;
            miComando.Parameters.Add("@Iddept", System.Data.SqlDbType.Int).Value = nPersona.IdDept;

            //Tener en cuenta ExecuteNonQuery porque devuelve filas
            filas = miComando.ExecuteNonQuery();

            return filas;




        }

        /// <summary>
        /// Funcion la cual borra una persona, y nos devolvera si numero de filas
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public int BorrarPersonaPorId_DAL(int id) {

            SqlConnection miConexion;

            SqlCommand miComando = new SqlCommand();
            int filas;
            clsMyConnection connection = new clsMyConnection();

            miConexion = connection.getConnection();
            miComando.CommandText = "DELETE FROM personas where IDPersona = @id";
            miComando.Connection = miConexion;

            SqlParameter param;
            param = new SqlParameter();
            param.ParameterName = "@id";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = id;
            miComando.Parameters.Add(param);

            //Tener en cuenta ExecuteNonQuery porque devuelve filas
            filas = miComando.ExecuteNonQuery();

            return filas;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int ActualizarPersona_DAL(clsPersona p) {
            int filas;

            SqlConnection miConexion;

            SqlCommand miComando = new SqlCommand();
            
            clsMyConnection connection = new clsMyConnection();

            miConexion = connection.getConnection();
            miComando.CommandText = "update Personas set nombrePersona = @nombre,@fechaNac = fechaNacimiento,apellidosPersona = @apellidos,telefono = @telefono,direccion = @direccion,IDDepartamento = @Iddept where IDPersona = @id";
            miComando.Connection = miConexion;

            SqlParameter param;
            param = new SqlParameter();


            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = p.idPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = p.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = p.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = p.fechaNacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = p.telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = p.direccion;
            miComando.Parameters.Add("@Iddept", System.Data.SqlDbType.Int).Value = p.IdDept;

            //Tener en cuenta ExecuteNonQuery porque devuelve filas
            filas = miComando.ExecuteNonQuery();

            return filas;
            

        }

    }

    
}
