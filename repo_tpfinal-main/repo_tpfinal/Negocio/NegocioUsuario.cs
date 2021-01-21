using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioUsuario
    {
        public DataTable getTabla()
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getTablaUsuario();
        }

        public DataTable getTablaBuscarNombre(string Nombre)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getTablaUsuarioEspecifico(Nombre);
        }

        public DataTable getTablaBuscarApellido(string Nombre)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getTablaUsuarioEspecificoApellido(Nombre);
        }

        public bool BuscarUsuarioNombre(string Nombre)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeUsuario(Nombre);
            if (Existe == true)
            {
                getTablaBuscarNombre(Nombre);
                return true;
            }
            else
            {
                return false;
            }
        }



     /*   public DataTable llenarcamposusuarios(int id)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getTablaCamposUsuarios(id);


        }*/

        public bool BuscarUsuarioApellido(string Nombre)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeUsuarioApellido(Nombre);
            if (Existe == true)
            {
                getTablaBuscarApellido(Nombre);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CrearUsuario(Usuarios usuario)
        {
            DaoUsuario dao = new DaoUsuario();

            if (dao.existeUsuario(usuario.getNombre_UsuarioUsuario()))
            {
                return true;
            }
            else
            {
                dao.agregarNuevoUsuario(usuario); 
                return false;
            }

        }

        public void CrearUsuarioDirecto(Usuarios usuario)
        {
            DaoUsuario dao = new DaoUsuario();
            dao.agregarNuevoUsuario(usuario);

        }


        public bool eliminarUsuarioAdmin_neg(int id)
        {
            //Validar usuarioadmin
            DaoUsuario dao = new DaoUsuario();
            Usuarios usu = new Usuarios();
            usu.setID_usuario(id);
            int op = dao.eliminarUsuarioAdmin(usu);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool BuscarUsuarioNombre_Usuario(string Nombre_Usuario)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeUsuarioNombre_Usuario(Nombre_Usuario);
            if (Existe == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BuscarUsuarioEmail(string Email_Usuario)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeUsuarioEmail(Email_Usuario);
            if (Existe == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BuscarUsuarioDni(string Dni_Usuario)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeUsuarioDni(Dni_Usuario);
            if (Existe == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public DataTable ObtenerUsuario(String id)
        {
            DaoUsuario dp = new DaoUsuario();
            return dp.ObtenerUnUsuario(id);
        }

        public bool BuscarUsuarioPassword(string Password)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeUsuarioPassword(Password);
            if (Existe == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BuscarUsuarioYclave(string Nombre_Usuario, string Clave)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeUsuarioYclave(Nombre_Usuario, Clave);
            if (Existe == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Boolean existe_id_user(int id)
        {
            DaoUsuario dao = new DaoUsuario();
            bool Existe = dao.existeid_usuario(id);
            if (Existe ==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ActualizarUsuario(Usuarios user)
        {


            DaoUsuario datos = new DaoUsuario();

            int actualizo = datos.actualizar_datos_usuario_en_bd(user);

            return actualizo;


        }

        public DataTable ObtenerCantidadUsuarios()
        {
            DaoUsuario du = new DaoUsuario();
            return du.CantidadTotalUsuarios();
        }
        public DataTable ObtenerCantidadAdmin()
        {
            DaoUsuario du = new DaoUsuario();
            return du.CantidadUsuarioAdmin();
        }

        //-------------------------------------------------------------------------
        public Usuarios DevolverUsuarioCompleto(string NombreUsuario)
        {
            DaoUsuario dao = new DaoUsuario();
            Usuarios Usu = new Usuarios();
            DataTable Con = dao.getTablaUsuarioCompleto(NombreUsuario);

            Usu.setID_usuario(Convert.ToInt32(Con.Rows[0]["ID_usuario"]));
            Usu.setNombreUsuario(Con.Rows[0]["Nombre"].ToString());
            Usu.setApellidoUsuario(Con.Rows[0]["Apellido"].ToString());
            Usu.setEmailUsuario(Con.Rows[0]["Email"].ToString());
            Usu.setDireccionUsuario(Con.Rows[0]["Direccion"].ToString());
            Usu.setNombre_UsuarioUsuario(Con.Rows[0]["Nombre_Usuario"].ToString());
            Usu.setPasswordUsuario(Con.Rows[0]["Password"].ToString());
            Usu.setTelefonoUsuario(Con.Rows[0]["Telefono"].ToString());
            Usu.setDNIUsuario(Con.Rows[0]["DNI"].ToString());
            Usu.setRolUsuario(int.Parse(Con.Rows[0]["Rol"].ToString()));

            return Usu;
        }

        //-------------------------------------------------------------------------
    }
}
