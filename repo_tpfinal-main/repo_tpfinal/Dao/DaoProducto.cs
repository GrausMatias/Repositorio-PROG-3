using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoProducto
    {
        AccesoaDatos ds = new AccesoaDatos();

        public bool ComprobarNombreRepetido(Producto pro)
        {
            AccesoaDatos datos = new AccesoaDatos();
            SqlParameter SqlParametros = new SqlParameter();
            SqlCommand comando = new SqlCommand();
            int CantRepetidos=0;
            bool estado;

            SqlParametros = comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 255);
            SqlParametros.Value = pro.Nombre1;

            CantRepetidos = datos.EjecutarProcedimientoAlmacenado2(comando, "spBuscarProductoRepetido");

            if (CantRepetidos == 1)
                estado = true;
            else
                estado = false;

            return estado;
        }

        public DataTable ObtenerTodosLosProductos()
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, marca.Nombre as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.estado AS Estado  from producto inner join marca on producto.ID_marca = marca.ID_marca inner join categoria on categoria.id_categoria = producto.ID_categoria");
        }
        public DataTable ObtenerTodosLosProductosConImagen()
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, marca.Nombre as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen  from producto inner join marca on producto.ID_marca = marca.ID_marca inner join categoria on categoria.id_categoria = producto.ID_categoria where producto.Stock > 0");
        }

        public DataTable BusquedaDeProductos(String texto)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, marca.Nombre as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.estado AS Estado  from producto inner join marca on producto.ID_marca = marca.ID_marca inner join categoria on categoria.id_categoria = producto.ID_categoria WHERE producto.Nombre LIKE '%" + texto + "%'");
        }

        public DataTable ObtenerUnProducto(String id)
        {
            DataTable aux = new DataTable();
            aux = ds.ObtenerTabla("producto", "Select * from producto WHERE id_producto = " + id);
            return aux;
        }

        // CONSULTA UNIVERSAL DE FILTROS? XD
        public DataTable ObtenerProdsConFiltro(String Consulta)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 " + Consulta);
        }
        //----------------------------------------------------------------

        public DataTable ObtenerProdsXIdCategoria(String codProd)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 AND producto.ID_Categoria = " + codProd);
        }
        //------------------FILTROS PRODUCTOS-----------------------------
        public DataTable ObtenerProdsXIdMayorAMenor(String codProd)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 AND producto.ID_Categoria = " + codProd + " order by Precio desc");
        }
        public DataTable ObtenerProdsXIdNuevos(String codProd)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 AND producto.ID_Categoria = " + codProd + " order by ID desc");
        }
        public DataTable ObtenerProdsXIdViejos(String codProd)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 AND producto.ID_categoria =" + codProd + " order by ID asc");
        }
        public DataTable ObtenerProdsXIdMenorAMayor(String codProd)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 AND producto.ID_categoria =" + codProd + "order by Precio asc");
        }
        public DataTable ObtenerProdsMarca(String id, String codigo)
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto  inner join marca on marca.ID_marca = producto.ID_marca where producto.estado = 1 AND producto.Stock > 0 AND producto.ID_marca = " + codigo + " AND producto.ID_categoria =" +id);
        }
        //---sin id categoria----
        public DataTable ObtenerProdsDeMayorAMenor()
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 order by Precio desc");
        }
        public DataTable ObtenerProdsDeMenorAMayor()
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 order by Precio asc");
        }
        public DataTable ObtenerProdsNuevos()
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 order by ID desc");
        }
        public DataTable ObtenerProdsViejos()
        {
            return ds.ObtenerTabla("producto", "Select id_Producto as ID, producto.Nombre as Producto, producto.ID_marca as Marca, producto.Stock as Disponibles, producto.Precio_unitario as Precio, producto.Imagen AS Imagen from producto where producto.estado = 1 AND producto.Stock > 0 order by ID asc");
        }
        //-------------------------------------------------------------------
        public DataTable ObtenerProductos()
        {
            return ds.ObtenerTabla("producto", "Select * from producto where producto.estado = 'true'");
        }
        public DataTable CantidadProductos()
        {
            DataTable aux = new DataTable();
            AccesoaDatos ad = new AccesoaDatos();
            aux = ad.ObtenerTabla("producto", "Select count(producto.id_producto) from producto where producto.Estado = 1");
            return aux;
        }
        public DataTable CantidadTotalProductos()
        {
            DataTable aux = new DataTable();
            AccesoaDatos ad = new AccesoaDatos();
            aux = ad.ObtenerTabla("producto", "Select count(producto.id_producto) from producto");
            return aux;
        }
        public DataTable CantidadUsuarios()
        {
            DataTable aux = new DataTable();
            AccesoaDatos ad = new AccesoaDatos();
            aux = ad.ObtenerTabla("usuario", "Select count(usuario.id_usuario) from usuario");
            return aux;
        }
        public DataTable CantidadUsuariosAdmin()
        {
            DataTable aux = new DataTable();
            AccesoaDatos ad = new AccesoaDatos();
            aux = ad.ObtenerTabla("usuario", "Select count(usuario.id_usuario) from usuario where rol =2");
            return aux;
        }
        public DataTable ObtenerProductosProd()
        {
            DataTable aux = new DataTable();
            AccesoaDatos ad = new AccesoaDatos();
            aux = ad.ObtenerTabla("producto", "select producto.id_producto as ID, producto.nombre as Nombre, producto.imagen as Imagen, producto.Stock as Stock, producto.Descripcion as Descripcion, producto.Precio_unitario as Precio, producto.Stock as Stock from producto");
            return aux;
        }
        public DataTable ObtenerDatosId(String id)
        {
            DataTable aux = new DataTable();
            AccesoaDatos ad = new AccesoaDatos();
            aux = ad.ObtenerTabla("producto", "select producto.id_producto as ID, producto.nombre as Nombre, producto.imagen as Imagen, producto.Stock as Stock, producto.Descripcion as Descripcion, producto.Precio_unitario as Precio, producto.Stock as Stock from producto where id_producto = " + id);
            return aux;
        }
        public void ArmarParametrosProductoActualizado(ref SqlCommand Comando, Producto productos)
        {
            SqlParameter sqlparametros = new SqlParameter();
            sqlparametros = Comando.Parameters.Add("@IDPROD", SqlDbType.Int);
            sqlparametros.Value = productos.Id_producto;
            sqlparametros = Comando.Parameters.Add("@STOCK", SqlDbType.Int);
            sqlparametros.Value = productos.Stock1;
            sqlparametros = Comando.Parameters.Add("@MARCA", SqlDbType.Int);
            sqlparametros.Value = productos.ID_marca1;
            sqlparametros = Comando.Parameters.Add("@PRECIO", SqlDbType.Float);
            sqlparametros.Value = productos.Precio_unitario1;
            sqlparametros = Comando.Parameters.Add("@CATEGORIA", SqlDbType.Int);
            sqlparametros.Value = productos.ID_categoria1;
            sqlparametros = Comando.Parameters.Add("@ESTADO", SqlDbType.Int);
            sqlparametros.Value = productos.Estado1;
            sqlparametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 255);
            sqlparametros.Value = productos.Nombre1;
            sqlparametros = Comando.Parameters.Add("@IMAGEN", SqlDbType.VarChar, 255);
            sqlparametros.Value = productos.Imagen1;
            sqlparametros = Comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 255);
            sqlparametros.Value = productos.Descripcion1;
        }

        public void ArmarParametrosProductoNuevo(ref SqlCommand Comando, Producto productos)
        {
            SqlParameter sqlparametros = new SqlParameter();
            sqlparametros = Comando.Parameters.Add("@STOCK", SqlDbType.Int);
            sqlparametros.Value = productos.Stock1;
            sqlparametros = Comando.Parameters.Add("@MARCA", SqlDbType.Int);
            sqlparametros.Value = productos.ID_marca1;
            sqlparametros = Comando.Parameters.Add("@PRECIO", SqlDbType.Decimal, 18);
            sqlparametros.Value = productos.Precio_unitario1;
            sqlparametros = Comando.Parameters.Add("@CATEGORIA", SqlDbType.Int);
            sqlparametros.Value = productos.ID_categoria1;
            sqlparametros = Comando.Parameters.Add("@ESTADO", SqlDbType.Int);
            sqlparametros.Value = productos.Estado1;
            sqlparametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 255);
            sqlparametros.Value = productos.Nombre1;
            sqlparametros = Comando.Parameters.Add("@IMAGEN", SqlDbType.VarChar, 255);
            sqlparametros.Value = productos.Imagen1;
            sqlparametros = Comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 255);
            sqlparametros.Value = productos.Descripcion1;
        }
        public int CrearProducto(Producto pro)
        {
            int estado = 1;
            Producto p = new Producto();
            p.Estado1 = estado;
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoNuevo(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spBuscarProductoRepetido");
        }

        public int eliminarProducto(SqlCommand Comando, String NombreSP, int Id)
        {
            AccesoaDatos ad = new AccesoaDatos();
            SqlConnection Conexion = ad.ObtenerConexion();
            SqlCommand cmd = new SqlCommand();

            int FilasCambiadas;
            cmd = Comando;

            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            cmd.Parameters.Add("@id_producto_programa", SqlDbType.Int).Value = Id;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();

            return FilasCambiadas;
        }

        public int descontarStock(SqlCommand Comando, String NombreSP, int id, int stock)
        {
            AccesoaDatos ad = new AccesoaDatos();
            SqlConnection Conexion = ad.ObtenerConexion();
            SqlCommand cmd = new SqlCommand();

            int FilasCambiadas;
            cmd = Comando;

            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            cmd.Parameters.Add("@id_producto", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@stock", SqlDbType.Int).Value = stock;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();

            return FilasCambiadas;
        }

        public DataTable ObtenerProductosPorFecha_R1(string f1)
        {
            DateTime d1 = Convert.ToDateTime(f1);
            var dateTime1 = d1;
            //SACA LA HORA 
            f1 = dateTime1.ToShortDateString();
            string consulta = "";
            DataTable tabla = new DataTable();
            try {
                consulta = "SELECT p.Nombre as Producto,sum(dv.Cantidad) as Cantidad_Vendida FROM producto p INNER JOIN detalle_venta dv ON dv.ID_producto = p.id_producto INNER JOIN venta v ON dv.ID_venta = v.ID_venta WHERE v.Fecha = '" + f1 + "' GROUP BY p.Nombre ORDER BY SUM(dv.cantidad) DESC";
                tabla = ds.ObtenerTabla("producto", consulta);
            }
            catch
            {
                consulta = "SELECT p.Nombre as Producto,sum(dv.Cantidad) as Cantidad_Vendida FROM producto p INNER JOIN detalle_venta dv ON dv.ID_producto = p.id_producto INNER JOIN venta v ON dv.ID_venta = v.ID_venta WHERE v.Fecha = '" + d1.ToString("yyyy-MM-dd") + "' GROUP BY p.Nombre ORDER BY SUM(dv.cantidad) DESC";
                tabla = ds.ObtenerTabla("producto", consulta);
            }
            return tabla;
        }

    }
}
