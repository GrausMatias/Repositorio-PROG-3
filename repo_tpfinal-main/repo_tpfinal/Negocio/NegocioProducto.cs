using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioProducto
    {
        AccesoaDatos ad = new AccesoaDatos();
        public bool ActualizarProducto(Producto Pro)
        {
            int FilasInsertadas = 0;
            SqlCommand Comando = new SqlCommand();
            AccesoaDatos ad = new AccesoaDatos();
            DaoProducto dp = new DaoProducto();
            NegocioProducto ngp = new NegocioProducto();

            if (dp.ComprobarNombreRepetido(Pro) == false)
            {
                dp.ArmarParametrosProductoActualizado(ref Comando, Pro);
                FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spActualizarProducto");
                if (FilasInsertadas == 1)
                    return true;
                else
                    return false;

            }
            else{
                return false;
            }   
        }

        public bool CrearProducto(Producto Pro)
        {
            int FilasInsertadas = 0;
            SqlCommand Comando = new SqlCommand();
            DaoProducto dp = new DaoProducto();
            dp.ArmarParametrosProductoNuevo(ref Comando, Pro);
            FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spCrearProducto");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public bool agregarProducto(Producto producto)
        {
            DaoProducto dao = new DaoProducto();
            NegocioProducto ngp = new NegocioProducto();

            if (dao.ComprobarNombreRepetido(producto) == false)
            {
                return ngp.CrearProducto(producto);

            } else
            {
                return false;
            }
        }
        public bool EliminarProducto(Producto producto)
        {
            SqlCommand Comando = new SqlCommand();
            AccesoaDatos ad = new AccesoaDatos();
            DaoProducto dp = new DaoProducto();
            int filasEliminadas = dp.eliminarProducto(Comando, "spEliminarProducto", producto.Id_producto);
            if (filasEliminadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ActivarProducto(Producto producto)
        {
            SqlCommand Comando = new SqlCommand();
            AccesoaDatos ad = new AccesoaDatos();
            DaoProducto dp = new DaoProducto();
            int filasActualizadas = dp.eliminarProducto(Comando, "spActivarProducto", producto.Id_producto);
            if (filasActualizadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActualizarStock(int id, int stock)
        {
            SqlCommand Comando = new SqlCommand();
            AccesoaDatos ad = new AccesoaDatos();
            DaoProducto dp = new DaoProducto();
            int filasActualizadas = dp.descontarStock(Comando, "spDescontarStock", id, stock);
            if (filasActualizadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable TodosLosProductos()
        {
            DaoProducto dp = new DaoProducto();
            return dp.ObtenerTodosLosProductos();
        }
        public DataTable TodosLosProductosConImagen()
        {
            DaoProducto dp = new DaoProducto();
            return dp.ObtenerTodosLosProductosConImagen();
        }
        public DataTable BuscarProductos(String texto)
        {
            DaoProducto dp = new DaoProducto();
            return dp.BusquedaDeProductos(texto);
        }
        public DataTable ObtenerProducto(String id)
        {
            DaoProducto dp = new DaoProducto();
            return dp.ObtenerUnProducto(id);
        }
        public DataTable ObtenerProdsXIdCategoria(String id)
        {
            DaoProducto dp = new DaoProducto();
            return dp.ObtenerProdsXIdCategoria(id);
        }
        public DataTable ObtenerMarcas()
        {
            DaoMarcas dm = new DaoMarcas();
            return dm.getTablaMarcas();
        }
        public DataTable ObtenerCantidadProductos()
        {
            DaoProducto dm = new DaoProducto();
            return dm.CantidadProductos();
        }
        
        public DataTable ObtenerCantidadTotal()
        {
            DaoProducto dm = new DaoProducto();
            return dm.CantidadTotalProductos();
        }
        public DataTable ObtenerProductoFiltro(String id, String tipo)
        {
            DaoProducto dm = new DaoProducto();

            switch(tipo){
                case "Mayor":
                    return dm.ObtenerProdsXIdMayorAMenor(id);
                case "Menor":
                    return dm.ObtenerProdsXIdMayorAMenor(id);
                case "Viejo":
                    return dm.ObtenerProdsXIdViejos(id);
                case "Nuevo":
                    return dm.ObtenerProdsXIdNuevos(id);
                default:
                    return dm.ObtenerTodosLosProductosConImagen();
            }

        }

        public DataTable ObtenerFiltroMarca (String id, String marca)
        {
            DaoProducto dm = new DaoProducto();
            return dm.ObtenerProdsMarca(id, marca);
        }

        public DataTable ObtenerProdsConFiltro(String Consulta)
        {
            DaoProducto dm = new DaoProducto();
            return dm.ObtenerProdsConFiltro(Consulta);
        }

        public DataTable ObtenerProdPorPrecioSinCategoria(String tipo)
        {
            DaoProducto dm = new DaoProducto();
            switch (tipo)
            {
                case "Mayor":
                    return dm.ObtenerProdsDeMayorAMenor();
                case "Menor":
                    return dm.ObtenerProdsDeMenorAMayor();
                case "Viejo":
                    return dm.ObtenerProdsViejos();
                case "Nuevo":
                    return dm.ObtenerProdsNuevos();
                default:
                    return dm.ObtenerTodosLosProductosConImagen();
            }

        }
        public DataTable ObtenerDatosProducto()
        {
            DaoProducto dm = new DaoProducto();
            return dm.ObtenerProductosProd();
        }
         public DataTable ObtenerProductoId(String id)
        {
            DaoProducto dm = new DaoProducto();
            return dm.ObtenerDatosId(id);
        }

        public DataTable cargar_gridview_neg_reporte1_tex(string fecha)
        {
            DaoProducto dm = new DaoProducto();
            return dm.ObtenerProductosPorFecha_R1(fecha);
        }

    }
}