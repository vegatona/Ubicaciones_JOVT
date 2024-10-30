using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL
{
    public class SQLDBHelper
    {
        DataTable Tabla;
        SqlConnection strConxion = new SqlConnection("Data Source=localhost;Initial Catalog=BDUbicaciones;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public bool EjecutarComandosSQL(SqlCommand strSQLCommand)
        {
            //INSERTAR, MODIFICAR, BORRA

            bool Respuesta = true;

            cmd = strSQLCommand;
            cmd.Connection = strConxion;
            strConxion.Open();
            Respuesta = (cmd.ExecuteNonQuery() <= 0) ? false : true;
            strConxion.Close();
            return Respuesta;
        }

        public DataTable EjecutarSentenciaSQL(SqlCommand strSQLCommand)
        {
            //Seleccionar datos de la base
            cmd = strSQLCommand;
            cmd.Connection = strConxion;
            strConxion.Open();
            Tabla = new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            strConxion.Close();
            return Tabla;
        }

        internal bool EjecutarComandosSQL(object cmdComando)
        {
            throw new NotImplementedException();
        }
    }
}
