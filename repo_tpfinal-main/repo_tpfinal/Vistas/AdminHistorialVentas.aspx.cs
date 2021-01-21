using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class AdminHistorialVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //mostrar todas las cats
            //cargarGridView();
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

            if (IsPostBack == false)
            {
                cargarGridView();
            }

        }

        public void cargarGridView()
        {
            NegocioVenta gVenta = new NegocioVenta();

            grdRegistros.DataSource = gVenta.TodasLasVentas();
            grdRegistros.DataBind();
        }

        protected void grdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRegistros.PageIndex = e.NewPageIndex;
            cargarGridView();
        }

        protected void grdRegistros_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string s_idVenta = ((Label)grdRegistros.Rows[e.NewSelectedIndex].FindControl("lbl_it_id")).Text;

            Ventas vent = new Ventas();

            vent.ID_venta1 = Convert.ToInt32(s_idVenta);
            //direccionar a detalles de venta con idVenta
            Response.Redirect("AdminDetalleVenta.aspx?idVenta="+ vent.ID_venta1);
        }
    }
}