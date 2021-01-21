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
    public partial class Reporte1 : System.Web.UI.Page
    {
        NegocioProducto neg = new NegocioProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            //--------------------------------------

            if (IsPostBack == false)
            {
                var dateTime = DateTime.Now.Date;
                string F_Actual = Convert.ToString(dateTime.ToShortDateString());

                grdRegistros.DataSource = neg.cargar_gridview_neg_reporte1_tex(F_Actual);
                grdRegistros.DataBind();
            }
        }

        protected void grdRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRegistros.PageIndex = e.NewPageIndex;
            grdRegistros.DataSource = neg.cargar_gridview_neg_reporte1_tex(txtFecha.Text);
            grdRegistros.DataBind();
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txtFecha.Text.Length != 0)
            {
                //ME TRAE EL DATATABLE CON LAS FECHAS INGRESADAS EN LOS TEXTBOXS
                grdRegistros.DataSource = neg.cargar_gridview_neg_reporte1_tex(txtFecha.Text);
                grdRegistros.DataBind();
            }
            else
            {
                //SI LOS TEXTBOX ESTAN VACIOS MUESTRA UN LABEL QUE DIGA QUE INGRESE UN NUMERO POR FAVOR
                lbl_Mensaje.Text = "Ingrese un fecha por favor";
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
        }

        protected void btn_Limpiar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            var dateTime = DateTime.Now.Date;
            string F_Actual = Convert.ToString(dateTime.ToShortDateString());
            grdRegistros.DataSource = neg.cargar_gridview_neg_reporte1_tex(F_Actual);
            grdRegistros.DataBind();
        }
    }
}