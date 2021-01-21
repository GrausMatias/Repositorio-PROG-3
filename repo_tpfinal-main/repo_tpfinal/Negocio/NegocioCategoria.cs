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
    public class NegocioCategoria
    {

        //public bool eliminarCategoria(int id)
        //{
            //Validar id existente 
            //DaoCategoria dao = new DaoCategoria();
            //Categorias cat = new Categorias();
            //cat.setIdCategoria(id);
            //cat.Id_categoria = id;

            //int op = dao.eliminarCategoria(cat);
            //if (op == 1)
              //  return true;
            //else
              //  return false;
        //}

        public bool agregarCategoria(String nombre, String imagen)
        {
            int cantFilas = 0;

            Categorias cat = new Categorias();
            //cat.setNombreCategoria(nombre);
            cat.Nombre1 = nombre;
            cat.Imagen1 = imagen;
            DaoCategoria dao = new DaoCategoria();

            cantFilas = dao.agregarCategoria(cat);

            /*
            if (dao.existeCategoría(cat) == false) //si la categ no existe, LA AGREGA
            {
                cantFilas = dao.agregarCategoria(cat);
            }
            */
            if (cantFilas == 1) //si se guardo correctamente va true
                return true;
            else
                return false;
        }

        public bool actualizarCategoria(Categorias cat)
        {
            int cantFilas = 0;
            //Categorias cat = new Categorias;
            DaoCategoria dao = new DaoCategoria();

            cantFilas = dao.actualizarCategoria(cat);

            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
                

        }

        

        public bool eliminarCategoria(String nombre)
        {
            int op = 0;
            //Validar id existente 
            DaoCategoria dao = new DaoCategoria();
            Categorias cat = new Categorias();
            cat.Nombre1 = nombre;
            if (dao.existeCategoría(cat) == true)
            {
                op = dao.eliminarCategoria(cat);
            }
            
            if (op == 1)
                return true;
            else
                return false;
        }



        public DataTable TodasLasCategorias()
        {
            DaoCategoria dp = new DaoCategoria();
            return dp.ObtenerTodasLasCategorias();
        }
        public DataTable ObtenerCategorias()
        {
            DaoCategoria dm = new DaoCategoria();
            return dm.ObtenerCategorias();
        }

        public DataTable BuscarCategoria(String texto) //para poder buscar por nombre
        {
            DaoCategoria dc = new DaoCategoria();
            return dc.BusquedaDeCategoria(texto);
        }

        //////////////////////


    }
}
