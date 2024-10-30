using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class ubicaciones_DAL
    {
        SQLDBHelper oConexion;
        //Iniciar la Conexion con la Base de Datos (Constructor)
        public ubicaciones_DAL()
        {
            oConexion = new SQLDBHelper();
        }
        public bool Agregar(ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicacion, Latitud, Longitud) VALUES (@Ubicacion, @Latitud, @Longitud)";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return oConexion.EjecutarComandosSQL(cmdComando);

        }
        public bool Eliminar(ubicaciones_BLL oUbicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "DELETE FROM Direcciones WHERE ID = @ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;

            return oConexion.EjecutarComandosSQL(cmdComando);
        }


        public bool Modificar(ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "UPDATE Direcciones SET Ubicacion = @Ubicacion, Latitud = @Latitud, Longitud = @Longitud WHERE ID = @ID";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = OubicacionesBLL.ID;
            return oConexion.EjecutarComandosSQL(cmdComando);
        }




        //Seleccionar los registros de la tabla mediante un SELECT 
        public DataTable Listar()
        {
            SqlCommand cmdcomando = new SqlCommand();
            //Sentencia SQL para traer todos los registros de la tabla "Direcciones"
            cmdcomando.CommandText = "SELECT * FROM Direcciones";
            //Tipo de comando, ya sea: texto, sp, etc.
            cmdcomando.CommandType = CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSentenciaSQL(cmdcomando);

            return TablaResultante;

        }
    }
}
