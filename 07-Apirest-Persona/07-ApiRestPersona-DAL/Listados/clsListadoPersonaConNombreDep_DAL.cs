﻿
using _07_ApiRestPersona_DAL.Conexion;
using _07_ApiRestPersona_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ApiRestPersona_DAL.Listados
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
            miComando.CommandText = "select IDPersona,Personas.IDDepartamento as iddep,nombrePersona,apellidosPersona,fechaNacimiento,telefono,direccion,nombreDepartamento from Personas inner join Departamentos on Personas.IDDepartamento = Departamentos.IDDepartamento";
            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {

                    oPersona = new clsPersonaConNombreDeDepartamento();
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.IdDept = (int)miLector["iddep"];
                    oPersona.nombre = (String)miLector["nombrePersona"];
                    oPersona.Apellidos = (String)miLector["apellidosPersona"];
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
