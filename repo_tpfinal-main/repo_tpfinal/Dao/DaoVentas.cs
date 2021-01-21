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
   public class DaoVentas
    {
        AccesoaDatos acceder = new AccesoaDatos();
        public int Registrar_Venta(Ventas vent)
        {
            SqlCommand comando = new SqlCommand();

            ParametrosRegistroVentas(ref comando, vent);

            return acceder.EjecutarProcedimientoAlmacenado(comando, "spRegistrarVenta");
        }



       public DataTable id_ultimaventa()
        {
            string consulta = "SELECT TOP 1 ID_VENTA from venta order by ID_venta desc";

            return acceder.ObtenerTabla("venta",consulta);
        }

        private void ParametrosRegistroVentas(ref SqlCommand comando, Ventas ven)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@FECHAVENTA", SqlDbType.DateTime);
            SqlParametros.Value = ven.Fecha1;
            SqlParametros = comando.Parameters.Add("@ID_USUARIO", SqlDbType.Int);
            SqlParametros.Value = ven.ID_usuario1;
            SqlParametros = comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar);
            SqlParametros.Value = ven.Direccion1;
            SqlParametros = comando.Parameters.Add("@TOTAL", SqlDbType.Decimal);
            SqlParametros.Value = ven.Total1;
            SqlParametros = comando.Parameters.Add("@MODO_ENVIO", SqlDbType.Int);
            SqlParametros.Value = ven.Modo_envio1;
            SqlParametros = comando.Parameters.Add("@MODO_PAGO", SqlDbType.Int);
            SqlParametros.Value = ven.Modo_pago1;
            SqlParametros = comando.Parameters.Add("@NROTARJETA", SqlDbType.VarChar);
            SqlParametros.Value = ven.Nro_tarjeta1;
            SqlParametros = comando.Parameters.Add("@CODTARJETA", SqlDbType.VarChar);
            SqlParametros.Value = ven.Codigo_tarjeta1;
            SqlParametros = comando.Parameters.Add("@ID_SUCURSAL", SqlDbType.Int);
            SqlParametros.Value = ven.ID_sucursal1;


        }

        public DataTable Reporte3(String Consulta, String Order)
        {
            return acceder.ObtenerTabla("venta", "SELECT venta.ID_venta as ID, venta.Total AS TOTAL,  FORMAT (venta.Fecha, 'dd-MM-yyyy') AS FECHA, SUM (detalle_venta.Cantidad) AS CANTIDAD FROM venta INNER JOIN detalle_venta ON venta.ID_venta = detalle_venta.ID_venta WHERE venta.ID_venta = detalle_venta.ID_venta " + Consulta + " Group by venta.ID_venta, venta.Total, venta.Fecha" + Order);
        }


        public DataTable ObtenerTodasLasVentas()
        {
            return acceder.ObtenerTabla("venta", "SELECT ID_venta, FORMAT (venta.Fecha, 'dd-MM-yyyy') as Fecha, ID_usuario , VENTA.Direccion, Total, Nro_tajeta,Nombre_Envio,Descripcion,Nombre FROM venta INNER JOIN envio ON envio.ID_envio = VENTA.Modo_envio INNER JOIN PAGO ON PAGO.ID_pago = venta.Modo_pago INNER JOIN sucursal ON sucursal.ID_Sucursal = venta.ID_sucursal");
        }

        public DataTable ObtenerTodasLasVentasUsuario(string Nombre)
        {
            DataTable Tabla = acceder.ObtenerTabla("venta", "select ID_venta, FORMAT (venta.Fecha, 'dd-MM-yyyy') AS FECHA, venta.Direccion,Nro_tajeta,Total from venta inner join usuario on venta.ID_usuario = usuario.ID_usuario where usuario.Nombre_Usuario ='" + Nombre + "'");
            return Tabla;
        }

        public DataTable ObtenerDetallesVentasUsuario(int idDetV)
        {

            return acceder.ObtenerTabla("detalle_venta", "select producto.Nombre, detalle_venta.Cantidad, detalle_venta.Precio_unitario from detalle_venta inner join venta on detalle_venta.ID_venta = venta.ID_venta inner join producto on detalle_venta.ID_producto = producto.id_producto  where detalle_venta.ID_venta = " + idDetV);
        }

        public DataTable ObtenerTodasLasVentasPorFecha(string f1, string f2, string orden)
        {
            DateTime d1 = Convert.ToDateTime(f1);
            DateTime d2 = Convert.ToDateTime(f2);
            var dateTime1 = d1;
            var dateTime2 = d2;
            //SACA LA HORA 
            f1 = dateTime1.ToShortDateString();
            f2 = dateTime2.ToShortDateString();

            int res = DateTime.Compare(d1, d2);

            string consulta = "";

            if (orden == "Mayor")
            {
                try
                {
                    if (res > 0)
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + f2 + "' and '" + f1 + "' GROUP BY Fecha ORDER BY Fecha DESC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                    else
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + f1 + "' and '" + f2 + "' GROUP BY Fecha ORDER BY Fecha DESC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                }
                catch
                {
                    if (res > 0)
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + d2.ToString("yyyy-MM-dd") + "' and '" + d1.ToString("yyyy-MM-dd") + "' GROUP BY Fecha ORDER BY Fecha DESC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                    else
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' GROUP BY Fecha ORDER BY Fecha DESC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                }

            }
            else
            {
                try
                {
                    if (res > 0)
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + f2 + "' and '" + f1 + "' GROUP BY Fecha ORDER BY Fecha ASC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                    else
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + f1 + "' and '" + f2 + "' GROUP BY Fecha ORDER BY Fecha ASC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                }
                catch
                {
                    if (res > 0)
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + d2.ToString("yyyy-MM-dd") + "' and '" + d1.ToString("yyyy-MM-dd") + "' GROUP BY Fecha ORDER BY Fecha ASC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                    else
                    {
                        consulta = "SELECT FORMAT (venta.Fecha, 'dd-MM-yyyy') AS Fecha,COUNT(Fecha) AS 'Ventas' FROM venta WHERE Fecha between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' GROUP BY Fecha ORDER BY Fecha ASC";
                        return acceder.ObtenerTabla("venta", consulta);
                    }
                }
            }

        }

    }
}
