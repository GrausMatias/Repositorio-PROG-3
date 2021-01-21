using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------
            Usuarios Usu = new Usuarios();
            if (Request.Cookies["NombreUsuario"] != null)
            {

                if (Request.Cookies["tipo_usuario_logueado"] != null)
                {

                    if (Request.Cookies["tipo_usuario_logueado"].Value == "1")
                    {
                        String IconosInnerHTML = "";
                        Char B = '"';
                        IconosInnerHTML = "";
                        IconosInnerHTML += "<a href=" + B + "/Home.aspx?Sign-out=true" + B + " class=" + B + "fas fa-sign-out-alt" + B + " style=" + B + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + B + " aria-hidden=" + B + "true" + B + "></a>";
                        IconoSalir.InnerHtml = IconosInnerHTML;
                    }
                    else
                    {
                        Response.Redirect("/IniciarSesion.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/IniciarSesion.aspx");
                }

            }
            else
            {
                Response.Redirect("/Home.aspx");
            }
            //-----------------------------------------------


            if (IsPostBack==false)
            {
                ddlRol.Items.Add(new ListItem { Text = "Seleccione", Value = "" });
                ddlRol.Items.Add(new ListItem { Text = "Admin", Value = "1" });
                ddlRol.Items.Add(new ListItem { Text = "User", Value = "2" });
            }
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            NegocioUsuario nuevo_usuario_admin = new NegocioUsuario();
            Usuarios Datos_usuario_admin = new Usuarios();

            Datos_usuario_admin.setRolUsuario(int.Parse(ddlRol.SelectedValue));
            Datos_usuario_admin.setNombreUsuario(txtNombre.Text);
            Datos_usuario_admin.setApellidoUsuario(txtApellido.Text);
            Datos_usuario_admin.setEmailUsuario(txtEmail.Text);
            Datos_usuario_admin.setDireccionUsuario(txtDireccion.Text);
            Datos_usuario_admin.setNombre_UsuarioUsuario(txtNombre_de_Usuario.Text);
            Datos_usuario_admin.setPasswordUsuario(txtContraseña.Text);
            Datos_usuario_admin.setTelefonoUsuario(txtTelefono.Text);
            Datos_usuario_admin.setDNIUsuario(txtDni.Text);

            bool existe = nuevo_usuario_admin.CrearUsuario(Datos_usuario_admin);

            if (existe == true)
            {
                lblUsuarioExiste.Text = "El usuario administrador ya se encuentra registrado";
            }

            else
            {
                lblUsuarioExiste.Text = "El usuario fue agregado con exito";
            }

            limpiar_campos();

            

        }

       public void limpiar_campos()
        {
            txtApellido.Text = "";
            txtContraseña.Text = "";
            txtNombre.Text = "";
            txtNombre_de_Usuario.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtDni.Text = "";


        }
    }
}