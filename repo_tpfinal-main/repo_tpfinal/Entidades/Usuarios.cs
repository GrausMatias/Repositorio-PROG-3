using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        private int ID_usuario;
        private int Rol;
        private string Nombre;
        private string Apellido;
        private string Email;
        private string Direccion;
        private string Nombre_Usuario;
        private string Password;
        private string Telefono;
        private string DNI;
        private int Estado;

        public Usuarios()
        {

        }

        public int getID_usuario()
        {
            return ID_usuario;
        }
        public void setID_usuario(int idUsuario)
        {
            ID_usuario = idUsuario;
        }
        public int getRolUsuario()
        {
            return Rol;
        }
        public void setRolUsuario(int rol)
        {
            Rol = rol;
        }

        public String getNombreUsuario()
        {
            return Nombre;
        }
        public void setNombreUsuario(String nombre)
        {
            Nombre = nombre;
        }

        public String getApellidoUsuario()
        {
            return Apellido;
        }
        public void setApellidoUsuario(String apellido)
        {
            Apellido = apellido;
        }

        public String getEmailUsuario()
        {
            return Email;
        }
        public void setEmailUsuario(String email)
        {
            Email = email;
        }

        public String getDireccionUsuario()
        {
            return Direccion;
        }
        public void setDireccionUsuario(String direccion)
        {
            Direccion = direccion;
        }

        public String getNombre_UsuarioUsuario()
        {
            return Nombre_Usuario;
        }
        public void setNombre_UsuarioUsuario(String nombreUsuario)
        {
            Nombre_Usuario = nombreUsuario;
        }

        public String getPasswordUsuario()
        {
            return Password;
        }
        public void setPasswordUsuario(String password)
        {
            Password = password;
        }

        public String getTelefonoUsuario()
        {
            return Telefono;
        }
        public void setTelefonoUsuario(String telefono)
        {
            Telefono = telefono;
        }
        public String getDNIUsuario()
        {
            return DNI;
        }
        public void setDNIUsuario(String dni)
        {
            DNI = dni;
        }
        public int get_Estado()
        {
            return Estado;
        }
        public void set_Estado(int Estado1)
        {
            Estado = Estado1;
        }
    }
}
