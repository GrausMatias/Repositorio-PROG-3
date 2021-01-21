using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;

namespace Negocio
{
    public class NegocioSucursal
    {
        public DataTable Sucursales()
        {
            DaoSucursales ds = new DaoSucursales();
            return ds.ObtenerTodasLasSucursales();
        }

    }
}
