using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Dao
{
    public class DaoDetalle_venta
    {
        AccesoaDatos acceder = new AccesoaDatos();

        public int Registar_detalle_venta(Detalle_venta det_vent)
        {
            SqlCommand comando = new SqlCommand();

            Parametros_registro_detalle_venta(ref comando, det_vent);

            return acceder.EjecutarProcedimientoAlmacenado(comando, "SpDetalleVentaRegistro");
        }


        private void Parametros_registro_detalle_venta (ref SqlCommand comando, Detalle_venta det_vent)
        {

            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = comando.Parameters.Add("@IDVENTA", SqlDbType.Int);
            SqlParametros.Value = det_vent.getId_venta();
            SqlParametros = comando.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int);
            SqlParametros.Value = det_vent.getid_producto();
            SqlParametros = comando.Parameters.Add("@CANTIDAD", SqlDbType.Int);
            SqlParametros.Value = det_vent.getCantidad();
            SqlParametros = comando.Parameters.Add("@PRECIO_UNITARIO", SqlDbType.Decimal);
            SqlParametros.Value = det_vent.getPrecio_unitario();
           

        }

        public DataTable ObtenerTodosDetallesVentas(int idDetV)
        {

            return acceder.ObtenerTabla("detalle_venta", "Select ROW_NUMBER() OVER(ORDER BY ID_detalle_venta) AS #, producto.Nombre , Cantidad, detalle_venta.Precio_unitario AS 'Precio' from detalle_venta INNER JOIN producto on producto.id_producto = detalle_venta.ID_producto WHERE ID_venta= " + idDetV);
        }

    }
}
