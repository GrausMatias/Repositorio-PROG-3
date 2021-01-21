using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private int id_producto;
        private int Stock;
        private int ID_marca;
        private decimal Precio_unitario;
        private int ID_categoria;
        private int Estado;
        private String Nombre;
        private String Imagen;
        private String Descripcion;

        public Producto()
        {

        }

        public Producto(int id_producto, int stock, int id_marca, decimal precio_unitario, int id_categoria, int estado, string nombre, string imagen, string descripcion)
        {
            this.id_producto = id_producto;
            Stock = stock;
            ID_marca = id_marca;
            Precio_unitario = precio_unitario;
            ID_categoria = id_categoria;
            Estado = estado;
            Nombre = nombre;
            Imagen = imagen;
            Descripcion = descripcion;
        }

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public int ID_marca1 { get => ID_marca; set => ID_marca = value; }
        public decimal Precio_unitario1 { get => Precio_unitario; set => Precio_unitario = value; }
        public int ID_categoria1 { get => ID_categoria; set => ID_categoria = value; }
        public int Estado1 { get => Estado; set => Estado = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Imagen1 { get => Imagen; set => Imagen = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

    }
}
