﻿using _EjercicioRezosYPlegarias_Entidades.Complejas;
using EjercicioRezosYPlegarias_Entidades.Persistencia;
using EjerciciosRezosYPlegarias_DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosRezosYPlegarias_DAL.Manejadora
{
    public class clsManejadoraPersona_DAL
    {
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

        public clsPersonaConNombreDeDepartamento PersonaConDept_DAL(int id) {

            clsPersonaConNombreDeDepartamento oPersona = new clsPersonaConNombreDeDepartamento();

            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            clsMyConnection connection = new clsMyConnection();

            //Try no obligatorio ya que esta en clase myconnection
            miConexion = connection.getConnection();

            miComando.CommandText = "select IDPersona,nombrePersona,apellidosPersona,telefono,nombreDepartamento,Personas.IDDepartamento from Personas inner join Departamentos on Personas.IDDepartamento = Departamentos.IDDepartamento where Personas.IDPersona = @Id ";
            miComando.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;


            miComando.Connection = miConexion;
            miLector = miComando.ExecuteReader();


            if (miLector.HasRows)
            {

                while (miLector.Read())
                {
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.nombre = (String)miLector["nombrePersona"];
                    oPersona.Apellidos = (String)miLector["apellidosPersona"];
                    oPersona.telefono = (String)miLector["telefono"];
                    oPersona.IdDept = (int)miLector["IDDepartamento"];
                    oPersona.nombreDepartamento = (string)miLector["nombreDepartamento"];

                }
            }

            miLector.Close();
            connection.closeConnection(ref miConexion);
            return oPersona;

        }

        public int ActualizarPersona_Dal(clsPersonaConNombreDeDepartamento nPersona) {

            int filas;

            SqlConnection miConexion;

            SqlCommand miComando = new SqlCommand();

            clsMyConnection connection = new clsMyConnection();

            miConexion = connection.getConnection();
            miComando.CommandText = "update Personas set telefono = @telefono where IDPersona = @id";
            miComando.Connection = miConexion;

            SqlParameter param;
            param = new SqlParameter();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = nPersona.idPersona;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = nPersona.telefono;
         

            //Tener en cuenta ExecuteNonQuery porque devuelve filas
            filas = miComando.ExecuteNonQuery();

            return filas;


        }

    }
}
