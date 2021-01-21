using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Dao
{
    public class AccesoaDatos
    {
        //string ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=TP_Final;Persist Security Info=True;User ID=sa;Password=123456";
        //string ruta = "Data Source=LAPTOP-JSEM9I72\\SQLEXPRESS;Initial Catalog=TP_Final;Integrated Security=True";
        string ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=TP_Final;Integrated Security=True";//Adriel
        //string ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=TP_Final;Integrated Security=True";
        //string ruta = "Data Source=DESKTOP-EDHCNT7\\SQLEXPRESS;Initial Catalog = TP_Final; Integrated Security = True";
        //string ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=TP_Final;Persist Security Info=True;User ID=sa;Password=123456";


        public AccesoaDatos()
        {

        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(ruta);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return null;
            }
        }

        public SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection con)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, con);
                return adaptador;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql,Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public int EjecutarProcedimientoAlmacenado2(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas = 1;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            try
            {
                string aux = dr[0].ToString();
            }
            catch
            {
                FilasCambiadas = 0;
            }

            Conexion.Close();
            return FilasCambiadas;
        }

        public DataSet TraerDs(string NombreTabla, string consulta)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adap = ObtenerAdaptador(consulta, Conexion);
            adap.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds;
        }


        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            Conexion.Close();
            return estado;
        }

        public int ejecutar_transaccion(string consulta)
        {
            SqlConnection conec = new SqlConnection(ruta);
            conec.Open();
            SqlCommand comando = new SqlCommand(consulta, conec);
            return comando.ExecuteNonQuery();
        }

        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            //TONY
            Conexion.Close();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }

    }



}
