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
    public partial class AdminListCategoria : System.Web.UI.Page
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
            NegocioCategoria gCategorias = new NegocioCategoria();
            
            grdCategorias.DataSource = gCategorias.TodasLasCategorias();
            grdCategorias.DataBind();
        }



        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            NegocioCategoria gCategorias = new NegocioCategoria();

            if (txtBuscar.Text != "")
            {
                grdCategorias.DataSource = gCategorias.BuscarCategoria(txtBuscar.Text);
                grdCategorias.DataBind();
            }
            else
            {
                grdCategorias.DataSource = gCategorias.TodasLasCategorias();
                grdCategorias.DataBind();
            }
        }

        protected void btnCrearCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCrearCategoria.aspx");
        }

        protected void grdCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCategorias.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void grdCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCategorias.EditIndex = -1;
            cargarGridView();
        }

        protected void grdCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //busca los editItemTemplate
            string s_id_categoria = ((Label)grdCategorias.Rows[e.RowIndex].FindControl("lbl_eit_idCat")).Text;
            string s_nombre_categoria = ((TextBox)grdCategorias.Rows[e.RowIndex].FindControl("txt_eit_nombreCat")).Text;
            //string s_estado_categoria = ((TextBox)grdCategorias.Rows[e.RowIndex].FindControl("txt_eit_estadoCat")).Text;
            string s_imagen_categoria = ((TextBox)grdCategorias.Rows[e.RowIndex].FindControl("txt_eit_imagen")).Text;
            string s_estado_categoria = ((DropDownList)grdCategorias.Rows[e.RowIndex].FindControl("ddl_eit_estadoCat")).SelectedValue;

            Categorias cat = new Categorias();
            cat.Id_categoria = Convert.ToInt32(s_id_categoria);
            cat.Nombre1 = s_nombre_categoria;
            cat.Imagen1 = s_imagen_categoria;
            cat.Estado1 = Convert.ToBoolean(s_estado_categoria);


            NegocioCategoria negCat = new NegocioCategoria();
            negCat.actualizarCategoria(cat);

            grdCategorias.EditIndex = -1;
            cargarGridView();

        }

        protected void grdCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategorias.PageIndex = e.NewPageIndex;
            cargarGridView();

        }
    }
}