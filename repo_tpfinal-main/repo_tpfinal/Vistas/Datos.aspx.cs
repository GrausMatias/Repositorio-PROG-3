
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        NegocioUsuario Neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------
            Usuarios Usu = new Usuarios();
            if (Request.Cookies["NombreUsuario"] != null)
            {
                HttpCookie ck = Request.Cookies["NombreUsuario"];

                Usu = Neg.DevolverUsuarioCompleto(Request.Cookies["NombreUsuario"].Value);


                String IconosInnerHTML = "";
                Char A = '"';

                if (Request.Cookies["tipo_usuario_logueado"] != null)
                {
                    if (Request.Cookies["tipo_usuario_logueado"].Value == "1")
                    {
                        IconosInnerHTML += "<a href=" + A + "/HomeAdmin.aspx" + A + " class=" + A + "fas fa-crown" + A + " style=" + A + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + A + " aria-hidden=" + A + "true" + A + "></a>";
                        accesoAdmin.InnerHtml = IconosInnerHTML;
                        IconosInnerHTML = "";
                    }
                }

                IconosInnerHTML += "<a href=" + A + "/Datos.aspx" + A + " class=" + A + "fas fa-user user" + A + " style=" + A + "text-decoration: none;" + A + "><div id = 'UsuarioLogueadoNombre' runat='server' style='font-size:20px;'>" + Usu.getNombreUsuario() + "</div><div id = 'UsuarioLogueadoApellido' runat='server' style='font-size:20px;'>" + Usu.getApellidoUsuario() + "</div></a>";
                infoUser.InnerHtml = IconosInnerHTML;
                IconosInnerHTML = "";
                IconosInnerHTML += "<a href=" + A + "/Home.aspx?Sign-out=true" + A + " class=" + A + "fas fa-sign-out-alt" + A + " style=" + A + "font-size: 1.6rem;text-decoration: none;color: #40514e;" + A + " aria-hidden=" + A + "true" + A + "></a>";
                IconoSalir.InnerHtml = IconosInnerHTML;
            }
            else
            {
                Response.Redirect("/Home.aspx");
            }
            //-----------------------------------------------


            NegocioCategoria gC = new NegocioCategoria();
            DataTable cat = gC.ObtenerCategorias();
            String CategoriasUl = "";
            CategoriasUl += "<a href =";
            CategoriasUl += '"';
            CategoriasUl += "/Productos.aspx";
            CategoriasUl += '"';
            CategoriasUl += "> Categorias </a>";
            CategoriasUl += "<ul>";

            foreach (DataRow row in cat.Rows)
            {
                CategoriasUl += "<li>";
                String A = "<a href=";
                A += '"';
                A += "/Productos.aspx?Cat=" + row[1].ToString();
                A += '"';
                A += ">" + row[1].ToString() + "</a>";
                CategoriasUl += A;
                CategoriasUl += "</ li >";

            }

            CategoriasUl += "</ul>";
            CargameLasCats.InnerHtml = CategoriasUl;

            // SI HAY CARGO DATOS DEL CARRO
            if (Session["Carrito"] != null)
            {
                String InnerHTML = "";
                DataTable infoCarrito = (DataTable)Session["Carrito"];
                float TotalCarro = 0;
                int CantProds = 0;

                foreach (DataRow row in infoCarrito.Rows)
                {
                    CantProds += int.Parse(row[1].ToString());
                    TotalCarro += CantProds * float.Parse(row[2].ToString());
                }

                InnerHTML += TotalCarro + "(" + CantProds + ")";
                datosCarrito.InnerHtml = InnerHTML;
            }
            if (IsPostBack == false)
            {
                txtNombre.Text = Usu.getNombreUsuario();
                txtApellido.Text = Usu.getApellidoUsuario();
                txtEmail.Text = Usu.getEmailUsuario();
                txtPassword.Text = Usu.getPasswordUsuario();
                txtDireccion.Text = Usu.getDireccionUsuario();
                txtTelefono.Text = Usu.getTelefonoUsuario();

            }


        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            nameValues.Set("Busqueda", txtBuscar.Text);
            string url = Request.Url.AbsolutePath;
            string updatedQueryString = "?" + nameValues.ToString();

            Response.Redirect("/productos.aspx" + updatedQueryString);
        }


        protected void btnGuardarCamb_Click(object sender, EventArgs e)
        {
            Usuarios Usu = new Usuarios();

            HttpCookie ck = Request.Cookies["NombreUsuario"];

            Usu = Neg.DevolverUsuarioCompleto(Request.Cookies["NombreUsuario"].Value);
            int actualizo = 0;


            Usu.setNombreUsuario(txtNombre.Text);
            Usu.setApellidoUsuario(txtApellido.Text);
            Usu.setEmailUsuario(txtEmail.Text);
            Usu.setPasswordUsuario(txtPassword.Text.ToString());
            Usu.setDireccionUsuario(txtDireccion.Text);
            Usu.setTelefonoUsuario(txtTelefono.Text);

            /*
            try
            {
                Neg.ActualizarUsuario(Usu);
                lblMensaje.Text = "Los datos fueron actualizados correctamente";
            }
            catch
            {
                lblMensaje.Text = "Hubo un error al actualizar datos";
                return;
            }
            */


            Boolean UserEmail = Neg.BuscarUsuarioEmail(txtEmail.Text);

            if(UserEmail == false)
            {
                actualizo = Neg.ActualizarUsuario(Usu);

                if (actualizo == 1)
                {
                    lblMensaje.Text = "Los datos fueron actualizados correctamente";
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al actualizar datos";
                }
            }
            else
            {
                lblMensaje.Text = "El Email ya esta en uso. Por favor ingrese uno valido.";
            }

            

            

        }

    }
}
