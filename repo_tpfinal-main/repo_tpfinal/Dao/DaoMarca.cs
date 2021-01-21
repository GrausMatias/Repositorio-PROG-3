using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class DaoMarcas
    {
        AccesoaDatos ds = new AccesoaDatos();

        public Boolean existeMarcas(Marcas marc, int accion)
        {
            String consulta = "";
            if (accion == 1)
            {
                consulta = "Select * from marca where Nombre= '" + marc.getNombre() + "'";
            }
            else if (accion == 2)
            {
                consulta = "Select * from marca where Nombre='" + marc.getNombre() + "' AND ID_marca != '" + marc.getID_Marcas() + "'";
            }
            return ds.existe(consulta);
        }

        public DataTable getTablaMarcas()
        {
            // List<Marcas> lista = new List<Marcas>();
            DataTable tabla = ds.ObtenerTabla("marca", "Select * from marca");
            return tabla;
        }

        public int eliminarMarcas(Marcas marc)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMarcasEliminar(ref comando, marc);
            //SE INGRESA EL NOMBRE DEL PROCEDIMIENTO ALMACENADO
            return ds.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarMarca");
        }
        public int ActualizarMarcas(Marcas marc)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMarcasActualizar(ref comando, marc);
            //SE INGRESA EL NOMBRE DEL PROCEDIMIENTO ALMACENADO
            return ds.EjecutarProcedimientoAlmacenado(comando, "sp_ActualizarMarca");
        }

        public int agregarMarcas(Marcas marc)
        {
            marc.setEstado(true);
            SqlCommand comando = new SqlCommand();
            //SE INGRESA EL NOMBRE DEL PROCEDIMIENTO ALMACENADO
            ArmarParametrosMarcasAgregar(ref comando, marc);
            //SE INGRESA EL NOMBRE DEL PROCEDIMIENTO ALMACENADO
            return ds.EjecutarProcedimientoAlmacenado(comando, "sp_Create_Marca");
        }

        private void ArmarParametrosMarcasEliminar(ref SqlCommand Comando, Marcas marc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Nombre_v", SqlDbType.VarChar);
            SqlParametros.Value = marc.getNombre();
        }
        private void ArmarParametrosMarcasActualizar(ref SqlCommand Comando, Marcas marc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@ID_marca_v", SqlDbType.Int);
            SqlParametros.Value = marc.getID_Marcas();
            SqlParametros = Comando.Parameters.Add("@Nombre_v", SqlDbType.VarChar);
            SqlParametros.Value = marc.getNombre();
            SqlParametros = Comando.Parameters.Add("@Estado_v", SqlDbType.Bit);
            SqlParametros.Value = marc.getEstado();
        }
        private void ArmarParametrosMarcasAgregar(ref SqlCommand Comando, Marcas marc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Nombre_v", SqlDbType.VarChar);
            SqlParametros.Value = marc.getNombre();
            //INGRESE EL PARAMETRO NOMBRE DE LA MARCA
            SqlParametros = Comando.Parameters.Add("@Estado_v", SqlDbType.VarChar);
            SqlParametros.Value = marc.getEstado();
        }
        public DataTable BusquedaDeMarcas(String texto)
        {
            return ds.ObtenerTabla("marca", "Select ID_marca, marca.Nombre, Estado from marca WHERE marca.Nombre LIKE '%" + texto + "%'");
        }

    }
}