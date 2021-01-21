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
    public partial class WebForm4 : System.Web.UI.Page
    {
        NegocioUsuario Neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------------------------------------------
            Usuarios Usu = new Usuarios();
            if (Request.Cookies["NombreUsuario"] != null)
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

                InnerHTML += "$" + TotalCarro + "(" + CantProds + ")";
                datosCarrito.InnerHtml = InnerHTML;
            }

        }

        protected void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bntCrearCuenta_Click(object sender, EventArgs e)
        {
           lblMensaje.Text = "";
            Boolean Usuario = Neg.BuscarUsuarioNombre_Usuario(txtNombreUsuario.Text);
            Boolean UserDni = Neg.BuscarUsuarioDni(txtDni.Text);
            Boolean UserEmail = Neg.BuscarUsuarioEmail(txtEmail.Text);

            if (txtNombre.Text == "" || txtApellido.Text == "" || txtDni.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "" || txtClave.Text == "" || txtValidarClave.Text == "" || txtNombreUsuario.Text == "")
            {
               // lblMensaje.Text = "Por favor Complete todos los campos";
            }
            else if (Usuario == false && UserDni == false && UserEmail == false && txtClave.Text == txtValidarClave.Text)
            {
                //Codigo---------
                Usuarios Datos_usuario = new Usuarios();

                Datos_usuario.setRolUsuario(2);
                Datos_usuario.setNombreUsuario(txtNombre.Text);
                Datos_usuario.setApellidoUsuario(txtApellido.Text);
                Datos_usuario.setEmailUsuario(txtEmail.Text);
                Datos_usuario.setDireccionUsuario(txtDireccion.Text);
                Datos_usuario.setNombre_UsuarioUsuario(txtNombreUsuario.Text);
                Datos_usuario.setPasswordUsuario(txtClave.Text);
                Datos_usuario.setTelefonoUsuario(txtTelefono.Text);
                Datos_usuario.setDNIUsuario(txtDni.Text);

                Neg.CrearUsuarioDirecto(Datos_usuario);
                Response.Redirect("IniciarSesion.aspx");
            }


            if (Usuario == false)
            {
                if (txtClave.Text != txtValidarClave.Text)
                {
                   lblMensaje.Text = "Las Contraseñas no coinsiden, por favor vuelva a intentar";
                }
            }
            else if (Usuario == true || UserDni == true || UserEmail == true)
            {
                lblMensaje.Text = "Este usuario ya exite, por favor intente con otro";
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
    }
}