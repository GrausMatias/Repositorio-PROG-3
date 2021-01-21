using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class AdminListMarcas : System.Web.UI.Page
    {
        NegocioMarca neg = new NegocioMarca();
       
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

            if (IsPostBack == false)
            {
                grdMarcas.DataSource = neg.cargar_gridview_neg();
                grdMarcas.DataBind();
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //NegocioProducto gProd = new NegocioProducto();

            if (txtBuscar.Text.Length != 0)
            {
                grdMarcas.DataSource = neg.BuscarMarcas(txtBuscar.Text);
                grdMarcas.DataBind();
            }
            else
            {
                grdMarcas.DataSource = neg.cargar_gridview_neg();
                grdMarcas.DataBind();
            }
        }

        protected void grdMarcas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMarcas.EditIndex = e.NewEditIndex;
            grdMarcas.DataSource = neg.BuscarMarcas(txtBuscar.Text);
            //grdMarcas.DataSource = neg.cargar_gridview_neg();
            grdMarcas.DataBind();
        }

        protected void grdMarcas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMarcas.EditIndex = -1;
            grdMarcas.DataSource = neg.cargar_gridview_neg();
            grdMarcas.DataBind();
        }

        protected void grdMarcas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String s_IdMarca = ((Label)grdMarcas.Rows[e.RowIndex].FindControl("lbl_eit_IDMarca")).Text;
            String s_Nombre = ((TextBox)grdMarcas.Rows[e.RowIndex].FindControl("txtbox_eit_Nombre")).Text.Trim();
            bool s_Estado = ((CheckBox)grdMarcas.Rows[e.RowIndex].FindControl("cb_eit_Estado")).Checked;

            Marcas mar = new Marcas();
            mar.setID_Marcas(Convert.ToInt32(s_IdMarca));
            mar.setNombre(s_Nombre);
            mar.setEstado(s_Estado);

            if (mar.getNombre().Length != 0)
            {
                if (!neg.ExisteMarcas_Neg(mar))
                {
                    neg.ActualizarMarca_neg(mar);
                    grdMarcas.EditIndex = -1;
                    grdMarcas.DataSource = neg.cargar_gridview_neg();
                    grdMarcas.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('El nombre ingresado ya EXISTE');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Por favor rellene el campo nombre');</script>");
            }
        }

        protected void grdMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMarcas.PageIndex = e.NewPageIndex;
            grdMarcas.DataSource = neg.cargar_gridview_neg();
            grdMarcas.DataBind();
        }

        protected void btnCrearMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCrearMarca.aspx");
        }

        protected void btn_Limpiar_Click(object sender, EventArgs e)
        {
            grdMarcas.DataSource = neg.cargar_gridview_neg();
            grdMarcas.DataBind();
        }
    }
}