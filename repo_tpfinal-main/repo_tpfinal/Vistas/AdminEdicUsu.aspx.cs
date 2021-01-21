using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;
namespace Vistas
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------
            Usuarios Usu = new Usuarios();
            NegocioUsuario neg = new NegocioUsuario();

            if (IsPostBack == false)
            {

                if (Request.Cookies["NombreUsuario"] != null)
                {

                    if (Request.Cookies["tipo_usuario_logueado"] != null)
                    {

                        if (Request.Cookies["tipo_usuario_logueado"].Value == "1")
                        {
                            String IconosInnerHTML = "";
                            Char B = '"';
                            IconosInnerHTML = "";
                            //ventanita para salir = true asi elimina cookies
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


                if (Session["id_usuario_modif"] != null)
                {
                    NegocioUsuario nu = new NegocioUsuario();
                    DataTable dat_usu = new DataTable();
                    dat_usu = nu.ObtenerUsuario(Session["id_usuario_modif"].ToString());

                    txtApellido.Text = dat_usu.Rows[0][3].ToString();
                    txtDireccion.Text = dat_usu.Rows[0][5].ToString();
                    txtEmail.Text = dat_usu.Rows[0][4].ToString();
                    txtNombre.Text = dat_usu.Rows[0][2].ToString();
                    txtNombredeUsuario.Text = dat_usu.Rows[0][6].ToString();
                    txtTelefono.Text = dat_usu.Rows[0][8].ToString();

                    txtIdUsuario.Text = (Session["id_usuario_modif"].ToString());
                    txtIdUsuario.Enabled = false;
                }
                else
                {
                    Response.Redirect("AdminListUsu.aspx");
                }

            }

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int actualizo;
            Usuarios usur = new Usuarios();
            NegocioUsuario neg = new NegocioUsuario();

            usur.setID_usuario(int.Parse(txtIdUsuario.Text));
            usur.setNombreUsuario(txtNombre.Text);
            usur.setApellidoUsuario(txtApellido.Text);
            usur.setEmailUsuario(txtEmail.Text);
            usur.setDireccionUsuario(txtDireccion.Text);
            usur.setNombre_UsuarioUsuario(txtNombredeUsuario.Text);
            usur.setTelefonoUsuario(txtTelefono.Text);

            bool ya_hay_id = neg.existe_id_user(usur.getID_usuario());


            if (ya_hay_id == false)
            {
                lblMensajedeActualizacion.Text = "No se encuentra registro de usuario";
            }
            else
            {

                actualizo = neg.ActualizarUsuario(usur);

                if (actualizo == 1)
                {
                    lblMensajedeActualizacion.Text = "Los datos del usuario fueron actualizados correctamente";
                }
                else
                {
                    lblMensajedeActualizacion.Text = "Hubo un error al actualizar datos";
                }

            }
               

        }
    }
}