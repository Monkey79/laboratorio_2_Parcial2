using BackLibs.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackLibs.Repository
{
    public static class AccesoDatos
    {
        public const string UTN_CONN_STRING = @"Data Source=NBCORAR835;Database=20240701-SP;Trusted_Connection=True;";

        public static string connQuery;
        public static SqlCommand sqlCmd;
        public static SqlConnection sqlConn;

        static AccesoDatos() {
            connQuery = UTN_CONN_STRING;
            sqlCmd = new SqlCommand();
            sqlConn = new SqlConnection(connQuery);

            sqlCmd.Connection = sqlConn;
            sqlCmd.CommandType = System.Data.CommandType.Text;
        }

        public static void ActualizarSerie(Serie serie) {
            bool rsl = false;
            try {
                sqlConn.Open();
                sqlCmd.CommandText = "UPDATE series SET alumno = @alumno WHERE genero = @genero AND nombre=@nombre";
                sqlCmd.Parameters.AddWithValue("@alumno", serie.Alumno);
                sqlCmd.Parameters.AddWithValue("@genero", serie.Genero);
                sqlCmd.Parameters.AddWithValue("@nombre", serie.Nombre);

                int rowsAffected = sqlCmd.ExecuteNonQuery();
                rsl = rowsAffected == 1 ? true : false;
            }catch (Exception e){
                Debug.WriteLine(e.Message);
                //TODO create LogFile
            }finally{
                sqlConn.Close();
            }           
        }
        public static List<Serie> ObtenerBacklog() {
            List<Serie> series = new List<Serie>();
            Serie serie = null;
            try {
                sqlConn.Open();
                sqlCmd.CommandText = "SELECT * FROM series";

                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read()) {
                    serie = new Serie(reader["genero"].ToString(), reader["nombre"].ToString(),null);
                    series.Add(serie);
                }
                reader.Close();
            }catch (Exception e) {
                Debug.WriteLine(e.Message);
                //TODO create FILEMng to create Log File
            }finally { 
                sqlConn.Close();
            }
            return series;
        }

    }
}
