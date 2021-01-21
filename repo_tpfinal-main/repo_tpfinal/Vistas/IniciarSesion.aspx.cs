using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        NegocioUsuario neg = new NegocioUsuario();
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

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Boolean Usuario = neg.BuscarUsuarioNombre_Usuario(txtUsuario.Text);
            Boolean Clave = false;
            lblMensaje.Text = "";


            if (Usuario == true) 
            {
                if (neg.BuscarUsuarioYclave(txtUsuario.Text, txtContraseña.Text) == true)
                {

                    Usuarios EsAdmin = new Usuarios();
                    HttpCookie Usu = new HttpCookie("NombreUsuario", txtUsuario.Text);
                    Usu.Expires = DateTime.Now.AddDays(1);
                    this.Response.Cookies.Add(Usu);
                    HttpCookie Cla = new HttpCookie("NombreClave", txtContraseña.Text);
                    Cla.Expires = DateTime.Now.AddHours(1);
                    this.Response.Cookies.Add(Cla);
                    NegocioUsuario nU = new NegocioUsuario();
                    EsAdmin = nU.DevolverUsuarioCompleto(txtUsuario.Text);
                    HttpCookie Tipo = new HttpCookie("tipo_usuario_logueado", EsAdmin.getRolUsuario().ToString());
                    Tipo.Expires = DateTime.Now.AddDays(1);
                    this.Response.Cookies.Add(Tipo);
                    Clave = true;
                    //System.Diagnostics.Debug.WriteLine("TIPO USUARIO = " + EsAdmin.getRolUsuario().ToString());
                    if(Request["Redirect"] == null) {
                        if (EsAdmin.getRolUsuario() == 1)
                        {
                            Response.Redirect("HomeAdmin.aspx");
                        }
                        else
                        {
                            Response.Redirect("Home.aspx");
                        }
                    }
                    else
                    {
                        if(Request["Redirect"].ToString() == "Carrito")
                        {
                            Response.Redirect("Carrito.aspx");
                        } else
                        {
                            if (EsAdmin.getRolUsuario() == 1)
                            {
                                Response.Redirect("HomeAdmin.aspx");
                            }
                            else
                            {
                                Response.Redirect("Home.aspx");
                            }
                        }
                    }
                }
                if(Clave == false)
                {
                    lblMensaje.Text = "La contraseña es incorrecta";
                }

            }
            if(Usuario == false)
            {
                lblMensaje.Text = "El Usuario Es incorrecto";
            }
            if (txtContraseña.Text == "" || txtUsuario.Text == "")
            {
                lblMensaje.Text = "Por favor complete todos los campos";
            }
        }

        protected void btnIniciarRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
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