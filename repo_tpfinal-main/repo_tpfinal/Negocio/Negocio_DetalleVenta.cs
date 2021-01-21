using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;

namespace Negocio
{
   public class Negocio_DetalleVenta
    {

        DaoDetalle_venta detalle_v = new DaoDetalle_venta();


        public bool Registro_detalle_venta(Detalle_venta dv)
        {
            int det_venta_exitoso = detalle_v.Registar_detalle_venta(dv);
            
            if (det_venta_exitoso == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


            
        }
        public DataTable TodosDetallesVentas(int idDetV)
        {
            DaoDetalle_venta dp = new DaoDetalle_venta();
            return dp.ObtenerTodosDetallesVentas(idDetV);
        }


    }
}
