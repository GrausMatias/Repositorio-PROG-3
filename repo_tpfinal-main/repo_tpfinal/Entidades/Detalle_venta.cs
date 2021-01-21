using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Detalle_venta
    {
        private int id_venta;
        private int id_detalle_venta;
        private int id_producto;
        private int cantidad;
        private decimal precio_unitario;



        public Detalle_venta()
        {

        }

        public int getId_venta()
        {
            return id_venta;
        }

        public int getId_detalleventa()
        {
            return id_detalle_venta;
        }

        public int getid_producto()
        {
            return id_producto;
        }


        public int getCantidad()
        {
            return cantidad;
        }

        public decimal getPrecio_unitario()
        {
            return precio_unitario;
        }

        public void set_idventa(int idventa)
        {
            id_venta = idventa;
        }

        public void set_idDetalleventa(int id_detalleventa)
        {
            id_detalle_venta = id_detalleventa;
        }

        public void set_cantidad(int cant)
        {
            cantidad = cant;
        }

        public void set_precio_u(decimal pu)
        {
            precio_unitario = pu;
        }

        public void set_idproducto (int idp)
        {
            id_producto = idp;
        }

     

    }
}
