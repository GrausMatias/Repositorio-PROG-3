using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sucursales
    {
        private int ID_Sucursal;
        private string Nombre;
        private string Direccion;

        public Sucursales()
        {

        }

        public Sucursales(int id_sucursal, string nombre, string direccion)
        {
            ID_Sucursal1 = id_sucursal;
            Nombre1 = nombre;
            Direccion1 = direccion;
        }

        public int ID_Sucursal1 { get => ID_Sucursal; set => ID_Sucursal = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
    }
}
