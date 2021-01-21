using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        private int ID_venta;
        private DateTime Fecha;
        private int ID_usuario;
        private string Direccion;
        private float Total;
        private int Modo_envio;
        private int Modo_pago;
        private string Nro_tarjeta;
        private string Codigo_tarjeta;
        private int ID_sucursal;
        ///


        public Ventas()
        {

        }

        public Ventas(int id_venta, DateTime fecha, int id_usuario, string direccion, float total, int modo_envio, int modo_pago, string nro_tarjeta, string codigo_tarjeta, int id_sucursal)
        {
            ID_venta1 = id_venta;
            Fecha1 = fecha;
            ID_usuario1 = id_usuario;
            Direccion1 = direccion;
            Total1 = total;
            Modo_envio1 = modo_envio;
            Modo_pago1 = modo_pago;
            Nro_tarjeta1 = nro_tarjeta;
            Codigo_tarjeta1 = codigo_tarjeta;
            ID_sucursal1 = id_sucursal;
        }

        public int ID_venta1 { get => ID_venta; set => ID_venta = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
        public int ID_usuario1 { get => ID_usuario; set => ID_usuario = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public float Total1 { get => Total; set => Total = value; }
        public int Modo_envio1 { get => Modo_envio; set => Modo_envio = value; }
        public int Modo_pago1 { get => Modo_pago; set => Modo_pago = value; }
        public string Nro_tarjeta1 { get => Nro_tarjeta; set => Nro_tarjeta = value; }
        public string Codigo_tarjeta1 { get => Codigo_tarjeta; set => Codigo_tarjeta = value; }
        public int ID_sucursal1 { get => ID_sucursal; set => ID_sucursal = value; }
    }
}
