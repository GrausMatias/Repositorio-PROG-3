using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;


namespace Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioUsuario neg = new NegocioUsuario();
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

            if (!IsPostBack)
            {
                DataTable tablaUsuario = neg.getTabla();
                grdUsuarios.DataSource = tablaUsuario;
                grdUsuarios.DataBind();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean estadoNombre = neg.BuscarUsuarioNombre(txtBuscar.Text);
            lblMensaje.Text = " ";
            if (txtBuscar.Text == "")
            {
                DataTable tablaUsuario = neg.getTabla();
                grdUsuarios.DataSource = tablaUsuario;
                grdUsuarios.DataBind();
                lblMensaje.Text = " ";
            }

            if (estadoNombre == true && txtBuscar.Text != "")
            {
                DataTable tablaUsuario = neg.getTablaBuscarNombre(txtBuscar.Text);
                grdUsuarios.DataSource = tablaUsuario;
                grdUsuarios.DataBind();
                lblMensaje.Text = " ";
            }

            if (txtBuscar.Text != "" && estadoNombre == false)
            {
                DataTable tablaUsuario = neg.getTablaBuscarNombre(txtBuscar.Text);
                grdUsuarios.DataSource = tablaUsuario;
                grdUsuarios.DataBind();
                lblMensaje.Text = " ";
            }

            if (grdUsuarios.Rows.Count == 0)
            {
                lblMensaje.Text = "El Nombre no se encuentran en la base de datos ";
            }

        }

        protected void grdUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsuarios.PageIndex = e.NewPageIndex;
            DataTable tablaUsuario = neg.getTabla();
            grdUsuarios.DataSource = tablaUsuario;
            grdUsuarios.DataBind();
        }

        protected void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            Boolean estadoApellido = neg.BuscarUsuarioApellido(txtBuscar.Text);
            lblMensaje.Text = " ";

            if (txtBuscar.Text == "")
            {
                DataTable tablaUsuario = neg.getTabla();
                grdUsuarios.DataSource = tablaUsuario;
                grdUsuarios.DataBind();
                lblMensaje.Text = " ";
            }

            if (estadoApellido == true && txtBuscar.Text != "")
            {
                DataTable tablaUsuario = neg.getTablaBuscarApellido(txtBuscar.Text);
                grdUsuarios.DataSource = tablaUsuario;
                grdUsuarios.DataBind();
                lblMensaje.Text = " ";
            }

            if (txtBuscar.Text != "" && estadoApellido == false)
            {
                DataTable tablaUsuario = neg.getTablaBuscarApellido(txtBuscar.Text);
                grdUsuarios.DataSource = tablaUsuario;
                grdUsuarios.DataBind();
                lblMensaje.Text = " ";
            }

            if (grdUsuarios.Rows.Count == 0)
            {
                lblMensaje.Text = "El Apellido no se encuentran en la base de datos ";
            }
        }

        protected void grdUsuarios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //creo y asigno variable session|| del grd la fila que este seleccionada busco el lblid y saco la prop txt
            Session["id_usuario_modif"] = (grdUsuarios.Rows[e.NewSelectedIndex].Cells[1]).Text;
            Response.Redirect("AdminEdicUsu.aspx");
        }
    }
}