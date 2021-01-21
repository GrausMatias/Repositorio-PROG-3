using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;


namespace Dao
{
    public class DaoSucursales
    {
        AccesoaDatos ds = new AccesoaDatos();

        public DataTable ObtenerTodasLasSucursales()
        {
            return ds.ObtenerTabla("sucursal","Select * from Sucursal");
        }
    }
}
