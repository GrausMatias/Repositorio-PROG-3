using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        private int id_categoria;
        private string Nombre;
        private bool Estado;
        private String Imagen;

        public Categorias()
        {

        }

        public Categorias(int id_categoria, string nombre, bool estado, String imagen)
        {
            this.Id_categoria = id_categoria;
            Nombre1 = nombre;
            Estado1 = estado;
            Imagen1 = imagen;
        }

        public int Id_categoria { get => id_categoria; set => id_categoria = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
        public string Imagen1 { get => Imagen; set => Imagen = value; }
    }

}