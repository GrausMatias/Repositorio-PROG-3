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
    public class NegocioMarca
    {
        public bool eliminarMarcas_neg(String nombre)
        {
            //Validar id existente 
            DaoMarcas dao = new DaoMarcas();
            Marcas marc = new Marcas();
            marc.setNombre(nombre);
            int op = dao.eliminarMarcas(marc);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool ActualizarMarca_neg(Marcas marc)
        {
            DaoMarcas dao = new DaoMarcas();
            int op = dao.ActualizarMarcas(marc);
            if (op == 1)
                return true;
            else
            return false;
        }

        public bool agregarMarcas_neg(String nombre)
        {
            int cantFilas = 0;

            Marcas marc = new Marcas();
            marc.setNombre(nombre);

            DaoMarcas dao = new DaoMarcas();
            if (dao.existeMarcas(marc,1) == false)
            {
                cantFilas = dao.agregarMarcas(marc);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool ExisteMarcas_Neg(Marcas marc)
        {
            DaoMarcas dao = new DaoMarcas();
            return dao.existeMarcas(marc, 2);
        }

        public DataTable cargar_gridview_neg()
        {
            DaoMarcas dao = new DaoMarcas();

            return dao.getTablaMarcas();
        }

        public DataTable BuscarMarcas(String texto)
        {
            DaoMarcas dao = new DaoMarcas();
            return dao.BusquedaDeMarcas(texto);
        }
    }
}

