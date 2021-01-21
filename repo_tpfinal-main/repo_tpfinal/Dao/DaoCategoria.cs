using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Dao
{
    public class DaoCategoria
    {
        AccesoaDatos ds = new AccesoaDatos();

        //public DataTable ObtenerTodasLasCategorias()
        //{
          //  return ds.ObtenerTabla("categorias", "SELECT categoria.Nombre, categoria.Imagen FROM categoria");
        //}

        public DataTable ObtenerTodasLasCategorias()
        {
            return ds.ObtenerTabla("categorias", "SELECT categoria.id_categoria, categoria.Nombre, categoria.Estado, categoria.Imagen FROM categoria");
        }

        public DataTable BusquedaDeCategoria(String texto)
        {
            return ds.ObtenerTabla("categoria", "Select id_categoria, categoria.Nombre, categoria.Estado, categoria.Imagen from categoria WHERE categoria.Nombre LIKE '%" + texto + "%'");
        }

        public Boolean existeCategoría(Categorias cat)
        {
            String consulta = "Select * from categoria where Nombre='" + cat.Nombre1 + "'";
            return ds.existe(consulta);
        }

        public int eliminarCategoria(Categorias cat)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCategoriaEliminar(ref comando, cat);
            return ds.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarCategoria");
        }


        public int agregarCategoria(Categorias cat)
        {

           
            //cat.setIdCategoria(ds.ObtenerMaximo("SELECT max(idCategoría) FROM Categorías") + 1);
            //cat.Id_categoria = ds.ObtenerMaximo("SELECT max(idCategoria) FROM Categorias") + 1;
            bool estado = true;
            cat.Estado1 = estado;
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCategoriaAgregar(ref comando, cat);
            return ds.EjecutarProcedimientoAlmacenado(comando, "sp_CrearCategoria");
        }

        public int actualizarCategoria(Categorias cat)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCategoriaActualizar(ref comando, cat);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spActualizarCategoria");

        }

        private void ArmarParametrosCategoriaActualizar(ref SqlCommand Comando, Categorias cat)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@IDCAT", SqlDbType.Int);
            SqlParametros.Value = cat.Id_categoria;
            //SqlParametros = Comando.Parameters.Add("@NOMBRECAT", SqlDbType.VarChar, 225);
            SqlParametros = Comando.Parameters.Add("@NOMBRECAT", SqlDbType.VarChar);
            SqlParametros.Value = cat.Nombre1;
            SqlParametros = Comando.Parameters.Add("@IMAGENCAT", SqlDbType.VarChar);
            SqlParametros.Value = cat.Imagen1;
            SqlParametros = Comando.Parameters.Add("@ESTADOCAT", SqlDbType.Bit);
            SqlParametros.Value = cat.Estado1;
        }

        private void ArmarParametrosCategoriaEliminar(ref SqlCommand Comando, Categorias cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            // SqlParametros = Comando.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
            // SqlParametros = Comando.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 225);
            SqlParametros.Value = cat.Nombre1;
        }

        private void ArmarParametrosCategoriaAgregar(ref SqlCommand Comando, Categorias cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            //SqlParametros = Comando.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
            //SqlParametros = Comando.Parameters.Add("@id_categoria", SqlDbType.Int);
           // SqlParametros.Value = cat.Id_categoria;
           // SqlParametros = Comando.Parameters.Add("@NOMBRECAT", SqlDbType.VarChar);
            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar,225);
            SqlParametros.Value = cat.Nombre1;
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = cat.Estado1;
            SqlParametros = Comando.Parameters.Add("@Imagen", SqlDbType.VarChar);
            SqlParametros.Value = cat.Imagen1;
        }

        public DataTable ObtenerCategorias()
        {
            DataTable aux = new DataTable();
            AccesoaDatos ad = new AccesoaDatos();
            aux = ad.ObtenerTabla("categoria", "Select * from categoria where categoria.estado = 1");
            return aux;
        }
       

    }
}
