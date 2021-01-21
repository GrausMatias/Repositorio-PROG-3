using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marcas
    {
        private int ID_marca;
        private string Nombre;
        private bool Estado;

        public Marcas()
        {

        }

        public int getID_Marcas()
        {
            return ID_marca;
        }
        public void setID_Marcas(int idMarcas)
        {
            ID_marca = idMarcas;
        }
        public String getNombre()
        {
            return Nombre;
        }
        public void setNombre(String nombreMarcas)
        {
            Nombre = nombreMarcas;
        }
        public bool getEstado()
        {
            return Estado;
        }
        public void setEstado(bool Estado1)
        {
            Estado = Estado1;
        }
    }
}
