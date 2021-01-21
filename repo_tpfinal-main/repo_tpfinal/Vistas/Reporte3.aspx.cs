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
    public partial class Reporte3 : System.Web.UI.Page
    {
        public String Consulta = "";
        public String Order = "";
        NegocioVenta nv = new NegocioVenta();
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

            //-------------------------------

            // BUSCO PARAMETROS EN LA URL
            // FECHA INICIAL
            // Supongo que si hay dia hay los otros valores
            if (Request["Indd"] != null)
            {
                // pero por las dudas busco todo XD
                if (Request["Inmm"] != null)
                {
                    if (Request["Inyy"] != null)
                    {
                        // LE SETEO EL VALOR AL DATEPICKER SI YA TENIA...
                        datepickerInicial.Value = Request["Indd"].ToString() + "/" + Request["Inmm"].ToString() + "/" + Request["Inyy"].ToString();
                        Consulta += " AND Fecha >= '" + Request["Inyy"].ToString() + "-" + Request["Inmm"].ToString() + "-" + Request["Indd"].ToString() + "'";
                    }

                }

            }

            // FECHA FINAL
            if (Request["Findd"] != null)
            {
                // pero por las dudas busco todo XD
                if (Request["Finmm"] != null)
                {
                    if (Request["Finyy"] != null)
                    {
                        // LE SETEO EL VALOR AL DATEPICKER SI YA TENIA...
                        datepickerFinal.Value = Request["Findd"].ToString() + "/" + Request["Finmm"].ToString() + "/" + Request["Finyy"].ToString();
                        Consulta += " AND Fecha <= '" + Request["Finyy"].ToString() + "-" + Request["Finmm"].ToString() + "-" + Request["Findd"].ToString() + "'";
                    }

                }

            }

            // PRECIO
            if (Request["Precio"] != null)
            {
                if (Request["Precio"].ToString() == "Mayor")
                {
                    Mayor.Checked = true;
                    Order += " order by Total desc";
                }
                else if (Request["Precio"].ToString() == "Menor")
                {
                    Menor.Checked = true;
                    Order += " order by Total asc";
                }
                else
                {
                    NoFilter.Checked = true;
                }
            }
            else
            {
                NoFilter.Checked = true;
            }

            // PRECIO RANGO
            if (Request["RangoMe"] != null)
            {
                if (Request["RangoMe"].ToString() != null && Request["RangoMe"].ToString() != "")
                {
                    PrecioMin.Value = Request["RangoMe"].ToString();
                    Consulta += " AND Total >= " + Request["RangoMe"].ToString();
                }
                else
                {
                    PrecioMin.Value = "";
                }
            }
            
            if (Request["RangoMa"] != null)
            {

                if (Request["RangoMa"].ToString() != null && Request["RangoMa"].ToString() != "")
                {
                    PrecioMax.Value = Request["RangoMa"].ToString();
                    Consulta += " AND Total <= " + Request["RangoMa"].ToString();
                }
                else
                {
                    PrecioMax.Value = "";
                }

            }

            if (Request["RangoMa"] == null && Request["RangoMe"] == null)
            {
                PrecioMax.Value = "";
                PrecioMin.Value = "";
            }

            // PRODUCTO
            if (Request["Producto"] != null)
            {
                if (Request["Producto"].ToString() == "Mayor")
                {
                    MayorProducto.Checked = true;
                    Order += " order by Cantidad desc";
                }
                else if (Request["Producto"].ToString() == "Menor")
                {
                    MenorProducto.Checked = true;
                    Order += " order by Cantidad asc";
                }
                else
                {
                    NoFilter.Checked = true;
                }
            }
            else
            {
                NoFilter.Checked = true;
            }


            grdVentas.DataSource = nv.ConsultaParaReporte3(Consulta,Order);
            grdVentas.DataBind();

            if(grdVentas.Rows.Count == 0)
            {
                NOHAYVENTAS.Text = "No se encontraron ventas para los filtros solicitados";
                NOHAYVENTAS.Visible = true;
            } else
            {
                NOHAYVENTAS.Visible = false;
            }


        }

        protected void grdVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVentas.PageIndex = e.NewPageIndex;
            grdVentas.DataSource = nv.ConsultaParaReporte3(Consulta, Order);
            grdVentas.DataBind();
        }

        protected void grdVentas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            String ID = ((Label)grdVentas.Rows[e.NewSelectedIndex].FindControl("lblId")).Text;
            Response.Redirect("AdminDetalleVenta.aspx?idVenta=" + ID + "&Redirect=Reporte3");
        }
    }
}